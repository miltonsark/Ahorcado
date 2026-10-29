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