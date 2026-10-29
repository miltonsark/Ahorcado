using Ahorcado.AcceptanceTests.Support;
using Microsoft.Playwright;
using Reqnroll;

[Binding]
public class PistaSteps
{
    private readonly Navegador _navegador;

    public PistaSteps(Navegador navegador) => _navegador = navegador;

    [When("pido una pista")]
    public async Task CuandoPidoUnaPista()
    {
        await _navegador.Page.GetByTestId("pista")
            .ClickAsync(new LocatorClickOptions { Timeout = 5000 });
    }
}