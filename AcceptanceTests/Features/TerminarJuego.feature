#language: es
@HU-J04
Característica: Terminar juego
    Como jugador
    quiero que el juego termine cuando gano o pierdo
    para saber el resultado de la partida

@CA-1
Escenario: Completo todas las letras de la palabra y gano
    Dado que ingreso a la partida con la palabra "GATO"
    Cuando ingreso la letra "G"
    Y ingreso la letra "A"
    Y ingreso la letra "T"
    Y ingreso la letra "O"
    Entonces veo el resultado "Ganaste"
