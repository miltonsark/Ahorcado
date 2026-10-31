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
}
