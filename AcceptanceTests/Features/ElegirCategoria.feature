#language: es
@HU-C04
Característica: Elegir categoría
    Como jugador
    quiero elegir una categoría de palabras
    para jugar con temas que me interesan

@CA-1
Escenario: Al elegir Colores juego con un color
    Dado que navego a la configuración
    Cuando elijo la categoría "Colores"
    Y guardo la configuración
    Y elijo "Iniciar partida"
    Y ingreso la letra "F"
    Y ingreso la letra "H"
    Y ingreso la letra "I"
    Y ingreso la letra "K"
    Y ingreso la letra "M"
    Y ingreso la letra "P"
    Entonces la palabra revelada es una de "ROJO, AZUL, VERDE, NEGRO, BLANCO"

@CA-2
Escenario: Veo la categoría que elegí
    Dado que navego a la configuración
    Cuando elijo la categoría "Frutas"
    Y guardo la configuración
    Y elijo "Iniciar partida"
    Entonces veo la categoría "Frutas"

@CA-3
Escenario: Con categoría Aleatoria veo la categoría que salió
    Dado que navego a la configuración
    Cuando elijo la categoría "Aleatoria"
    Y guardo la configuración
    Y elijo "Iniciar partida"
    Entonces veo una categoría entre "Animales, Frutas, Colores"
