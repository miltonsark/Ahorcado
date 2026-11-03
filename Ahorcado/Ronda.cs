namespace Ahorcado;

public class Ronda
{
    private readonly IReadOnlyList<string> _jugadores;
    private readonly IReadOnlyList<Ahorcado> _juegos;
    private readonly Historial _historial;

    public Ronda(IReadOnlyList<string> jugadores, IReadOnlyList<Ahorcado> juegos, Historial historial)
    {
        _jugadores = jugadores;
        _juegos = juegos;
        _historial = historial;
    }

    public string JugadorActual => "";
}