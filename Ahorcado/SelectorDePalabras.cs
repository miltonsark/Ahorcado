namespace Ahorcado;

public class SelectorDePalabras
{
    private static readonly string[] Colores = { "ROJO", "AZUL", "VERDE", "NEGRO", "BLANCO" };

    private readonly Func<int, int> _elegirIndice;

    public SelectorDePalabras(Func<int, int> elegirIndice) => _elegirIndice = elegirIndice;

    public string Elegir(string categoria) => Colores[_elegirIndice(Colores.Length)];
}