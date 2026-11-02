#language: es
@HU-C03
Característica: Elegir dificultad
    Como jugador
    quiero elegir la dificultad
    para ajustar cuántas vidas tengo

@CA-1
Escenario: En difícil pierdo con 4 errores
    Dado que navego a la configuración
    Cuando elijo la dificultad "Difícil"
    Y guardo la configuración
    Y inicio la partida con la palabra "GATO"
    Y ingreso la letra "Z"
    Y ingreso la letra "X"
    Y ingreso la letra "Q"
    Y ingreso la letra "W"
    Entonces veo el resultado "Perdiste"

@CA-2
Escenario: Si no elijo dificultad, juego en Normal
    Dado que navego a la configuración
    Entonces la dificultad elegida es "Normal"
