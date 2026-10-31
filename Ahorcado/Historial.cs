namespace Ahorcado;

public class Historial
{
    private readonly List<string> _entradas = new();

    public void Registrar(string nombre, int puntaje) => _entradas.Add($"{nombre}: {puntaje}");

    public IReadOnlyList<string> Entradas => _entradas;
}
