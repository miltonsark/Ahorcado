using Ahorcado.AcceptanceTests.Support;
using Microsoft.Playwright;
using Reqnroll;
using System.Text.RegularExpressions;

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

    [Then("la letra usada {string} está marcada como errada")]
    public async Task EntoncesLaLetraUsadaEstaMarcadaComoErrada(string letra)
    {
        var usada = _navegador.Page.GetByTestId("letras-usadas").Locator("li", new() { HasText = letra });
        await Assertions.Expect(usada).ToHaveClassAsync(new Regex(@"\berrada\b"));
    }
}
