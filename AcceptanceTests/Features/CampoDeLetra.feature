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

@CA-1
Escenario: Confirmo la letra con Enter
    Dado que ingreso a la partida con la palabra "GATO"
    Cuando ingreso la letra "A" y presiono Enter
    Entonces veo la palabra oculta "_ A _ _"

@CA-2
Escenario: Se ingresa una letra por vez y el campo se limpia
    Dado que ingreso a la partida con la palabra "GATO"
    Cuando ingreso la letra "A"
    Entonces el campo de letra está vacío
    Y el campo de letra acepta una sola letra