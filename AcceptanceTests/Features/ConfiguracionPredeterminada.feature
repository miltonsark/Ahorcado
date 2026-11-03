#language: es
@HU-C01
Característica: Elegir configuración predeterminada
    Como jugador
    quiero una configuración predeterminada
    para empezar a jugar rápido sin configurar nada

@CA-2
Escenario: Elijo la configuración predeterminada y arranca con una categoría al azar
    Dado que navego a la configuración
    Cuando elijo la dificultad "Difícil"
    Y elijo usar la configuración predeterminada
    Y guardo la configuración
    Y elijo "Iniciar partida"
    Entonces veo una categoría entre "Animales, Frutas, Colores"
