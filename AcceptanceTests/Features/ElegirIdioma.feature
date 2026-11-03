#language: es
@HU-C02
Característica: Elegir idioma
    Como jugador
    quiero elegir el idioma del juego
    para jugar en el idioma que prefiero

@CA-1
Escenario: En inglés veo el resultado en inglés
    Dado que navego a la configuración
    Cuando elijo el idioma "English"
    Y guardo la configuración
    Y inicio la partida con la palabra "GATO"
    Y ingreso la letra "G"
    Y ingreso la letra "A"
    Y ingreso la letra "T"
    Y ingreso la letra "O"
    Entonces veo el resultado "You won"

@CA-2
Escenario: En inglés arranca con una categoría al azar en inglés
    Dado que navego a la configuración
    Cuando elijo el idioma "English"
    Y guardo la configuración
    Y elijo "Start game"
    Entonces veo una categoría entre "Animals, Fruits, Colors"
