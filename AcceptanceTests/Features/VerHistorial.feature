#language: es
@HU-P02
Característica: Ver historial de puntajes
    Como jugador
    quiero ver el historial de mis puntajes
    para comparar mi progreso entre partidas

@CA-1
Escenario: Al terminar la partida se agrega al historial
    Dado que ingreso a la partida con la palabra "GATO"
    Cuando ingreso el nombre "Carla"
    Y ingreso la letra "G"
    Y ingreso la letra "A"
    Y ingreso la letra "T"
    Y ingreso la letra "O"
    Entonces la entrada 1 del historial es "Carla: 60"
