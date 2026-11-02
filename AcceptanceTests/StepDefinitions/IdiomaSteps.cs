using Ahorcado.AcceptanceTests.Support;
using Microsoft.Playwright;
using Reqnroll;

[Binding]
public class IdiomaSteps
{
    private readonly Navegador _navegador;

    public IdiomaSteps(Navegador navegador) => _navegador = navegador;

    [When("elijo el idioma {string}")]
    public async Task CuandoElijoElIdioma(string idioma)
    {
        await _navegador.Page.GetByTestId("idioma")
            .SelectOptionAsync(new SelectOptionValue { Label = idioma });
    }

    [Then("el idioma elegido es {string}")]
    public async Task EntoncesElIdiomaElegidoEs(string valor)
    {
        var lista = _navegador.Page.GetByTestId("idioma");
        await Assertions.Expect(lista).ToHaveValueAsync(valor);
    }
}
