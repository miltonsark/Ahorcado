using Ahorcado.AcceptanceTests.Support;
using Microsoft.Playwright;
using Reqnroll;

[Binding]
public class PalabraOcultaSteps
{
    private readonly Navegador _navegador;

    public PalabraOcultaSteps(Navegador navegador) => _navegador = navegador;

    [Given("que ingreso a la partida con la palabra {string}")]
    public async Task DadoIngresoALaPartida(string palabra)
        => await _navegador.Page.GotoAsync($"{Hooks.BaseUrl}/?word={palabra}");

    [Then("veo la palabra oculta {string}")]
    public async Task EntoncesVeoLaPalabraOculta(string esperado)
    {
        var palabra = _navegador.Page.GetByTestId("palabra-oculta");
        await Assertions.Expect(palabra).ToHaveTextAsync(esperado);
    }
}