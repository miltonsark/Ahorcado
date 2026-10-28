using Ahorcado.AcceptanceTests.Support;
using Microsoft.Playwright;
using Reqnroll;

[Binding]
public class MensajeSteps
{
    private readonly Navegador _navegador;

    public MensajeSteps(Navegador navegador) => _navegador = navegador;

    [Then("veo el mensaje {string}")]
    public async Task EntoncesVeoElMensaje(string esperado)
    {
        var mensaje = _navegador.Page.GetByTestId("mensaje");
        await Assertions.Expect(mensaje).ToHaveTextAsync(esperado);
    }
}