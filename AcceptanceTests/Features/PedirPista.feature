#language: es
@HU-J03
Característica: Pedir pista
    Como jugador
    quiero poder pedir una pista
    para ayudarme cuando estoy trabado

@CA-1
Escenario: Pido una pista y se revela una letra
    Dado que ingreso a la partida con la palabra "GATO"
    Cuando pido una pista
    Entonces veo la palabra oculta "G _ _ _"

@CA-2
Escenario: Pedir una pista descuenta una vida
    Dado que ingreso a la partida con la palabra "GATO"
    Cuando pido una pista
    Entonces veo 1 errores

@CA-4
Escenario: Si la pista completa la palabra, gano
    Dado que ingreso a la partida con la palabra "GATO"
    Cuando ingreso la letra "G"
    Y ingreso la letra "A"
    Y ingreso la letra "T"
    Y pido una pista
    Entonces veo el resultado "Ganaste"

@CA-5
Escenario: Después de pedir una pista no puedo pedir otra
    Dado que ingreso a la partida con la palabra "GATO"
    Cuando pido una pista
    Entonces el botón de pista está deshabilitado

@CA-3
Escenario: Con la partida ganada no puedo pedir pista
    Dado que ingreso a la partida con la palabra "GATO"
    Cuando ingreso la letra "G"
    Y ingreso la letra "A"
    Y ingreso la letra "T"
    Y ingreso la letra "O"
    Entonces el botón de pista está deshabilitado

@CA-6
Escenario: Con una sola vida no puedo pedir pista
    Dado que ingreso a la partida con la palabra "GATO"
    Cuando ingreso la letra "Z"
    Y ingreso la letra "X"
    Y ingreso la letra "Q"
    Y ingreso la letra "W"
    Y ingreso la letra "Y"
    Entonces el botón de pista está deshabilitado
