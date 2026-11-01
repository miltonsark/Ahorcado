using Juego = Ahorcado.Ahorcado;
using Jugador = Ahorcado.Jugador;
using Dificultad = Ahorcado.Dificultad;
using Historial = Ahorcado.Historial;
using Xunit;
using SelectorDePalabras = Ahorcado.SelectorDePalabras;

namespace Tests;

public class AhorcadoTests
{
    [Fact]
    public void PalabraEnmascarada_DeGatoMuestraUnGuionPorLetra()
    {
        var juego = new Juego("GATO");

        Assert.Equal("_ _ _ _", juego.PalabraEnmascarada());
    }

    [Fact]
    public void PalabraEnmascarada_DePerro_MuestraUnGuionPorLetra()
    {
        var juego = new Juego("PERRO");

        Assert.Equal("_ _ _ _ _", juego.PalabraEnmascarada());
    }

    [Fact]
    public void Adivinar_A_en_GATO_revela_la_letra()
    {
        var juego = new Juego("GATO");

        juego.Adivinar('A');

        Assert.Equal("_ A _ _", juego.PalabraEnmascarada());
    }

    [Fact]
    public void Adivinar_a_minuscula_en_GATO_revela_la_A()
    {
        var juego = new Juego("GATO");

        juego.Adivinar('a');

        Assert.Equal("_ A _ _", juego.PalabraEnmascarada());
    }

    [Fact]
    public void Adivinar_t_minuscula_en_GATO_revela_la_T()
    {
        var juego = new Juego("GATO");

        juego.Adivinar('t');

        Assert.Equal("_ _ T _", juego.PalabraEnmascarada());
    }

    [Fact]
    public void Adivinar_Z_en_GATO_suma_un_error()
    {
        var juego = new Juego("GATO");

        juego.Adivinar('Z');

        Assert.Equal(1, juego.Errores);
    }

    [Fact]
    public void Adivinar_dos_letras_que_no_estan_en_GATO_suma_dos_errores()
    {
        var juego = new Juego("GATO");

        juego.Adivinar('Z');
        juego.Adivinar('X');

        Assert.Equal(2, juego.Errores);
    }

    [Fact]
    public void Adivinar_Z_dos_veces_en_GATO_suma_un_solo_error()
    {
        var juego = new Juego("GATO");

        juego.Adivinar('Z');
        juego.Adivinar('Z');

        Assert.Equal(1, juego.Errores);
    }

    [Fact]
    public void Adivinar_Z_X_Z_en_GATO_suma_dos_errores()
    {
        var juego = new Juego("GATO");

        juego.Adivinar('Z');
        juego.Adivinar('X');
        juego.Adivinar('Z');

        Assert.Equal(2, juego.Errores);
    }

    [Fact]
    public void Adivinar_Z_dos_veces_en_GATO_avisa_que_ya_fue_usada()
    {
        var juego = new Juego("GATO");

        juego.Adivinar('Z');
        juego.Adivinar('Z');

        Assert.Equal("La letra Z ya fue usada", juego.Mensaje);
    }

    [Fact]
    public void Adivinar_A_dos_veces_en_GATO_avisa_que_ya_fue_usada()
    {
        var juego = new Juego("GATO");

        juego.Adivinar('A');
        juego.Adivinar('A');

        Assert.Equal("La letra A ya fue usada", juego.Mensaje);
    }

    [Fact]
    public void Adivinar_todas_las_letras_de_GATO_gana()
    {
        var juego = new Juego("GATO");

        juego.Adivinar('G');
        juego.Adivinar('A');
        juego.Adivinar('T');
        juego.Adivinar('O');

        Assert.Equal("Ganaste", juego.Resultado);
    }

    [Fact]
    public void Adivinar_solo_G_y_A_de_GATO_todavia_no_gana()
    {
        var juego = new Juego("GATO");

        juego.Adivinar('G');
        juego.Adivinar('A');

        Assert.Equal("", juego.Resultado);
    }

    [Fact]
    public void Fallar_6_letras_en_GATO_pierde()
    {
        var juego = new Juego("GATO");

        foreach (var letra in "ZXQWYU")
            juego.Adivinar(letra);

        Assert.Equal("Perdiste", juego.Resultado);
    }

