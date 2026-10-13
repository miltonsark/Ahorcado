using Ahorcado.AcceptanceTests.Support;
using Microsoft.Playwright;
using Reqnroll;

namespace Ahorcado.AcceptanceTests.StepDefinitions
{
    [Binding]
    public class IngresarALaPaginaSteps
    {
        private readonly Navegador _nav;

        public IngresarALaPaginaSteps(Navegador nav) => _nav = nav;

        [Given(@"que navego a la página principal")]
        public async Task DadoQueNavegoALaPaginaPrincipal()
        {
            await _nav.Page.GotoAsync($"{Hooks.BaseUrl}/");
        }

        [Then(@"veo el título ""(.*)""")]
        public async Task EntoncesVeoElTitulo(string titulo)
        {
            var texto = await _nav.Page.Locator("h1").InnerTextAsync();
            Assert.Equal(titulo, texto);
        }

        [Then(@"veo el tablero de juego")]
        public async Task EntoncesVeoElTableroDeJuego()
        {
            var visible = await _nav.Page.Locator("[data-testid=word]").IsVisibleAsync();
            Assert.True(visible);
        }
    }
}