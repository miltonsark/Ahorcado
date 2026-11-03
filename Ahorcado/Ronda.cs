namespace Ahorcado;

public class Ronda
{
    private readonly IReadOnlyList<string> _jugadores;
    private readonly IReadOnlyList<Ahorcado> _juegos;
    private readonly Historial _historial;
    private int _turno;   

    public Ronda(IReadOnlyList<string> jugadores, IReadOnlyList<Ahorcado> juegos, Historial historial)
    {
        _jugadores = jugadores;
        _juegos = juegos;
        _historial = historial;
    }

    public string JugadorActual => _jugadores[_turno];

    public void Adivinar(char letra) { }
}