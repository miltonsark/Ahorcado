using Ahorcado.AcceptanceTests.Support;
using Microsoft.Playwright;
using Reqnroll;

[Binding]
public class InicioSteps
{
    private readonly Navegador _navegador;

    public InicioSteps(Navegador navegador) => _navegador = navegador;

    [Then("veo la opción {string}")]
    public async Task EntoncesVeoLaOpcion(string opcion)
    {
        var enlace = _navegador.Page.GetByRole(AriaRole.Link, new() { Name = opcion, Exact = true });
        await Assertions.Expect(enlace).ToBeVisibleAsync();
    }
}
