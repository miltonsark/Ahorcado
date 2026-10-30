using Ahorcado.AcceptanceTests.Support;
using Microsoft.Playwright;
using Reqnroll;

[Binding]
public class DificultadSteps
{
    private readonly Navegador _navegador;

    public DificultadSteps(Navegador navegador) => _navegador = navegador;

    [When("elijo la dificultad {string}")]
    public async Task CuandoElijoLaDificultad(string dificultad)
    {
        await _navegador.Page.GetByTestId("dificultad")
            .SelectOptionAsync(new SelectOptionValue { Label = dificultad });
    }
}