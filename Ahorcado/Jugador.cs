namespace Ahorcado;

public class Jugador
{
    private readonly string _nombre;

    public Jugador(string nombre) => _nombre = nombre;

    public string Nombre => _nombre;
}