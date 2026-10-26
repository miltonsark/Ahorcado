#language: es
@HU-J01
Característica: Ingresar una Letra que esté en la palabra

A short summary of the feature

@CA-1
Escenario: Ingreso una letra que está en la palabra
	Dado que ingreso a la partida con la palabra 'GATO'
	Cuando ingreso la letra 'A'
	Entonces veo la palabra oculta "_ A _ _"

@CA-2
Escenario: Ingreso una letra en minúscula que está en la palabra
	Dado que ingreso a la partida con la palabra 'GATO'
	Cuando ingreso la letra 'a'
	Entonces veo la palabra oculta "_ A _ _"
