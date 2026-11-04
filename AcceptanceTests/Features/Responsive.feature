#language: es
@HU-V04
Característica: Usar el juego desde el celular
    Como jugador
    quiero jugar desde el celular
    para poder jugar en cualquier lado

@CA-1
Esquema del escenario: En un celular la pantalla no se desborda a lo ancho
    Dado que uso un celular
    Cuando abro la pantalla "<ruta>"
    Entonces la pantalla no se desborda a lo ancho

    Ejemplos:
        | ruta                |
        | /                   |
        | /configuracion      |
        | /partida?word=JIRAFA |
        | /historial          |