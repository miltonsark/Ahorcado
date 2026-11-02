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

@CA-2
Escenario: La dificultad guardada se usa al iniciar la partida
    Dado que navego a la configuración
    Cuando elijo la dificultad "Difícil"
    Y guardo la configuración
    Y elijo "Iniciar partida"
    Y ingreso la letra "Z"
    Y ingreso la letra "X"
    Y ingreso la letra "Q"
    Y ingreso la letra "W"
    Entonces veo el resultado "Perdiste"

@CA-3
Escenario: El idioma guardado se usa al iniciar la partida
    Dado que navego a la configuración
    Cuando elijo el idioma "English"
    Y guardo la configuración
    Y elijo "Iniciar partida"
    Entonces veo la palabra oculta "_ _ _ _ _ _ _"

@CA-4
Escenario: El tiempo guardado se usa al iniciar la partida
    Dado que navego a la configuración
    Cuando elijo el límite de tiempo "30 segundos"
    Y guardo la configuración
    Y elijo "Iniciar partida"
    Entonces veo el tiempo restante entre 25 y 30
