#language: es
@HU-J02
Característica: Ver las letras usadas
    Como jugador
    quiero ver las letras que ya probé
    para no repetirlas y saber cuáles fallaron

@CA-4
Escenario: Veo las letras que ya probé en el orden en que las ingresé
    Dado que ingreso a la partida con la palabra "GATO"
    Cuando ingreso la letra "A"
    Y ingreso la letra "Z"
    Y ingreso la letra "T"
    Entonces veo las letras usadas "A, Z, T"

@CA-4
Escenario: Las letras que no están en la palabra se marcan como erradas
    Dado que ingreso a la partida con la palabra "GATO"
    Cuando ingreso la letra "A"
    Y ingreso la letra "Z"
    Entonces la letra usada "Z" está marcada como errada

@CA-4
Escenario: En multijugador cada jugador ve sus propias letras
    Dado que navego a la configuración
    Cuando ingreso el jugador 1 "Ana"
    Y ingreso el jugador 2 "Beto"
    Y guardo la configuración
    Y inicio la partida con las palabras "GATO, PERRO"
    Y ingreso la letra "A"
    Y ingreso la letra "Z"
    Y ingreso la letra "E"
    Entonces veo el jugador "Beto"
    Y veo las letras usadas "E"