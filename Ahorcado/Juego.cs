using System;
using System.Collections.Generic;
using System.Text;

namespace Ahorcado;

public class Ahorcado
{
    private readonly string _palabra;
    private readonly List<char> _usadas = new();
    private readonly HashSet<char> _acertadas = new HashSet<char>();
    private readonly HashSet<char> _erradas = new HashSet<char>();
    private readonly int _maxErrores = 6;
    private readonly int _puntosPorVida = 10;
    private const string PalabraPorDefecto = "AHORCADO";
    private bool _pistaUsada;

    public Ahorcado(string palabra) => _palabra = palabra == "" ? PalabraPorDefecto : palabra;

    public Ahorcado(string palabra, Dificultad dificultad) : this(palabra)
    {
        (_maxErrores, _puntosPorVida) = dificultad switch
        {
            Dificultad.Facil => (8, 5),
            Dificultad.Dificil => (4, 20),
            _ => (6, 10)
        };
    }

    public string Categoria { get; init; } = "";

    public int Errores { get; private set; }
    private bool Perdio => Errores >= _maxErrores || TiempoRestante == 0;

    public string Mensaje { get; private set; } = "";

    public string Resultado =>
        Perdio ? "Perdiste" :
        _palabra.All(letra => _acertadas.Contains(letra)) ? "Ganaste" : "";

    public bool Terminado => Resultado != "";

    public int Puntaje => Resultado == "Ganaste" ? (_maxErrores - Errores) * _puntosPorVida : 0;

    public int PartesDelDibujo => Errores * 6 / _maxErrores;

    public bool PuedePedirPista => !_pistaUsada && !Terminado && Errores < _maxErrores - 1;

    public int? TiempoRestante { get; private set; }

    public void EstablecerLimite(int segundos) => TiempoRestante = segundos;

    public void PasarSegundo()
    {
        if (Terminado) return;

        TiempoRestante--;
    }

    public void Adivinar(char letra)
    {
        if (Terminado) return;

        letra = char.ToUpperInvariant(letra);
        Mensaje = "";

        if (_acertadas.Contains(letra) || _erradas.Contains(letra))
            Mensaje = $"La letra {letra} ya fue usada";

        if (!_usadas.Contains(letra))
            _usadas.Add(letra);

        if (_palabra.Contains(letra))
            _acertadas.Add(letra);
        else if (_erradas.Add(letra))
            Errores++;
    }

    public void PedirPista()
    {
        if (!PuedePedirPista) return;

        var letra = _palabra.First(l => !_acertadas.Contains(l));
        _acertadas.Add(letra);

        Errores++;
        _pistaUsada = true;
    }

    public string PalabraEnmascarada()
    {
        if (Perdio)
            return string.Join(" ", _palabra.Select(letra => letra.ToString()));

        return string.Join(" ", _palabra.Select(letra =>
            _acertadas.Contains(letra) ? letra.ToString() : "_"));
    }

    public IReadOnlyList<char> LetrasUsadas => _usadas;




}
