namespace Ahorcado;

public class SelectorDePalabras
{
    private static readonly Dictionary<string, string[]> Palabras = new()
    {
        ["Animales"] = new[] { "GATO", "PERRO", "CABALLO", "TIGRE", "JIRAFA" },
        ["Frutas"] = new[] { "MANZANA", "BANANA", "PERA", "UVA", "NARANJA" },
        ["Colores"] = new[] { "ROJO", "AZUL", "VERDE", "NEGRO", "BLANCO" }
    };

    private static readonly Dictionary<string, string[]> PalabrasEnIngles = new()
    {
        ["Animales"] = new[] { "CAT", "DOG", "HORSE", "TIGER", "GIRAFFE" },
        ["Frutas"] = new[] { "APPLE", "BANANA", "PEAR", "GRAPE", "ORANGE" },
        ["Colores"] = new[] { "RED", "BLUE", "GREEN", "BLACK", "WHITE" }
    };

    private readonly Func<int, int> _elegirIndice;

    public SelectorDePalabras(Func<int, int> elegirIndice) => _elegirIndice = elegirIndice;

    public string Elegir(string categoria, Idioma idioma = Idioma.Espanol)
    {
        var palabras = (idioma == Idioma.Ingles ? PalabrasEnIngles : Palabras)[categoria];
        return palabras[_elegirIndice(palabras.Length)];
    }

    public string ElegirCategoria() =>
        Palabras.Keys.ElementAt(_elegirIndice(Palabras.Count));

    public static string PalabraPorDefecto(Idioma idioma) =>
        idioma == Idioma.Ingles ? "HANGMAN" : "AHORCADO";

    public IReadOnlyList<string> ElegirDistintas(string categoria, Idioma idioma, int cantidad) => [];
}
