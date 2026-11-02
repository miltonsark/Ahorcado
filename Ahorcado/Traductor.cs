namespace Ahorcado;

public class Traductor
{
    private static readonly Dictionary<string, string> Ingles = new()
    {
        ["Ganaste"] = "You won",
        ["Perdiste"] = "You lost"
    };

    public Traductor(Idioma idioma)
    {
    }

    public string Traducir(string texto) => Ingles.GetValueOrDefault(texto, texto);
}
