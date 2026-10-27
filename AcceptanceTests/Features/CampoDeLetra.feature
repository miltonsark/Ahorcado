#language: es
@HU-J01
Característica: Ingresar letras
    Como jugador
    quiero ingresar letras
    para ir adivinando la palabra

@CA-3
Escenario: Al ganar el campo de letra queda deshabilitado
    Dado que ingreso a la partida con la palabra "GATO"
    Cuando ingreso la letra "G"
    Y ingreso la letra "A"
    Y ingreso la letra "T"
    Y ingreso la letra "O"
    Entonces el campo de letra está deshabilitado