using Ahorcado.AcceptanceTests.Support;
using Microsoft.Playwright;
using Reqnroll;

[Binding]
public class JugadorSteps
{
    private readonly Navegador _navegador;

    public JugadorSteps(Navegador navegador) => _navegador = navegador;

    [When("ingreso el nombre {string}")]
    public async Task CuandoIngresoElNombre(string nombre)
    {
        await _navegador.Page.GetByTestId("nombre-input")
            .FillAsync(nombre, new LocatorFillOptions { Timeout = 5000 });
    }

    [Then("veo el jugador {string}")]
    public async Task EntoncesVeoElJugador(string esperado)
    {
        var jugador = _navegador.Page.GetByTestId("jugador");
        await Assertions.Expect(jugador).ToHaveTextAsync(esperado);
    }
}
