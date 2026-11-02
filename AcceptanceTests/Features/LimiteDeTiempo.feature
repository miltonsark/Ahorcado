#language: es
@HU-C05
Característica: Establecer tiempo
    Como jugador
    quiero establecer un límite de tiempo
    para darle más desafío a la partida

@CA-1
Escenario: Elijo 30 segundos y veo la cuenta regresiva
    Dado que ingreso a la partida con la palabra "GATO"
    Cuando elijo el límite de tiempo "30 segundos"
    Entonces veo el tiempo restante entre 25 y 30