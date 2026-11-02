using Ahorcado.AcceptanceTests.Support;
using Microsoft.Playwright;
using Reqnroll;

[Binding]
public class TurnosSteps
{
    private readonly Navegador _navegador;

    public TurnosSteps(Navegador navegador) => _navegador = navegador;

    [When("paso a la siguiente partida")]
    public async Task CuandoPasoALaSiguientePartida()
    {
        await _navegador.Page.GetByTestId("siguiente-partida")
            .ClickAsync(new LocatorClickOptions { Timeout = 5000 });
    }
}