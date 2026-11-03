#language: es
@HU-V01
Característica: Pantalla de inicio
    Como jugador
    quiero una pantalla de inicio
    para elegir qué hacer antes de jugar

@CA-1
Escenario: El inicio muestra las tres opciones
    Dado que navego a la página principal
    Entonces veo la opción "Iniciar partida"
    Y veo la opción "Configuración"
    Y veo la opción "Historial y jugadores"

@CA-2
Escenario: Iniciar partida abre una partida con la configuración predeterminada
    Dado que navego a la página principal
    Cuando elijo "Iniciar partida"
    Entonces veo una categoría entre "Animales, Frutas, Colores"
