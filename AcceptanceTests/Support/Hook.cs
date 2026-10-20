using System.Diagnostics;
using Microsoft.Playwright;
using Reqnroll;

namespace Ahorcado.AcceptanceTests.Support;

[Binding]
public class Hooks
{
    public const string BaseUrl = "http://localhost:7122";
    private static Process? _server;

    private readonly Navegador _nav;
    private IPlaywright? _playwright;
    private IBrowser? _browser;

    public Hooks(Navegador nav) => _nav = nav;

    [BeforeTestRun]
    public static async Task LevantarServidor()
    {
        var raiz = new DirectoryInfo(AppContext.BaseDirectory);
        while (raiz != null && !File.Exists(Path.Combine(raiz.FullName, "WebAhorcado", "WebAhorcado.csproj")))
            raiz = raiz.Parent;
        if (raiz == null)
            throw new InvalidOperationException("No encuentro la carpeta WebAhorcado.");

        _server = Process.Start(new ProcessStartInfo
        {
            FileName = "dotnet",
            Arguments = $"run --project WebAhorcado --no-launch-profile --urls {BaseUrl}",
            WorkingDirectory = raiz.FullName,
            UseShellExecute = false,
            CreateNoWindow = true
        }) ?? throw new InvalidOperationException("No pude iniciar WebAhorcado.");

        using var http = new HttpClient();
        var limite = DateTime.UtcNow.AddSeconds(120);
        while (DateTime.UtcNow < limite)
        {
            try
            {
                var respuesta = await http.GetAsync(BaseUrl);
                if (respuesta.IsSuccessStatusCode) return;
            }
            catch (HttpRequestException) { }
            await Task.Delay(500);
        }

        throw new InvalidOperationException("WebAhorcado no arrancó en 120 s.");
    }

    [AfterTestRun]
    public static void BajarServidor()
    {
        if (_server is { HasExited: false })
            _server.Kill(entireProcessTree: true);
    }

    [BeforeScenario]
    public async Task AbrirNavegador()
    {
        _playwright = await Playwright.CreateAsync();
        _browser = await _playwright.Chromium.LaunchAsync();
        _nav.Page = await _browser.NewPageAsync();
    }

    [AfterScenario]
    public async Task CerrarNavegador()
    {
        if (_browser != null) await _browser.CloseAsync();
        _playwright?.Dispose();
    }
}