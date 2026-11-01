#language: es
@HU-P01
Característica: Ver puntaje
    Como jugador
    quiero ver mi puntaje al terminar la partida
    para saber qué tan bien jugué

@CA-1
Escenario: Gano sin errores y veo el puntaje máximo
    Dado que ingreso a la partida con la palabra "GATO"
    Cuando ingreso la letra "G"
    Y ingreso la letra "A"
    Y ingreso la letra "T"
    Y ingreso la letra "O"
    Entonces veo el puntaje 60

@CA-3
Escenario: En difícil gano sin errores y veo 80 puntos
    Dado que ingreso a la partida con la palabra "GATO"
    Cuando elijo la dificultad "Difícil"
    Y ingreso la letra "G"
    Y ingreso la letra "A"
    Y ingreso la letra "T"
    Y ingreso la letra "O"
    Entonces veo el puntaje 80