using Ahorcado.AcceptanceTests.Support;
using Microsoft.Playwright;
using Reqnroll;

[Binding]
public class ErroresSteps
{
    private readonly Navegador _navegador;

    public ErroresSteps(Navegador navegador) => _navegador = navegador;

    [Then("veo {int} errores")]
    public async Task EntoncesVeoLosErrores(int cantidad)
    {
        var errores = _navegador.Page.GetByTestId("errores");
        await Assertions.Expect(errores).ToHaveTextAsync(cantidad.ToString());
    }
}
