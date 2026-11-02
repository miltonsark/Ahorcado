#language: es
@HU-C06
Característica: Establecer cantidad de jugadores
    Como jugador
    quiero establecer la cantidad de jugadores
    para poder jugar en modo multijugador

@CA-2
Escenario: Al pasar a la siguiente partida le toca al siguiente jugador
    Dado que ingreso a la partida con la palabra "GATO"
    Cuando ingreso el nombre "Ana, Beto"
    Y ingreso la letra "G"
    Y ingreso la letra "A"
    Y ingreso la letra "T"
    Y ingreso la letra "O"
    Y paso a la siguiente partida
    Entonces veo el jugador "Beto"

@CA-3
Escenario: Cada partida se registra con el jugador del turno
    Dado que ingreso a la partida con la palabra "GATO"
    Cuando ingreso el nombre "Ana, Beto"
    Y ingreso la letra "G"
    Y ingreso la letra "A"
    Y ingreso la letra "T"
    Y ingreso la letra "O"
    Y paso a la siguiente partida
    Y ingreso la letra "Z"
    Y ingreso la letra "X"
    Y ingreso la letra "Q"
    Y ingreso la letra "W"
    Y ingreso la letra "Y"
    Y ingreso la letra "U"
    Entonces la entrada 1 del historial es "Beto: 0"
    Y la entrada 2 del historial es "Ana: 60"