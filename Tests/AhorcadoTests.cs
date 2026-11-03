using Ahorcado;
using Xunit;
using Configuracion = Ahorcado.Configuracion;
using Dificultad = Ahorcado.Dificultad;
using Historial = Ahorcado.Historial;
using Idioma = Ahorcado.Idioma;
using Juego = Ahorcado.Ahorcado;
using Jugador = Ahorcado.Jugador;
using SelectorDePalabras = Ahorcado.SelectorDePalabras;
using Traductor = Ahorcado.Traductor;
using Turnos = Ahorcado.Turnos;

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

    [Fact]
    public void Con_limite_de_30_segundos_quedan_30()
    {
        var juego = new Juego("GATO");

        juego.EstablecerLimite(30);

        Assert.Equal(30, juego.TiempoRestante);
    }

    [Fact]
    public void Con_limite_de_60_y_un_segundo_quedan_59()
    {
        var juego = new Juego("GATO");

        juego.EstablecerLimite(60);
        juego.PasarSegundo();

        Assert.Equal(59, juego.TiempoRestante);
    }

    [Fact]
    public void Si_el_tiempo_llega_a_0_se_pierde()
    {
        var juego = new Juego("GATO");
        juego.EstablecerLimite(2);

        juego.PasarSegundo();
        juego.PasarSegundo();

        Assert.Equal("Perdiste", juego.Resultado);
    }

    [Fact]
    public void Si_el_tiempo_llega_a_0_se_revela_la_palabra()
    {
        var juego = new Juego("GATO");
        juego.EstablecerLimite(2);

        juego.PasarSegundo();
        juego.PasarSegundo();

        Assert.Equal("G A T O", juego.PalabraEnmascarada());
    }

    [Fact]
    public void El_tiempo_no_baja_de_0()
    {
        var juego = new Juego("GATO");
        juego.EstablecerLimite(2);

        juego.PasarSegundo();
        juego.PasarSegundo();
        juego.PasarSegundo();

        Assert.Equal(0, juego.TiempoRestante);
    }

    [Fact]
    public void Con_1_error_se_ve_1_parte()
    {
        var juego = new Juego("GATO");

        juego.Adivinar('Z');

        Assert.Equal(1, juego.PartesDelDibujo);
    }

    [Fact]
    public void Con_3_errores_se_ven_3_partes()
    {
        var juego = new Juego("GATO");

        foreach (var letra in "ZXQ")
            juego.Adivinar(letra);

        Assert.Equal(3, juego.PartesDelDibujo);
    }

    [Fact]
    public void En_dificil_con_2_errores_se_ven_3_partes()
    {
        var juego = new Juego("GATO", Dificultad.Dificil);

        foreach (var letra in "ZX")
            juego.Adivinar(letra);

        Assert.Equal(3, juego.PartesDelDibujo);
    }

    [Fact]
    public void En_ingles_Ganaste_es_You_won()
    {
        var traductor = new Traductor(Idioma.Ingles);

        Assert.Equal("You won", traductor.Traducir("Ganaste"));
    }

    [Fact]
    public void En_ingles_Perdiste_es_You_lost()
    {
        var traductor = new Traductor(Idioma.Ingles);

        Assert.Equal("You lost", traductor.Traducir("Perdiste"));
    }

    [Fact]
    public void En_espanol_Ganaste_queda_igual()
    {
        var traductor = new Traductor(Idioma.Espanol);

        Assert.Equal("Ganaste", traductor.Traducir("Ganaste"));
    }

    [Fact]
    public void En_ingles_se_traduce_el_aviso_de_letra_usada()
    {
        var traductor = new Traductor(Idioma.Ingles);

        Assert.Equal("The letter Z was already used", traductor.Traducir("La letra Z ya fue usada"));
    }

    [Fact]
    public void En_ingles_la_palabra_por_defecto_es_HANGMAN()
    {
        Assert.Equal("HANGMAN", SelectorDePalabras.PalabraPorDefecto(Idioma.Ingles));
    }

    [Fact]
    public void En_espanol_la_palabra_por_defecto_es_AHORCADO()
    {
        Assert.Equal("AHORCADO", SelectorDePalabras.PalabraPorDefecto(Idioma.Espanol));
    }

    [Fact]
    public void En_ingles_Colores_posicion_0_es_RED()
    {
        var selector = new SelectorDePalabras(cantidad => 0);

        Assert.Equal("RED", selector.Elegir("Colores", Idioma.Ingles));
    }

    [Fact]
    public void En_ingles_Animales_posicion_1_es_DOG()
    {
        var selector = new SelectorDePalabras(cantidad => 1);

        Assert.Equal("DOG", selector.Elegir("Animales", Idioma.Ingles));
    }

    [Fact]
    public void Con_Ana_y_Beto_empieza_Ana()
    {
        var turnos = new Turnos("Ana, Beto");

        Assert.Equal("Ana", turnos.Actual);
    }

    [Fact]
    public void Con_Beto_y_Ana_empieza_Beto()
    {
        var turnos = new Turnos("Beto, Ana");

        Assert.Equal("Beto", turnos.Actual);
    }

    [Fact]
    public void Al_pasar_el_turno_le_toca_a_Beto()
    {
        var turnos = new Turnos("Ana, Beto");

        turnos.Pasar();

        Assert.Equal("Beto", turnos.Actual);
    }
    [Fact]
    public void Despues_del_ultimo_vuelve_al_primero()
    {
        var turnos = new Turnos("Ana, Beto");

        turnos.Pasar();
        turnos.Pasar();

        Assert.Equal("Ana", turnos.Actual);
    }

    [Fact]
    public void Se_juega_con_hasta_4_jugadores()
    {
        var turnos = new Turnos("Ana, Beto, Caro, Dani, Eli");

        for (var i = 0; i < 4; i++)
            turnos.Pasar();

        Assert.Equal("Ana", turnos.Actual);
    }

    [Fact]
    public void Sin_nombres_juega_Anonimo()
    {
        var turnos = new Turnos("");

        Assert.Equal("Anónimo", turnos.Actual);
    }

    [Fact]
    public void Configuracion_predeterminada_en_ingles_usa_una_categoria_al_azar()
    {
        var config = new Configuracion { Idioma = Idioma.Ingles };

        var juego = config.CrearPartida(new SelectorDePalabras(_ => 0));

        Assert.Equal("_ _ _", juego.PalabraEnmascarada());
    }

    [Fact]
    public void Configuracion_predeterminada_usa_una_categoria_al_azar()
    {
        var config = new Configuracion();

        var juego = config.CrearPartida(new SelectorDePalabras(_ => 0));

        Assert.Equal("_ _ _ _", juego.PalabraEnmascarada());
    }

    [Fact]
    public void Configuracion_con_categoria_Animales_crea_la_partida_con_GATO()
    {
        var config = new Configuracion { Categoria = "Animales" };

        var juego = config.CrearPartida(new SelectorDePalabras(_ => 0));

        Assert.Equal("_ _ _ _", juego.PalabraEnmascarada());
    }

    [Fact]
    public void Configuracion_con_Frutas_en_ingles_crea_la_partida_con_APPLE()
    {
        var config = new Configuracion { Categoria = "Frutas", Idioma = Idioma.Ingles };

        var juego = config.CrearPartida(new SelectorDePalabras(_ => 0));

        Assert.Equal("_ _ _ _ _", juego.PalabraEnmascarada());
    }

    [Fact]
    public void Configuracion_en_Dificil_crea_una_partida_que_se_pierde_con_4_errores()
    {
        var config = new Configuracion { Dificultad = Dificultad.Dificil };

        var juego = config.CrearPartida(new SelectorDePalabras(_ => 0));
        foreach (var letra in "ZXQW")
            juego.Adivinar(letra);

        Assert.Equal("Perdiste", juego.Resultado);
    }

    [Fact]
    public void Configuracion_con_30_segundos_crea_la_partida_con_limite()
    {
        var config = new Configuracion { Tiempo = 30 };

        var juego = config.CrearPartida(new SelectorDePalabras(_ => 0));

        Assert.Equal(30, juego.TiempoRestante);
    }

    [Fact]
    public void Configuracion_sin_tiempo_crea_la_partida_sin_limite()
    {
        var config = new Configuracion();

        var juego = config.CrearPartida(new SelectorDePalabras(_ => 0));

        Assert.Null(juego.TiempoRestante);
    }

    [Fact]
    public void Configuracion_con_palabra_fija_ignora_idioma_y_categoria()
    {
        var config = new Configuracion { Idioma = Idioma.Ingles, Categoria = "Frutas" };

        var juego = config.CrearPartida(new SelectorDePalabras(_ => 0), "GATO");

        Assert.Equal("_ _ _ _", juego.PalabraEnmascarada());
    }

    [Fact]
    public void Al_adivinar_una_letra_nueva_se_borra_el_mensaje()
    {
        var juego = new Juego("GATO");

        juego.Adivinar('A');
        juego.Adivinar('A');
        juego.Adivinar('T');

        Assert.Equal("", juego.Mensaje);
    }

    [Theory]
    [InlineData("Iniciar partida", "Start game")]
    [InlineData("Configuración", "Settings")]
    [InlineData("Historial y jugadores", "History and players")]
    [InlineData("Guardar", "Save")]
    [InlineData("Jugadores", "Players")]
    public void Traductor_traduce_los_textos_de_las_pantallas_nuevas(string texto, string esperado)
    {
        var traductor = new Traductor(Idioma.Ingles);

        Assert.Equal(esperado, traductor.Traducir(texto));
    }

    [Fact]
    public void Turnos_exponen_la_lista_de_jugadores()
    {
        var turnos = new Turnos("Ana, Carla");

        Assert.Equal(new[] { "Ana", "Carla" }, turnos.Jugadores);
    }

    [Theory]
    [InlineData("Inicio", "Home")]
    [InlineData("Orden de turnos", "Turn order")]
    [InlineData("Últimas partidas", "Latest games")]
    public void Traductor_traduce_los_textos_del_historial(string texto, string esperado)
    {
        var traductor = new Traductor(Idioma.Ingles);

        Assert.Equal(esperado, traductor.Traducir(texto));
    }

    [Fact]
    public void Traductor_traduce_el_skin_Neon()
    {
        var traductor = new Traductor(Idioma.Ingles);

        Assert.Equal("Neon", traductor.Traducir("Neón"));
    }

    [Fact]
    public void Selector_elige_la_categoria_de_la_posicion_sorteada()
    {
        var selector = new SelectorDePalabras(_ => 1);

        Assert.Equal("Frutas", selector.ElegirCategoria());
    }

    [Fact]
    public void Selector_con_la_posicion_2_elige_Colores()
    {
        var selector = new SelectorDePalabras(_ => 2);

        Assert.Equal("Colores", selector.ElegirCategoria());
    }

    [Fact]
    public void Configuracion_aleatoria_elige_la_palabra_de_una_categoria_al_azar()
    {
        var config = new Configuracion { Categoria = "Aleatoria" };

        var juego = config.CrearPartida(new SelectorDePalabras(_ => 1));

        Assert.Equal("_ _ _ _ _ _", juego.PalabraEnmascarada());
    }

    [Fact]
    public void La_partida_sabe_de_que_categoria_es_su_palabra()
    {
        var juego = new Configuracion { Categoria = "Aleatoria" }.CrearPartida(new SelectorDePalabras(_ => 1));

        Assert.Equal("Frutas", juego.Categoria);
    }

    [Fact]
    public void Traductor_traduce_Aleatoria()
    {
        Assert.Equal("Random", new Traductor(Idioma.Ingles).Traducir("Aleatoria"));
    }

    [Fact]
    public void Selector_elige_palabras_distintas_de_la_categoria()
    {
        var selector = new SelectorDePalabras(_ => 0);

        Assert.Equal(new[] { "GATO", "PERRO" }, selector.ElegirDistintas("Animales", Idioma.Espanol, 2));
    }
    [Fact]
    public void Selector_elige_tres_palabras_distintas_de_Frutas()
    {
        var selector = new SelectorDePalabras(_ => 0);

        Assert.Equal(
            new[] { "MANZANA", "BANANA", "PERA" },
            selector.ElegirDistintas("Frutas", Idioma.Espanol, 3));
    }

    [Fact]
    public void Selector_al_azar_las_4_palabras_son_distintas()
    {
        var palabras = new SelectorDePalabras(Random.Shared.Next).ElegirDistintas("Colores", Idioma.Espanol, 4);

        Assert.Equal(4, palabras.Distinct().Count());
    }

    [Fact]
    public void Configuracion_crea_una_partida_con_palabra_distinta_por_jugador()
    {
        var config = new Configuracion { Categoria = "Animales" };

        var juegos = config.CrearPartidas(new SelectorDePalabras(_ => 0), 2);

        Assert.Equal(new[] { "_ _ _ _", "_ _ _ _ _" }, juegos.Select(j => j.PalabraEnmascarada()));
    }

    [Fact]
    public void Configuracion_todas_las_partidas_comparten_categoria_dificultad_tiempo()
    {
        var config = new Configuracion { Dificultad = Dificultad.Dificil, Tiempo = 30 };

        var juegos = config.CrearPartidas(new SelectorDePalabras(_ => 0), 3);

        Assert.All(juegos, juego =>
        {
            Assert.Equal("Animales", juego.Categoria);
            Assert.Equal(30, juego.TiempoRestante);
        });
    }

    [Fact]
    public void Configuracion_con_palabras_fijas_cada_jugador_recibe_la_suya()
    {
        var config = new Configuracion { Categoria = "Frutas" };

        var juegos = config.CrearPartidas(new SelectorDePalabras(_ => 0), 2, new[] { "GATO", "PERRO" });

        Assert.Equal(new[] { "_ _ _ _", "_ _ _ _ _" }, juegos.Select(j => j.PalabraEnmascarada()));
    }

    [Fact]
    public void Configuracion_una_sola_palabra_fija_se_usa_para_todos()
    {
        var config = new Configuracion { Categoria = "Animales" };

        var juegos = config.CrearPartidas(new SelectorDePalabras(_ => 0), 2, new[] { "GATO" });

        Assert.All(juegos, j => Assert.Equal("_ _ _ _", j.PalabraEnmascarada()));
    }

    [Fact]
    public void Ronda_empieza_con_el_primer_jugador()
    {
        var historial = new Historial();
        var ronda = new Ronda(new[] { "Ana", "Beto" }, new[] { new Juego("GATO"), new Juego("PERRO") }, historial);

        Assert.Equal("Ana", ronda.JugadorActual);
    }

    [Fact]
    public void Ronda_con_Beto_primero_empieza_Beto()
    {
        var historial = new Historial();
        var ronda = new Ronda(new[] { "Beto", "Ana" }, new[] { new Juego("GATO"), new Juego("PERRO") }, historial);

        Assert.Equal("Beto", ronda.JugadorActual);
    }

    [Fact]
    public void Ronda_si_el_jugador_falla_le_toca_al_siguiente()
    {
        var historial = new Historial();
        var ronda = new Ronda(new[] { "Ana", "Beto" }, new[] { new Juego("GATO"), new Juego("PERRO") }, historial);

        ronda.Adivinar('Z');

        Assert.Equal("Beto", ronda.JugadorActual);
    }

    [Fact]
    public void Ronda_si_el_jugador_acierta_sigue_jugando()
    {
        var historial = new Historial();
        var ronda = new Ronda(new[] { "Ana", "Beto" }, new[] { new Juego("GATO"), new Juego("PERRO") }, historial);

        ronda.Adivinar('G');

        Assert.Equal("Ana", ronda.JugadorActual);
    }

    [Fact]
    public void Ronda_cada_jugador_adivina_su_propia_palabra()
    {
        var historial = new Historial();
        var ronda = new Ronda(new[] { "Ana", "Beto" }, new[] { new Juego("GATO"), new Juego("PERRO") }, historial);

        ronda.Adivinar('Z');   // Ana falla → Beto
        ronda.Adivinar('P');   // Beto acierta la P de PERRO

        Assert.Equal("P _ _ _ _", ronda.JuegoActual.PalabraEnmascarada());
    }

    [Fact]
    public void Ronda_si_el_jugador_completa_su_palabra_pasa_el_turno()
    {
        var historial = new Historial();
        var ronda = new Ronda(new[] { "Ana", "Beto" }, new[] { new Juego("GATO"), new Juego("PERRO") }, historial);

        foreach (var letra in "GATO")
            ronda.Adivinar(letra);

        Assert.Equal("Beto", ronda.JugadorActual);
    }

    [Fact]
    public void Ronda_el_turno_saltea_a_quien_ya_termino()
    {
        var ronda = new Ronda(new[] { "Ana", "Beto", "Carla" },
            new[] { new Juego("GATO"), new Juego("PERRO"), new Juego("UVA") }, new Historial());

        foreach (var letra in "GATO")
            ronda.Adivinar(letra);   // Ana gana, le toca a Beto
        ronda.Adivinar('Z');         // Beto falla, le toca a Carla
        ronda.Adivinar('Z');         // Carla falla: Ana ya terminó, le toca a Beto

        Assert.Equal("Beto", ronda.JugadorActual);
    }

    [Fact]
    public void Ronda_termina_cuando_todos_terminaron()
    {
        var historial = new Historial();
        var ronda = new Ronda(new[] { "Ana" }, new[] { new Juego("GATO") }, historial);

        foreach (var letra in "GATO")
            ronda.Adivinar(letra);

        Assert.True(ronda.Terminada);
    }

    [Fact]
    public void Ronda_cada_juego_terminado_se_registra_una_sola_vez()
    {
        var historial = new Historial();
        var ronda = new Ronda(new[] { "Ana" }, new[] { new Juego("GATO") }, historial);

        foreach (var letra in "GATOX")
            ronda.Adivinar(letra);   // la X llega con el juego ya terminado

        Assert.Equal(new[] { "Ana: 60" }, historial.Entradas);
    }

    [Fact]
    public void Ronda_pedir_pista_pasa_el_turno()
    {
        var historial = new Historial();
        var ronda = new Ronda(new[] { "Ana", "Beto" }, new[] { new Juego("GATO"), new Juego("PERRO") }, historial);

        ronda.PedirPista();

        Assert.Equal("Beto", ronda.JugadorActual);
    }

    [Fact]
    public void Ronda_solo_corre_el_reloj_del_jugador_en_turno()
    {
        var deAna = new Juego("GATO");
        var deBeto = new Juego("PERRO");
        deAna.EstablecerLimite(30);
        deBeto.EstablecerLimite(30);
        var ronda = new Ronda(new[] { "Ana", "Beto" }, new[] { deAna, deBeto }, new Historial());

        ronda.PasarSegundo();

        Assert.Equal(29, deAna.TiempoRestante);
        Assert.Equal(30, deBeto.TiempoRestante);
    }

    [Fact]
    public void Ronda_si_se_acaba_el_tiempo_pierde_y_pasa_el_turno()
    {
        var historial = new Historial();
        var deAna = new Juego("GATO");
        var deBeto = new Juego("PERRO");
        deAna.EstablecerLimite(1);
        deBeto.EstablecerLimite(1);
        var ronda = new Ronda(new[] { "Ana", "Beto" }, new[] { deAna, deBeto }, historial);

        ronda.PasarSegundo();

        Assert.Equal("Beto", ronda.JugadorActual);
        Assert.Single(historial.Entradas);
    }

    [Fact]
    public void Ronda_con_un_solo_jugador_despues_de_fallar_sigue_jugando_el()
    {
        var historial = new Historial();
        var ronda = new Ronda(new[] { "Ana" }, new[] { new Juego("GATO") }, historial);

        ronda.Adivinar('Z');

        Assert.Equal("Ana", ronda.JugadorActual);
    }

    [Fact]
    public void Perder_por_tiempo_da_0_puntos()
    {
        var juego = new Juego("GATO");
        juego.EstablecerLimite(1);

        juego.PasarSegundo();

        Assert.Equal(0, juego.Puntaje);
    }

    [Fact]
    public void Al_adivinar_la_letra_queda_entre_las_usadas()
    {
        var juego = new Juego("GATO");

        juego.Adivinar('G');

        Assert.Equal(new[] { 'G' }, juego.LetrasUsadas);
    }
}
