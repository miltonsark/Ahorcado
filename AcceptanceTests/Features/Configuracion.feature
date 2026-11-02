#language: es
@HU-V02
Característica: Pantalla de configuración
    Como jugador
    quiero configurar la partida en una pantalla aparte
    para que todas mis opciones se respeten juntas

@CA-1
Escenario: La categoría guardada se usa al iniciar la partida
    Dado que navego a la configuración
    Cuando elijo la categoría "Animales"
    Y guardo la configuración
    Y elijo "Iniciar partida"
    Entonces veo la categoría "Animales"
