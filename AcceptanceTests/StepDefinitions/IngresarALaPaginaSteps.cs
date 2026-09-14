using Microsoft.Playwright;
using Reqnroll;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ahorcado.AcceptanceTests.StepDefinitions
{
    [Binding]
    public class IngresarALaPaginaSteps
    {
        private IPage _page = null!;

        [Given(@"que navego a la página principal")]
        public async Task DadoQueNavegoALaPaginaPrincipal()
        {
            var playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync();
            _page = await browser.NewPageAsync();
            await _page.GotoAsync("http://localhost:5000/");
        }

        [Then(@"veo el título ""(.*)""")]
        public async Task EntoncesVeoElTitulo(string titulo)
        {
            var texto = await _page.Locator("h1").InnerTextAsync();
            Assert.Equal(titulo, texto);
        }

        [Then(@"veo el tablero de juego")]
        public async Task EntoncesVeoElTableroDeJuego()
        {
            var visible = await _page.Locator("[data-testid=word]").IsVisibleAsync();
            Assert.True(visible);
        }
    }
}
