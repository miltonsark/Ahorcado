#language: es
@HU-J04
Característica: Terminar juego
    Como jugador
    quiero que el juego termine cuando gano o pierdo
    para saber el resultado de la partida

@CA-1
Escenario: Completo todas las letras de la palabra y gano
    Dado que ingreso a la partida con la palabra "GATO"
    Cuando ingreso la letra "G"
    Y ingreso la letra "A"
    Y ingreso la letra "T"
    Y ingreso la letra "O"
    Entonces veo el resultado "Ganaste"

@CA-2
Escenario: Fallo 6 veces y pierdo
    Dado que ingreso a la partida con la palabra "GATO"
    Cuando ingreso la letra "Z"
    Y ingreso la letra "X"
    Y ingreso la letra "Q"
    Y ingreso la letra "W"
    Y ingreso la letra "Y"
    Y ingreso la letra "U"
    Entonces veo el resultado "Perdiste"

@CA-2
Escenario: Al perder veo la palabra completa
    Dado que ingreso a la partida con la palabra "GATO"
    Cuando ingreso la letra "Z"
    Y ingreso la letra "X"
    Y ingreso la letra "Q"
    Y ingreso la letra "W"
    Y ingreso la letra "Y"
    Y ingreso la letra "U"
    Entonces veo la palabra oculta "G A T O"

@CA-3
Escenario: Después de perder no se aceptan más letras
    Dado que ingreso a la partida con la palabra "GATO"
    Cuando ingreso la letra "Z"
    Y ingreso la letra "X"
    Y ingreso la letra "Q"
    Y ingreso la letra "W"
    Y ingreso la letra "Y"
    Y ingreso la letra "U"
    Y ingreso la letra "K"
    Entonces veo 6 errores