    [Fact]
    public void Fallar_5_letras_en_GATO_todavia_no_pierde()
    {
        var juego = new Juego("GATO");

        foreach (var letra in "ZXQWY")
            juego.Adivinar(letra);

        Assert.Equal("", juego.Resultado);
    }

    [Fact]
    public void Perder_con_GATO_revela_la_palabra()
    {
        var juego = new Juego("GATO");

        foreach (var letra in "ZXQWYU")
            juego.Adivinar(letra);

        Assert.Equal("G A T O", juego.PalabraEnmascarada());
    }

    [Fact]
    public void Perder_con_PERRO_revela_la_palabra()
    {
        var juego = new Juego("PERRO");

        foreach (var letra in "ZXQWYU")
            juego.Adivinar(letra);

        Assert.Equal("P E R R O", juego.PalabraEnmascarada());
    }

    [Fact]
    public void Despues_de_perder_no_se_aceptan_mas_letras()
    {
        var juego = new Juego("GATO");

        foreach (var letra in "ZXQWYU")
            juego.Adivinar(letra);
        juego.Adivinar('K');

        Assert.Equal(6, juego.Errores);
    }

    [Fact]
    public void Despues_de_ganar_no_se_aceptan_mas_letras()
    {
        var juego = new Juego("GATO");

        foreach (var letra in "GATO")
            juego.Adivinar(letra);
        juego.Adivinar('Z');

        Assert.Equal(0, juego.Errores);
    }

    [Fact]
    public void Sin_palabra_usa_la_palabra_por_defecto()
    {
        var juego = new Juego("");

        Assert.Equal("_ _ _ _ _ _ _ _", juego.PalabraEnmascarada());
    }

    [Fact]
    public void Sin_palabra_se_puede_adivinar_la_palabra_por_defecto()
    {
        var juego = new Juego("");

        juego.Adivinar('A');

        Assert.Equal("A _ _ _ _ A _ _", juego.PalabraEnmascarada());
    }

    [Fact]
    public void Ganar_GATO_sin_errores_da_60_puntos()
    {
        var juego = new Juego("GATO");

        foreach (var letra in "GATO")
            juego.Adivinar(letra);

        Assert.Equal(60, juego.Puntaje);
    }

    [Fact]
    public void Ganar_GATO_con_2_errores_da_40_puntos()
    {
        var juego = new Juego("GATO");

        foreach (var letra in "ZXGATO")
            juego.Adivinar(letra);

        Assert.Equal(40, juego.Puntaje);
    }

    [Fact]
    public void Mientras_la_partida_sigue_el_puntaje_es_0()
    {
        var juego = new Juego("GATO");

        juego.Adivinar('G');

        Assert.Equal(0, juego.Puntaje);
    }

    [Fact]
    public void Pedir_pista_en_GATO_revela_la_G()
    {
        var juego = new Juego("GATO");

        juego.PedirPista();

        Assert.Equal("G _ _ _", juego.PalabraEnmascarada());
    }

    [Fact]
    public void Pedir_pista_despues_de_adivinar_la_G_revela_la_A()
    {
        var juego = new Juego("GATO");

        juego.Adivinar('G');
        juego.PedirPista();

        Assert.Equal("G A _ _", juego.PalabraEnmascarada());
    }

    [Fact]
    public void Pedir_pista_suma_un_error()
    {
        var juego = new Juego("GATO");

        juego.PedirPista();

        Assert.Equal(1, juego.Errores);
    }

    [Fact]
    public void Pedir_pista_con_un_error_previo_deja_dos_errores()
    {
        var juego = new Juego("GATO");

        juego.Adivinar('Z');
        juego.PedirPista();

        Assert.Equal(2, juego.Errores);
    }

    [Fact]
    public void Despues_de_pedir_pista_no_se_puede_pedir_otra()
    {
        var juego = new Juego("GATO");

        juego.PedirPista();

        Assert.False(juego.PuedePedirPista);
    }

    [Fact]
    public void Con_un_error_y_sin_pista_usada_se_puede_pedir_pista()
    {
        var juego = new Juego("GATO");

        juego.Adivinar('Z');

        Assert.True(juego.PuedePedirPista);
    }

