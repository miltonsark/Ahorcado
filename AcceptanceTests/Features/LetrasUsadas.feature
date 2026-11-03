#language: es
@HU-J02
Característica: Ver las letras usadas
    Como jugador
    quiero ver las letras que ya probé
    para no repetirlas y saber cuáles fallaron

@CA-4
Escenario: Veo las letras que ya probé en el orden en que las ingresé
    Dado que ingreso a la partida con la palabra "GATO"
    Cuando ingreso la letra "A"
    Y ingreso la letra "Z"
    Y ingreso la letra "T"
    Entonces veo las letras usadas "A, Z, T"