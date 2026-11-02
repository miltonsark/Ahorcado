namespace Ahorcado;

public class Traductor
{
    private static readonly Dictionary<string, string> Ingles = new()
    {
        ["Ganaste"] = "You won",
        ["Perdiste"] = "You lost",
        ["Ahorcado"] = "Hangman",
        ["Idioma"] = "Language",
        ["Usar configuración predeterminada"] = "Use default settings",
        ["Nombre"] = "Name",
        ["Jugador"] = "Player",
        ["Dificultad"] = "Difficulty",
        ["Fácil"] = "Easy",
        ["Difícil"] = "Hard",
        ["Categoría"] = "Category",
        ["Sin categoría"] = "No category",
        ["Animales"] = "Animals",
        ["Frutas"] = "Fruits",
        ["Colores"] = "Colors",
        ["Tiempo"] = "Time",
        ["Sin límite"] = "No limit",
        ["60 segundos"] = "60 seconds",
        ["30 segundos"] = "30 seconds",
        ["Tiempo restante"] = "Time left",
        ["Clásico"] = "Classic",
        ["Pizarra"] = "Chalkboard",
        ["Adivinar"] = "Guess",
        ["Pedir pista"] = "Get a hint",
        ["Errores"] = "Mistakes",
        ["Puntaje"] = "Score",
        ["Historial"] = "History",
        ["Iniciar partida"] = "Start game",
        ["Configuración"] = "Settings",
        ["Historial y jugadores"] = "History and players",
        ["Guardar"] = "Save",
        ["Jugadores"] = "Players",
        ["Inicio"] = "Home",
        ["Orden de turnos"] = "Turn order",
        ["Últimas partidas"] = "Latest games"
    };

    private readonly Idioma _idioma;

    public Traductor(Idioma idioma) => _idioma = idioma;

    public string Traducir(string texto)
    {
        if (_idioma == Idioma.Espanol) return texto;

        if (texto.StartsWith("La letra "))
            return $"The letter {texto[9]} was already used";

        return Ingles.GetValueOrDefault(texto, texto);
    }
}
