#language: es
@HU-C03
Característica: Elegir dificultad
    Como jugador
    quiero elegir la dificultad
    para ajustar cuántas vidas tengo

@CA-1
Escenario: En difícil pierdo con 4 errores
    Dado que ingreso a la partida con la palabra "GATO"
    Cuando elijo la dificultad "Difícil"
    Y ingreso la letra "Z"
    Y ingreso la letra "X"
    Y ingreso la letra "Q"
    Y ingreso la letra "W"
    Entonces veo el resultado "Perdiste"