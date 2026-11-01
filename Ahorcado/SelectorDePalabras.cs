namespace Ahorcado;

public class SelectorDePalabras
{
    private static readonly Dictionary<string, string[]> Palabras = new()
    {
        ["Animales"] = new[] { "GATO", "PERRO", "CABALLO", "TIGRE", "JIRAFA" },
        ["Frutas"] = new[] { "MANZANA", "BANANA", "PERA", "UVA", "NARANJA" },
        ["Colores"] = new[] { "ROJO", "AZUL", "VERDE", "NEGRO", "BLANCO" }
    };

    private readonly Func<int, int> _elegirIndice;

    public SelectorDePalabras(Func<int, int> elegirIndice) => _elegirIndice = elegirIndice;

    public string Elegir(string categoria)
    {
        var palabras = Palabras[categoria];
        return palabras[_elegirIndice(palabras.Length)];
    }
}