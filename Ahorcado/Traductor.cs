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

        if (texto.StartsWith("La letra "))
            return $"The letter {texto[9]} was already used";

        return Ingles.GetValueOrDefault(texto, texto);
    }
}
