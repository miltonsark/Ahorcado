namespace Ahorcado;

public class Turnos
{
    private readonly List<string> _nombres;

    public Turnos(string nombres) =>
        _nombres = nombres.Split(',').Select(nombre => new Jugador(nombre.Trim()).Nombre).Take(4).ToList();

    private int _turno;

    public string Actual => _nombres[_turno];

    public IReadOnlyList<string> Jugadores => [];

    public void Pasar() => _turno = (_turno + 1) % _nombres.Count;

}

