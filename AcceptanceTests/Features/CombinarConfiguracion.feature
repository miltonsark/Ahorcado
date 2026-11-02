#language: es
@HU-C08
Característica: Combinar configuración
    Como jugador
    quiero que las opciones que elijo se combinen y se mantengan
    para no tener que configurar todo de nuevo en cada partida

@CA-2
Escenario: Siguiente partida arranca con la configuración elegida
    Dado que navego a la configuración
    Cuando elijo la dificultad "Difícil"
    Y guardo la configuración
    Y elijo "Iniciar partida"
    Y paso a la siguiente partida
    Y ingreso la letra "Z"
    Y ingreso la letra "X"
    Y ingreso la letra "Q"
    Y ingreso la letra "W"
    Entonces veo el resultado "Perdiste"
