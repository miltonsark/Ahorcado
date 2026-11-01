using System.Text.RegularExpressions;
using Ahorcado.AcceptanceTests.Support;
using Microsoft.Playwright;
using Reqnroll;

[Binding]
public class CategoriaSteps
{
    private readonly Navegador _navegador;

    public CategoriaSteps(Navegador navegador) => _navegador = navegador;

    [When("elijo la categoría {string}")]
    public async Task CuandoElijoLaCategoria(string categoria)
    {
        await _navegador.Page.GetByTestId("categoria")
            .SelectOptionAsync(new SelectOptionValue { Label = categoria });
    }

    [Then("la palabra revelada es una de {string}")]
    public async Task EntoncesLaPalabraReveladaEsUnaDe(string lista)
    {
        // "ROJO" se muestra como "R O J O"
        var opciones = lista.Split(", ")
            .Select(palabra => string.Join(" ", palabra.Select(letra => letra.ToString())));
        var patron = new Regex("^(" + string.Join("|", opciones) + ")$");
        await Assertions.Expect(_navegador.Page.GetByTestId("palabra-oculta")).ToHaveTextAsync(patron);
    }

    [Then("veo la categoría {string}")]
    public async Task EntoncesVeoLaCategoria(string esperada)
    {
        var categoria = _navegador.Page.GetByTestId("categoria-actual");
        await Assertions.Expect(categoria).ToHaveTextAsync(esperada);
    }
}