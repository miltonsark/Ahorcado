using Ahorcado.AcceptanceTests.Support;
using Microsoft.Playwright;
using Reqnroll;

[Binding]
public class ResponsiveSteps
{
    private readonly Navegador _navegador;

    public ResponsiveSteps(Navegador navegador) => _navegador = navegador;

    [Given("que uso un celular")]
    public async Task DadoQueUsoUnCelular()
    {
        await _navegador.Page.SetViewportSizeAsync(360, 740);
    }

    [When("abro la pantalla {string}")]
    public async Task CuandoAbroLaPantalla(string ruta)
    {
        await _navegador.Page.GotoAsync($"{Hooks.BaseUrl}{ruta}");
        await Assertions.Expect(_navegador.Page.Locator("h1")).ToBeVisibleAsync();
    }

    [Then("la pantalla no se desborda a lo ancho")]
    public async Task EntoncesLaPantallaNoSeDesborda()
    {
        var desborda = await _navegador.Page.EvaluateAsync<bool>(
            "document.documentElement.scrollWidth > document.documentElement.clientWidth");
        Assert.False(desborda);
    }
}