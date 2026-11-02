using System.Text.RegularExpressions;
using Ahorcado.AcceptanceTests.Support;
using Microsoft.Playwright;
using Reqnroll;

[Binding]
public class TiempoSteps
{
    private readonly Navegador _navegador;

    public TiempoSteps(Navegador navegador) => _navegador = navegador;

    [When("elijo el límite de tiempo {string}")]
    public async Task CuandoElijoElLimiteDeTiempo(string limite)
    {
        await _navegador.Page.GetByTestId("limite-tiempo")
            .SelectOptionAsync(new SelectOptionValue { Label = limite });
    }

    [Then("veo el tiempo restante entre {int} y {int}")]
    public async Task EntoncesVeoElTiempoRestanteEntre(int minimo, int maximo)
    {
        var tiempo = _navegador.Page.GetByTestId("tiempo-restante");
        await Assertions.Expect(tiempo).ToHaveTextAsync(new Regex(@"^\d+$"));
        var segundos = int.Parse(await tiempo.InnerTextAsync());
        Assert.InRange(segundos, minimo, maximo);
    }

    [Given("que ingreso a la partida con la palabra {string} y {int} segundos de límite")]
    public async Task DadoIngresoConLimite(string palabra, int segundos)
    {
        await _navegador.Page.GotoAsync($"{Hooks.BaseUrl}/?word={palabra}&tiempo={segundos}");
    }

    [When("espero {int} segundos")]
    public async Task CuandoEspero(int segundos)
    {
        await _navegador.Page.WaitForTimeoutAsync(segundos * 1000);
    }
}