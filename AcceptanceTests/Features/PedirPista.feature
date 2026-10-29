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