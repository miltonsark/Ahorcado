#language: es
@HU-C06
Característica: Establecer cantidad de jugadores
    Como jugador
    quiero establecer la cantidad de jugadores
    para poder jugar en modo multijugador

@CA-2
Escenario: Si el jugador falla una letra, le toca al siguiente
    Dado que navego a la configuración
    Cuando ingreso el jugador 1 "Ana"
    Y ingreso el jugador 2 "Beto"
    Y guardo la configuración
    Y inicio la partida con las palabras "GATO, PERRO"
    Y ingreso la letra "Z"
    Entonces veo el jugador "Beto"

@CA-2
Escenario: Si el jugador acierta, sigue jugando
    Dado que navego a la configuración
    Cuando ingreso el jugador 1 "Ana"
    Y ingreso el jugador 2 "Beto"
    Y guardo la configuración
    Y inicio la partida con las palabras "GATO, PERRO"
    Y ingreso la letra "G"
    Entonces veo el jugador "Ana"

@CA-4
Escenario: Cada jugador adivina su propia palabra
    Dado que navego a la configuración
    Cuando ingreso el jugador 1 "Ana"
    Y ingreso el jugador 2 "Beto"
    Y guardo la configuración
    Y inicio la partida con las palabras "GATO, PERRO"
    Y ingreso la letra "Z"
    Entonces veo la palabra oculta "_ _ _ _ _"

@CA-3
Escenario: Cada palabra se registra con el jugador que la jugó
    Dado que navego a la configuración
    Cuando ingreso el jugador 1 "Ana"
    Y ingreso el jugador 2 "Beto"
    Y guardo la configuración
    Y inicio la partida con las palabras "GATO, PERRO"
    Y ingreso la letra "G"
    Y ingreso la letra "A"
    Y ingreso la letra "T"
    Y ingreso la letra "O"
    Y ingreso la letra "Z"
    Y ingreso la letra "X"
    Y ingreso la letra "Q"
    Y ingreso la letra "W"
    Y ingreso la letra "Y"
    Y ingreso la letra "U"
    Y elijo "Inicio"
    Y elijo "Historial y jugadores"
    Entonces la entrada 1 del historial es "Beto: 0"
    Y la entrada 2 del historial es "Ana: 60"

@CA-5
Escenario: Siguiente partida arranca una ronda nueva con el primer jugador
    Dado que navego a la configuración
    Cuando ingreso el jugador 1 "Ana"
    Y ingreso el jugador 2 "Beto"
    Y guardo la configuración
    Y inicio la partida con las palabras "GATO, PERRO"
    Y ingreso la letra "Z"
    Y paso a la siguiente partida
    Entonces veo el jugador "Ana"
