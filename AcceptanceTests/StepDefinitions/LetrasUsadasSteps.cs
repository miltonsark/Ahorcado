using Ahorcado.AcceptanceTests.Support;
using Microsoft.Playwright;
using Reqnroll;

[Binding]
public class LetrasUsadasSteps
{
    private readonly Navegador _navegador;

    public LetrasUsadasSteps(Navegador navegador) => _navegador = navegador;

    [Then("veo las letras usadas {string}")]
    public async Task EntoncesVeoLasLetrasUsadas(string letras)
    {
        var esperadas = letras.Split(", ");
        var usadas = _navegador.Page.GetByTestId("letras-usadas").Locator("li");
        await Assertions.Expect(usadas).ToHaveTextAsync(esperadas);
    }
}
