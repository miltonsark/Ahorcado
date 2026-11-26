# Ahorcado

Juego del ahorcado desarrollado como **trabajo práctico para la materia Metodologías Ágiles**. La solución separa la lógica del juego de la interfaz web e incluye pruebas unitarias y pruebas de aceptación automatizadas.

## Aplicación y despliegue

La aplicación web está desarrollada con **Blazor WebAssembly** y publicada en **GitHub Pages**:

**[Jugar al Ahorcado](https://miltonsark.github.io/Ahorcado/)**

## Tecnologías

### Aplicación

- **C# y .NET 10**: lógica del juego y aplicación.
- **Blazor WebAssembly**: interfaz web ejecutada en el navegador.
- **HTML y CSS**: estructura y estilos de la interfaz.

### Pruebas unitarias

El proyecto `Tests/` prueba la lógica de dominio (`Ahorcado/`) sin automatizar un navegador. Utiliza:

- **xUnit** como framework de pruebas.
- **Microsoft.NET.Test.Sdk** para ejecutar las pruebas.
- **Coverlet** (`coverlet.collector` y `coverlet.msbuild`) para medir cobertura.

### Pruebas de aceptación

El proyecto `AcceptanceTests/` valida escenarios de comportamiento de la aplicación web. Utiliza:

- **Gherkin** para describir los escenarios en lenguaje natural.
- **Reqnroll** para vincular los escenarios Gherkin con sus definiciones de pasos en C#.
- **xUnit** como framework y runner de las pruebas.
- **Microsoft Playwright** para automatizar la interacción con la aplicación en el navegador; en CI se instala **Chromium**.

## Ejecutar localmente

### Requisitos

- [.NET SDK 10](https://dotnet.microsoft.com/download/dotnet/10.0)
- Git

### Aplicación web

```bash
git clone https://github.com/miltonsark/Ahorcado.git
cd Ahorcado
dotnet restore Ahorcado.slnx
dotnet run --project WebAhorcado
```

Abrí en el navegador la dirección que informe el comando. En el perfil HTTP de desarrollo configurado actualmente, es `http://localhost:5009`.

### Pruebas

Ejecutar las pruebas unitarias:

```bash
dotnet test Tests
```

Ejecutar las pruebas de aceptación:

```bash
dotnet test AcceptanceTests
```

Las pruebas de aceptación requieren un navegador compatible con Playwright. La configuración de CI instala Chromium antes de ejecutarlas.

## CI/CD con GitHub Actions

El workflow está definido en [`.github/workflows/ci.yml`](.github/workflows/ci.yml). Se ejecuta en estas situaciones:

- En cada `push` a la rama `master`.
- En cada pull request cuyo destino sea `master`.

Si hay una ejecución anterior todavía activa para la misma referencia (rama o pull request), se cancela para dar prioridad a la más reciente.

### Integración continua (CI)

El job `build-test` corre en Ubuntu y realiza, en orden, estos pasos:

1. Descarga el código con `actions/checkout`.
2. Configura .NET SDK `10.0.x`.
3. Restaura las dependencias de `Ahorcado.slnx`.
4. Compila la solución.
5. Ejecuta las pruebas unitarias de `Tests` y mide la cobertura del dominio. El job falla si la cobertura es inferior al **90 %**.
6. Instala Chromium y las dependencias del sistema necesarias para Playwright.
7. Ejecuta las pruebas de aceptación de `AcceptanceTests`.
8. Sube los resultados TRX y los archivos de cobertura como artefactos, incluso si fallan las pruebas.

Tanto los `push` como los pull requests ejecutan estas validaciones. El despliegue no se realiza desde un pull request.

### Despliegue continuo (CD)

El job `deploy` depende de que `build-test` finalice correctamente y solo se ejecuta cuando el evento es un `push` a `master`. Por lo tanto, un pull request puede pasar las pruebas, pero no publica el sitio; el despliegue ocurre al integrar los cambios en `master`.

El job de despliegue:

1. Publica `WebAhorcado` en modo `Release`.
2. Ajusta la ruta base del sitio a `/Ahorcado/`, necesaria para GitHub Pages.
3. Prepara `404.html` como fallback y crea `.nojekyll`.
4. Sube el sitio publicado como artefacto de Pages y lo despliega con GitHub Actions.

## Estructura del repositorio

- `Ahorcado/`: lógica y dominio del juego.
- `WebAhorcado/`: aplicación Blazor WebAssembly.
- `Tests/`: pruebas unitarias del dominio con xUnit.
- `AcceptanceTests/`: pruebas de aceptación con Gherkin, Reqnroll, xUnit y Playwright.
- `.github/workflows/ci.yml`: pipeline de CI/CD.
