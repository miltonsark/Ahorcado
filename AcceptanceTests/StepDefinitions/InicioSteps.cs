using Ahorcado.AcceptanceTests.Support;
using Microsoft.Playwright;
using Reqnroll;

[Binding]
public class InicioSteps
{
    private readonly Navegador _navegador;

    public InicioSteps(Navegador navegador) => _navegador = navegador;

    [Then("veo la opción {string}")]
    public async Task EntoncesVeoLaOpcion(string opcion)
    {
        var enlace = _navegador.Page.GetByRole(AriaRole.Link, new() { Name = opcion, Exact = true });
        await Assertions.Expect(enlace).ToBeVisibleAsync();
    }

    [When("elijo {string}")]
    public async Task CuandoElijo(string opcion)
    {
        await _navegador.Page.GetByRole(AriaRole.Link, new() { Name = opcion, Exact = true }).ClickAsync();
    }

    [When("inicio la partida con la palabra {string}")]
    public async Task CuandoInicioLaPartidaConLaPalabra(string palabra)
    {
        // Navega dentro de la app sin recargar, así se conserva la configuración guardada
        await _navegador.Page.EvaluateAsync($"Blazor.navigateTo('partida?word={palabra}')");
        await Assertions.Expect(_navegador.Page.GetByTestId("palabra-oculta")).ToBeVisibleAsync();
    }

    [When("inicio la partida con las palabras {string}")]
    public async Task CuandoInicioLaPartidaConLasPalabras(string palabras)
    {
        // Una palabra por jugador, en orden: "GATO, PERRO" -> partida?word=GATO,PERRO
        var lista = palabras.Replace(" ", "");
        await _navegador.Page.EvaluateAsync($"Blazor.navigateTo('partida?word={lista}')");
        await Assertions.Expect(_navegador.Page.GetByTestId("palabra-oculta")).ToBeVisibleAsync();
    }
}
