using Juego = Ahorcado.Ahorcado;
using Xunit;

namespace Tests;

public class AhorcadoTests
{
    [Fact]
    public void PalabraEnmascarada_DeGatoMuestraUnGuionPorLetra()
    {
        var juego = new Juego("GATO");

        Assert.Equal("   _", juego.PalabraEnmascarada());
    }
}