using System;
using System.Collections.Generic;
using System.Text;

namespace Ahorcado;

public class Ahorcado
{
    private readonly string _palabra;
    private readonly HashSet<char> _acertadas = new HashSet<char>();
    private readonly HashSet<char> _erradas = new HashSet<char>();

    public Ahorcado(string palabra) => _palabra = palabra;

    public int Errores { get; private set; }

    public string Mensaje { get; private set; } = "";

    public string Resultado => _palabra.All(letra => _acertadas.Contains(letra)) ? "Ganaste" : "";

    public void Adivinar(char letra)
    {
        letra = char.ToUpperInvariant(letra);

        if (_acertadas.Contains(letra) || _erradas.Contains(letra))
        Mensaje = $"La letra {letra} ya fue usada";

        if (_palabra.Contains(letra))
            _acertadas.Add(letra);
        else if (_erradas.Add(letra))
            Errores++;
    }

    public string PalabraEnmascarada() => string.Join(" ", _palabra.Select(letra =>
        _acertadas.Contains(letra) ? letra.ToString() : "_"));
}
