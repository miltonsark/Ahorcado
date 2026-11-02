namespace Ahorcado;

public class Traductor
{
    private static readonly Dictionary<string, string> Ingles = new()
    {
        ["Ganaste"] = "You won",
        ["Perdiste"] = "You lost"
    };

    private readonly Idioma _idioma;

    public Traductor(Idioma idioma) => _idioma = idioma;

    public string Traducir(string texto)
    {
        if (_idioma == Idioma.Espanol) return texto;

        return Ingles.GetValueOrDefault(texto, texto);
    }
}
