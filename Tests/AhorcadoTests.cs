using Juego = Ahorcado.Ahorcado;
using Xunit;

namespace Tests;

public class AhorcadoTests
{
    [Fact]
    public void PalabraEnmascarada_DeGatoMuestraUnGuionPorLetra()
    {
        var juego = new Juego("GATO");

        Assert.Equal("_ _ _ _", juego.PalabraEnmascarada());
    }

    [Fact]
    public void PalabraEnmascarada_DePerro_MuestraUnGuionPorLetra()
    {
        var juego = new Juego("PERRO");

        Assert.Equal("_ _ _ _ _", juego.PalabraEnmascarada());
    }

    [Fact]
    public void Adivinar_A_en_GATO_revela_la_letra()
    {
        var juego = new Juego("GATO");

        juego.Adivinar('A');

        Assert.Equal("_ A _ _", juego.PalabraEnmascarada());
    }
}
