namespace Ahorcado;

public class Configuracion
{
    public Idioma Idioma { get; set; } = Idioma.Espanol;

    public string Categoria { get; set; } = "";

    public Dificultad Dificultad { get; set; } = Dificultad.Normal;

    public Ahorcado CrearPartida(SelectorDePalabras selector, string? palabraFija = null)
        => new Ahorcado(Categoria == "" ? SelectorDePalabras.PalabraPorDefecto(Idioma) : selector.Elegir(Categoria, Idioma));
}
