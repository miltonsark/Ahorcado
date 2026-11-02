using Ahorcado.AcceptanceTests.Support;
using Microsoft.Playwright;
using Reqnroll;

[Binding]
public class DibujoSteps
{
    private readonly Navegador _navegador;

    public DibujoSteps(Navegador navegador) => _navegador = navegador;

    [Then("veo {int} partes del dibujo")]
    public async Task EntoncesVeoPartesDelDibujo(int cantidad)
    {
        var partes = _navegador.Page.Locator("[data-testid^='parte-']");
        await Assertions.Expect(partes).ToHaveCountAsync(cantidad);
    }
}