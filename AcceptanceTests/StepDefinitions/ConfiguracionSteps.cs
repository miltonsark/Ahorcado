using Ahorcado.AcceptanceTests.Support;
using Microsoft.Playwright;
using Reqnroll;

[Binding]
public class ConfiguracionSteps
{
    private readonly Navegador _navegador;

    public ConfiguracionSteps(Navegador navegador) => _navegador = navegador;

    [When("elijo usar la configuración predeterminada")]
    public async Task CuandoElijoUsarLaConfiguracionPredeterminada()
    {
        await _navegador.Page.GetByTestId("config-predeterminada")
            .ClickAsync(new LocatorClickOptions { Timeout = 5000 });
    }

    [Given("que navego a la configuración")]
    public async Task DadoQueNavegoALaConfiguracion()
    {
        await _navegador.Page.GotoAsync($"{Hooks.BaseUrl}/configuracion");
    }

    [When("guardo la configuración")]
    public async Task CuandoGuardoLaConfiguracion()
    {
        await _navegador.Page.GetByTestId("guardar-configuracion").ClickAsync();
    }
}