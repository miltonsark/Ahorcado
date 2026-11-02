namespace Ahorcado;

public class Turnos
{
    private readonly List<string> _nombres;

    public Turnos(string nombres) =>
        _nombres = nombres.Split(',').Select(nombre => nombre.Trim()).ToList();

    private int _turno;

    public string Actual => _nombres[_turno];

    public void Pasar() => _turno = (_turno + 1) % _nombres.Count;

}

