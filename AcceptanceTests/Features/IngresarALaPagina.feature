#language: es
@HU-R01
Característica: Ingresar a la página
    Como jugador
    quiero ingresar a la página del juego
    para poder empezar a jugar

@CA-1
Escenario: El jugador ingresa a la página
    Dado que navego a la página principal
    Entonces veo el título "Ahorcado"

@CA-2
Escenario: Sin palabra en la URL arranca con la palabra por defecto
    Dado que navego a la página principal
    Entonces veo la palabra oculta "_ _ _ _ _ _ _ _"