    [Fact]
    public void Con_la_partida_ganada_no_se_puede_pedir_pista()
    {
        var juego = new Juego("GATO");

        foreach (var letra in "GATO")
            juego.Adivinar(letra);

        Assert.False(juego.PuedePedirPista);
    }

    [Fact]
    public void Con_una_sola_vida_no_se_puede_pedir_pista()
    {
        var juego = new Juego("GATO");

        foreach (var letra in "ZXQWY")
            juego.Adivinar(letra);

        Assert.False(juego.PuedePedirPista);
    }

    [Fact]
    public void Pedir_pista_dos_veces_cuenta_un_solo_error()
    {
        var juego = new Juego("GATO");

        juego.PedirPista();
        juego.PedirPista();

        Assert.Equal(1, juego.Errores);
    }

    [Fact]
    public void Jugador_Nico_se_llama_Nico()
    {
        var jugador = new Jugador("Nico");

        Assert.Equal("Nico", jugador.Nombre);
    }

    [Fact]
    public void Jugador_Ana_se_llama_Ana()
    {
        var jugador = new Jugador("Ana");

        Assert.Equal("Ana", jugador.Nombre);
    }

    [Fact]
    public void Jugador_sin_nombre_se_llama_Anonimo()
    {
        var jugador = new Jugador("");

        Assert.Equal("Anónimo", jugador.Nombre);
    }

    [Fact]
    public void En_dificil_se_pierde_con_4_errores()
    {
        var juego = new Juego("GATO", Dificultad.Dificil);

        foreach (var letra in "ZXQW")
            juego.Adivinar(letra);

        Assert.Equal("Perdiste", juego.Resultado);
    }

    [Fact]
    public void En_facil_6_errores_todavia_no_pierde()
    {
        var juego = new Juego("GATO", Dificultad.Facil);

        foreach (var letra in "ZXQWYU")
            juego.Adivinar(letra);

        Assert.Equal("", juego.Resultado);
    }

    [Fact]
    public void En_normal_se_pierde_con_6_errores()
    {
        var juego = new Juego("GATO", Dificultad.Normal);

        foreach (var letra in "ZXQWYU")
            juego.Adivinar(letra);

        Assert.Equal("Perdiste", juego.Resultado);
    }

    [Fact]
    public void Registrar_a_Carla_con_60_la_agrega_al_historial()
    {
        var historial = new Historial();

        historial.Registrar("Carla", 60);

        Assert.Equal(new[] { "Carla: 60" }, historial.Entradas);
    }

    [Fact]
    public void Registrar_a_Ana_con_40_la_agrega_al_historial()
    {
        var historial = new Historial();

        historial.Registrar("Ana", 40);

        Assert.Equal(new[] { "Ana: 40" }, historial.Entradas);
    }

    [Fact]
    public void El_historial_muestra_primero_la_partida_mas_reciente()
    {
        var historial = new Historial();

        historial.Registrar("Carla", 60);
        historial.Registrar("Ana", 40);

        Assert.Equal(new[] { "Ana: 40", "Carla: 60" }, historial.Entradas);
    }

    [Fact]
    public void Ganar_perfecto_en_dificil_da_80_puntos()
    {
        var juego = new Juego("GATO", Dificultad.Dificil);

        foreach (var letra in "GATO")
            juego.Adivinar(letra);

        Assert.Equal(80, juego.Puntaje);
    }

    [Fact]
    public void Ganar_perfecto_en_facil_da_40_puntos()
    {
        var juego = new Juego("GATO", Dificultad.Facil);

        foreach (var letra in "GATO")
            juego.Adivinar(letra);

        Assert.Equal(40, juego.Puntaje);
    }

    [Fact]
    public void En_Colores_la_posicion_0_es_ROJO()
    {
        var selector = new SelectorDePalabras(cantidad => 0);

        Assert.Equal("ROJO", selector.Elegir("Colores"));
    }

    [Fact]
    public void En_Colores_la_posicion_1_es_AZUL()
    {
        var selector = new SelectorDePalabras(cantidad => 1);

        Assert.Equal("AZUL", selector.Elegir("Colores"));
    }

    [Fact]
    public void En_Animales_la_posicion_0_es_GATO()
    {
        var selector = new SelectorDePalabras(cantidad => 0);

        Assert.Equal("GATO", selector.Elegir("Animales"));
    }
}
