using System;
using System.Collections.Generic;
using System.Text;

namespace Ahorcado;

public class Ahorcado
{
    private readonly string _palabra;

    public Ahorcado(string palabra) => _palabra = palabra;

    public string PalabraEnmascarada() => string.Join(" ", _palabra.Select(_ => "_"));
}
