#language: es
@HU-C02
Característica: Elegir idioma
    Como jugador
    quiero elegir el idioma del juego
    para jugar en el idioma que prefiero

@CA-1
Escenario: En inglés veo el resultado en inglés
    Dado que ingreso a la partida con la palabra "GATO"
    Cuando elijo el idioma "English"
    Y ingreso la letra "G"
    Y ingreso la letra "A"
    Y ingreso la letra "T"
    Y ingreso la letra "O"
    Entonces veo el resultado "You won"

@CA-2
Escenario: En inglés la palabra por defecto es HANGMAN
    Dado que navego a la partida
    Cuando elijo el idioma "English"
    Entonces veo la palabra oculta "_ _ _ _ _ _ _"
