namespace Ahorcado;

public class Configuracion
{
    public Idioma Idioma { get; set; } = Idioma.Espanol;

    public string Categoria { get; set; } = "";

    public Ahorcado CrearPartida(SelectorDePalabras selector, string? palabraFija = null)
        => new Ahorcado(SelectorDePalabras.PalabraPorDefecto(Idioma));
}
