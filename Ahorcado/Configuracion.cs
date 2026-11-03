namespace Ahorcado;

public class Configuracion
{
    public Idioma Idioma { get; set; } = Idioma.Espanol;

    public string Categoria { get; set; } = "Aleatoria";

    public Dificultad Dificultad { get; set; } = Dificultad.Normal;

    public int Tiempo { get; set; }

    public Ahorcado CrearPartida(SelectorDePalabras selector, string? palabraFija = null)
    {
        var categoria = Categoria == "Aleatoria" && palabraFija is null ? selector.ElegirCategoria() : Categoria;
        var palabra = palabraFija
            ?? (categoria == "" ? SelectorDePalabras.PalabraPorDefecto(Idioma) : selector.Elegir(categoria, Idioma));
        var juego = new Ahorcado(palabra, Dificultad) { Categoria = categoria };
        if (Tiempo > 0)
            juego.EstablecerLimite(Tiempo);
        return juego;
    }

    public IReadOnlyList<Ahorcado> CrearPartidas(SelectorDePalabras selector, int cantidad, IReadOnlyList<string>? palabrasFijas = null)
    {
        var categoria = Categoria == "Aleatoria" && palabrasFijas is null
            ? selector.ElegirCategoria()
            : Categoria;

        var palabras = palabrasFijas is not null
            ? Enumerable.Range(0, cantidad).Select(i => palabrasFijas[i % palabrasFijas.Count]).ToList()
            : selector.ElegirDistintas(categoria, Idioma, cantidad);

        return palabras
            .Select(palabra => CrearJuego(palabra, categoria))
            .ToList();
    }

    private Ahorcado CrearJuego(string palabra, string categoria)
    {
        var juego = new Ahorcado(palabra, Dificultad) { Categoria = categoria };
        if (Tiempo > 0)
            juego.EstablecerLimite(Tiempo);
        return juego;
    }
}
