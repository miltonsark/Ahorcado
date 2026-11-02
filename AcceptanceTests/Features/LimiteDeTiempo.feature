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

@CA-2
Escenario: Si se acaba el tiempo pierdo y veo la palabra
    Dado que ingreso a la partida con la palabra "GATO" y 3 segundos de límite
    Cuando espero 5 segundos
    Entonces veo el resultado "Perdiste"
    Y veo la palabra oculta "G A T O"