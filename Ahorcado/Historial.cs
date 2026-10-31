namespace Ahorcado;

public class Historial
{
    private readonly List<string> _entradas = new();

    public void Registrar(string nombre, int puntaje) => _entradas.Insert(0, $"{nombre}: {puntaje}");

    public IReadOnlyList<string> Entradas => _entradas;
}
