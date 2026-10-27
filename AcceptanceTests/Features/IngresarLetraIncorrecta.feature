# language: es
@HU-J02
Característica: Ingresar una letra que no está en la palabra

@CA-2
Escenario: Ingreso una letra que no está en la palabra
    Dado que ingreso a la partida con la palabra "GATO"
    Cuando ingreso la letra "Z"
    Entonces veo la palabra oculta "_ _ _ _"
    Y veo 1 errores

@CA-3
Escenario: Ingreso dos veces la misma letra que no está en la palabra
    Dado que ingreso a la partida con la palabra "GATO"
    Cuando ingreso la letra "Z"
    Y ingreso la letra "Z"
    Entonces veo 1 errores