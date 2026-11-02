namespace Ahorcado;

public class Configuracion
{
    public Idioma Idioma { get; set; } = Idioma.Espanol;

    public string Categoria { get; set; } = "";

    public Dificultad Dificultad { get; set; } = Dificultad.Normal;

    public int Tiempo { get; set; }

    public Ahorcado CrearPartida(SelectorDePalabras selector, string? palabraFija = null)
    {
        var palabra = Categoria == "" ? SelectorDePalabras.PalabraPorDefecto(Idioma) : selector.Elegir(Categoria, Idioma);
        return new Ahorcado(palabra, Dificultad);
    }
}
