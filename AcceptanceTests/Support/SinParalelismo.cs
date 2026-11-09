// Los tests de aceptación corren de a un feature por vez.
// Cada escenario abre su propio navegador y descarga la app entera contra un único servidor:
// en paralelo, las computadoras con menos recursos se saturan y algunos escenarios
// quedan en "Loading..." más de 5 segundos y fallan al azar.
[assembly: CollectionBehavior(DisableTestParallelization = true)]
