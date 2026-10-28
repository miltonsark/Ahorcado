using Ahorcado.AcceptanceTests.Support;
using Microsoft.Playwright;
using Reqnroll;

[Binding]
public class PuntajeSteps
{
    private readonly Navegador _navegador;

    public PuntajeSteps(Navegador navegador) => _navegador = navegador;

    [Then("veo el puntaje {int}")]
    public async Task EntoncesVeoElPuntaje(int puntaje)
    {
        var elemento = _navegador.Page.GetByTestId("puntaje");
        await Assertions.Expect(elemento).ToHaveTextAsync(puntaje.ToString());
    }
}