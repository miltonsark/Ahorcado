#language: es
@HU-C01
Característica: Elegir configuración predeterminada
    Como jugador
    quiero una configuración predeterminada
    para empezar a jugar rápido sin configurar nada

@CA-2
Escenario: Elijo la configuración predeterminada y arranca una partida nueva
    Dado que ingreso a la partida con la palabra "GATO"
    Cuando elijo usar la configuración predeterminada
    Entonces veo la palabra oculta "_ _ _ _ _ _ _ _"