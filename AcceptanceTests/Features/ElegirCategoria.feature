#language: es
@HU-C04
Característica: Elegir categoría
    Como jugador
    quiero elegir una categoría de palabras
    para jugar con temas que me interesan

@CA-1
Escenario: Al elegir Colores juego con un color
    Dado que ingreso a la partida con la palabra "GATO"
    Cuando elijo la categoría "Colores"
    Y ingreso la letra "F"
    Y ingreso la letra "H"
    Y ingreso la letra "I"
    Y ingreso la letra "K"
    Y ingreso la letra "M"
    Y ingreso la letra "P"
    Entonces la palabra revelada es una de "ROJO, AZUL, VERDE, NEGRO, BLANCO"

@CA-2
Escenario: Veo la categoría que elegí
    Dado que ingreso a la partida con la palabra "GATO"
    Cuando elijo la categoría "Frutas"
    Entonces veo la categoría "Frutas"