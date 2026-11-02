using Ahorcado.AcceptanceTests.Support;
using Microsoft.Playwright;
using Reqnroll;

[Binding]
public class DibujoSteps
{
    private readonly Navegador _navegador;

    public DibujoSteps(Navegador navegador) => _navegador = navegador;

    [Then("veo {int} partes del dibujo")]
    public async Task EntoncesVeoPartesDelDibujo(int cantidad)
    {
        var partes = _navegador.Page.Locator("[data-testid^='parte-']");
        await Assertions.Expect(partes).ToHaveCountAsync(cantidad);
    }

    [When("elijo el skin {string}")]
    public async Task CuandoElijoElSkin(string skin)
    {
        await _navegador.Page.GetByTestId("skin")
            .SelectOptionAsync(new SelectOptionValue { Label = skin });
    }

    [Then("el dibujo usa el skin {string}")]
    public async Task EntoncesElDibujoUsaElSkin(string skin)
    {
        var dibujo = _navegador.Page.GetByTestId("dibujo");
        await Assertions.Expect(dibujo).ToHaveAttributeAsync("data-skin", skin);
    }

    [Then("el selector de skin ofrece {string}")]
    public async Task EntoncesElSelectorDeSkinOfrece(string skin)
    {
        var opcion = _navegador.Page.GetByTestId("skin").Locator("option", new() { HasText = skin });
        await Assertions.Expect(opcion).ToHaveCountAsync(1);
    }
}