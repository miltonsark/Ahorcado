namespace Ahorcado;

public class Turnos
{
    private readonly List<string> _nombres;

    public Turnos(string nombres) =>
        _nombres = nombres.Split(',').Select(nombre => nombre.Trim()).ToList();

    public string Actual => _nombres[0];
}