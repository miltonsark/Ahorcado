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
}
