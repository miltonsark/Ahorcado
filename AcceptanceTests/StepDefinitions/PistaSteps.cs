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

    [Then("el botón de pista está deshabilitado")]
    public async Task EntoncesElBotonDePistaEstaDeshabilitado()
    {
        var boton = _navegador.Page.GetByTestId("pista");
        await Assertions.Expect(boton).ToBeDisabledAsync();
    }
}
