using System;
using System.Collections.Generic;
using System.Text;

namespace Ahorcado;

public class Ahorcado
{
    private readonly string _palabra;
    private readonly HashSet<char> _acertadas = new HashSet<char>();

    public Ahorcado(string palabra) => _palabra = palabra;

    public int Errores => 0;
    public void Adivinar(char letra)
    {
        letra = char.ToUpperInvariant(letra);

        if (_palabra.Contains(letra))
            _acertadas.Add(letra);
    }

    public string PalabraEnmascarada() => string.Join(" ", _palabra.Select(letra =>
        _acertadas.Contains(letra) ? letra.ToString() : "_"));
}
