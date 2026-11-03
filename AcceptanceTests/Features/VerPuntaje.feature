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
    Dado que navego a la configuración
    Cuando elijo la dificultad "Difícil"
    Y guardo la configuración
    Y inicio la partida con la palabra "GATO"
    Y ingreso la letra "G"
    Y ingreso la letra "A"
    Y ingreso la letra "T"
    Y ingreso la letra "O"
    Entonces veo el puntaje 80

@CA-4
Escenario: Si se acaba el tiempo el puntaje es 0
    Dado que ingreso a la partida con la palabra "GATO" y 3 segundos de límite
    Cuando espero 5 segundos
    Entonces veo el resultado "Perdiste"
    Y veo el puntaje 0
