using Ahorcado.AcceptanceTests.Support;
using Microsoft.Playwright;
using Reqnroll;

[Binding]
public class HistorialSteps
{
    private readonly Navegador _navegador;

    public HistorialSteps(Navegador navegador) => _navegador = navegador;

    [Then("la entrada {int} del historial es {string}")]
    public async Task EntoncesLaEntradaDelHistorialEs(int posicion, string esperado)
    {
        var entrada = _navegador.Page.GetByTestId("historial").Locator("li").Nth(posicion - 1);
        await Assertions.Expect(entrada).ToHaveTextAsync(esperado);
    }

    [When("recargo la página")]
    public async Task CuandoRecargoLaPagina()
    {
        await _navegador.Page.ReloadAsync();
    }

    [Then("el historial está vacío")]
    public async Task EntoncesElHistorialEstaVacio()
    {
        // Espera a que la página termine de cargar antes de contar
        await Assertions.Expect(_navegador.Page.GetByTestId("historial")).ToBeAttachedAsync();
        var entradas = _navegador.Page.GetByTestId("historial").Locator("li");
        await Assertions.Expect(entradas).ToHaveCountAsync(0);
    }

    [Then("el jugador {int} de la lista es {string}")]
    public async Task EntoncesElJugadorDeLaListaEs(int posicion, string esperado)
    {
        var jugador = _navegador.Page.GetByTestId("jugadores").Locator("li").Nth(posicion - 1);
        await Assertions.Expect(jugador).ToHaveTextAsync(esperado);
    }
}
