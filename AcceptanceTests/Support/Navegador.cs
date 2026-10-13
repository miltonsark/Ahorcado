using Microsoft.Playwright;

namespace Ahorcado.AcceptanceTests.Support;

public class Navegador
{
    public IPage Page { get; set; } = null!;
}
