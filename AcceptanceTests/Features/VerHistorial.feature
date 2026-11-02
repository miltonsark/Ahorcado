#language: es
@HU-P02
Característica: Ver historial de puntajes
    Como jugador
    quiero ver el historial de mis puntajes
    para comparar mi progreso entre partidas

@CA-1
Escenario: Al terminar la partida se agrega al historial
    Dado que navego a la configuración
    Cuando ingreso el jugador 1 "Carla"
    Y guardo la configuración
    Y inicio la partida con la palabra "GATO"
    Y ingreso la letra "G"
    Y ingreso la letra "A"
    Y ingreso la letra "T"
    Y ingreso la letra "O"
    Y elijo "Inicio"
    Y elijo "Historial y jugadores"
    Entonces la entrada 1 del historial es "Carla: 60"

@CA-2
Escenario: El historial muestra primero la partida más reciente
    Dado que navego a la configuración
    Cuando ingreso el jugador 1 "Carla"
    Y guardo la configuración
    Y inicio la partida con la palabra "GATO"
    Y ingreso la letra "G"
    Y ingreso la letra "A"
    Y ingreso la letra "T"
    Y ingreso la letra "O"
    Y paso a la siguiente partida
    Y ingreso la letra "Z"
    Y ingreso la letra "X"
    Y ingreso la letra "Q"
    Y ingreso la letra "W"
    Y ingreso la letra "Y"
    Y ingreso la letra "U"
    Y elijo "Inicio"
    Y elijo "Historial y jugadores"
    Entonces la entrada 1 del historial es "Carla: 0"
    Y la entrada 2 del historial es "Carla: 60"

@CA-3
Escenario: Al recargar la página el historial empieza vacío
    Dado que ingreso a la partida con la palabra "GATO"
    Cuando ingreso la letra "G"
    Y ingreso la letra "A"
    Y ingreso la letra "T"
    Y ingreso la letra "O"
    Y elijo "Inicio"
    Y elijo "Historial y jugadores"
    Y recargo la página
    Entonces el historial está vacío
