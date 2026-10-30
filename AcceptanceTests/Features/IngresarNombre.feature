#language: es
@HU-R02
Característica: Ingresar nombre
    Como jugador
    quiero ingresar mi nombre
    para identificarme en el historial de puntajes

@CA-1
Escenario: Ingreso mi nombre y lo veo en pantalla
    Dado que ingreso a la partida con la palabra "GATO"
    Cuando ingreso el nombre "Nico"
    Entonces veo el jugador "Nico"