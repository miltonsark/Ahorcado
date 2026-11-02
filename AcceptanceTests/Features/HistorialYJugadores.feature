#language: es
@HU-V03
Característica: Historial y jugadores
    Como jugador
    quiero ver las partidas y el orden de turnos en una pantalla aparte
    para seguir quién va ganando

@CA-1
Escenario: Desde la partida vuelvo al inicio
    Dado que navego a la partida
    Cuando elijo "Inicio"
    Entonces veo la opción "Iniciar partida"

@CA-2
Escenario: El historial muestra las partidas jugadas
    Dado que navego a la configuración
    Cuando ingreso el jugador 1 "Ana"
    Y guardo la configuración
    Y inicio la partida con la palabra "GATO"
    Y ingreso la letra "G"
    Y ingreso la letra "A"
    Y ingreso la letra "T"
    Y ingreso la letra "O"
    Y elijo "Inicio"
    Y elijo "Historial y jugadores"
    Entonces la entrada 1 del historial es "Ana: 60"

@CA-3
Escenario: Veo el orden de los turnos
    Dado que navego a la configuración
    Cuando ingreso el jugador 1 "Ana"
    Y ingreso el jugador 2 "Carla"
    Y guardo la configuración
    Y elijo "Historial y jugadores"
    Entonces el jugador 2 de la lista es "Carla"
