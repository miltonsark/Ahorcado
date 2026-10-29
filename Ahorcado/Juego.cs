using System;
using System.Collections.Generic;
using System.Text;

namespace Ahorcado;

public class Ahorcado
{
    private readonly string _palabra;
    private readonly HashSet<char> _acertadas = new HashSet<char>();
    private readonly HashSet<char> _erradas = new HashSet<char>();
    private const int MaxErrores = 6;
    private const string PalabraPorDefecto = "AHORCADO";
    private bool _pistaUsada;

    public Ahorcado(string palabra) => _palabra = palabra == "" ? PalabraPorDefecto : palabra;

    public int Errores { get; private set; }

    public string Mensaje { get; private set; } = "";

    public string Resultado =>
        Errores >= MaxErrores ? "Perdiste" :
        _palabra.All(letra => _acertadas.Contains(letra)) ? "Ganaste" : "";

    public bool Terminado => Resultado != "";

    public int Puntaje => Terminado ? (MaxErrores - Errores) * 10 : 0;

    public bool PuedePedirPista => !_pistaUsada && !Terminado && Errores < MaxErrores - 1;

    public void Adivinar(char letra)
    {
        if (Terminado) return;

        letra = char.ToUpperInvariant(letra);

        if (_acertadas.Contains(letra) || _erradas.Contains(letra))
            Mensaje = $"La letra {letra} ya fue usada";

        if (_palabra.Contains(letra))
            _acertadas.Add(letra);
        else if (_erradas.Add(letra))
            Errores++;
    }

    public void PedirPista()
    {
        var letra = _palabra.First(l => !_acertadas.Contains(l));
        _acertadas.Add(letra);
        Errores++;
        _pistaUsada = true;
    }

    public string PalabraEnmascarada()
    {
        if (Errores >= MaxErrores)
            return string.Join(" ", _palabra.Select(letra => letra.ToString()));

        return string.Join(" ", _palabra.Select(letra =>
            _acertadas.Contains(letra) ? letra.ToString() : "_"));
    }
}
