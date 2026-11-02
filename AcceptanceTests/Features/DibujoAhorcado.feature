#language: es
@HU-C07
Característica: Dibujo del ahorcado
    Como jugador
    quiero ver el dibujo del ahorcado
    para saber cuánto me falta para perder

@CA-1
Escenario: Con 2 errores veo 2 partes del muñeco
    Dado que ingreso a la partida con la palabra "GATO"
    Cuando ingreso la letra "Z"
    Y ingreso la letra "X"
    Entonces veo 2 partes del dibujo

@CA-2
Escenario: Elijo el skin Pizarra
    Dado que navego a la configuración
    Cuando elijo el skin "Pizarra"
    Y guardo la configuración
    Y inicio la partida con la palabra "GATO"
    Entonces el dibujo usa el skin "pizarra"

@CA-2
Escenario: Si no elijo skin, el dibujo es Clásico
    Dado que ingreso a la partida con la palabra "GATO"
    Entonces el dibujo usa el skin "clasico"
