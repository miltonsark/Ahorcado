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

    public Ahorcado JuegoActual => _juegos[_turno];

    public void Adivinar(char letra)
    {
        var juego = JuegoActual;
        if (juego.Terminado) return;

        var errores = juego.Errores;
        juego.Adivinar(letra);
        if (juego.Terminado)
            _historial.Registrar(JugadorActual, juego.Puntaje);
        if (juego.Terminado || juego.Errores > errores)
            PasarAlSiguiente();
    }

    private void PasarAlSiguiente()
    {
        for (var i = 1; i <= _juegos.Count; i++)
        {
            var siguiente = (_turno + i) % _juegos.Count;
            if (!_juegos[siguiente].Terminado)
            {
                _turno = siguiente;
                return;
            }
        }
    }

    public bool Terminada => _juegos.All(juego => juego.Terminado);

    public void PedirPista()
    {
        var juego = JuegoActual;
        if (juego.Terminado) return;

        var errores = juego.Errores;
        juego.PedirPista();
        if (juego.Terminado)
            _historial.Registrar(JugadorActual, juego.Puntaje);
        if (juego.Terminado || juego.Errores > errores)
            PasarAlSiguiente();
    }
}