using System;
using System.Collections.Generic;
using System.Text;

namespace Ahorcado;

public class Ahorcado
{
    private readonly string _palabra;
    private readonly HashSet<char> _acertadas = new HashSet<char>();

    public Ahorcado(string palabra) => _palabra = palabra;

    public void Adivinar(char letra)
    {
        if (_palabra.Contains(letra))
            _acertadas.Add(letra);
    }

    public string PalabraEnmascarada() => string.Join(" ", _palabra.Select(letra =>
        _acertadas.Contains(letra) ? letra.ToString() : "_"));
}
