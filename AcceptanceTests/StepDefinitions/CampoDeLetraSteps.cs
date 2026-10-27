using Ahorcado.AcceptanceTests.Support;
using Microsoft.Playwright;
using Reqnroll;

[Binding]
public class CampoDeLetraSteps
{
    private readonly Navegador _navegador;

    public CampoDeLetraSteps(Navegador navegador) => _navegador = navegador;

    [Then("el campo de letra está deshabilitado")]
    public async Task EntoncesElCampoDeLetraEstaDeshabilitado()
    {
        var campo = _navegador.Page.GetByTestId("letra-input");
        await Assertions.Expect(campo).ToBeDisabledAsync();
    }
}