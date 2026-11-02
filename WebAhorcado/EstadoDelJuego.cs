namespace WebAhorcado;

public class EstadoDelJuego
{
    public Ahorcado.Configuracion Configuracion { get; set; } = new();
    public Ahorcado.Historial Historial { get; } = new();
}
