using Ahorcado.AcceptanceTests.Support;
using Microsoft.Playwright;
using Reqnroll;

[Binding]
public class ResultadoSteps
{
    private readonly Navegador _navegador;

    public ResultadoSteps(Navegador navegador) => _navegador = navegador;

    [Then("veo el resultado {string}")]
    public async Task EntoncesVeoElResultado(string esperado)
    {
        var resultado = _navegador.Page.GetByTestId("resultado");
        await Assertions.Expect(resultado).ToHaveTextAsync(esperado);
    }
}
