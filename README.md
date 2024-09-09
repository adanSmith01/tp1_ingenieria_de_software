# Trabajo Practico N°1

## Integrantes
- Gramajo, Cristian
- Flores, Jorgelina
- Muñoz, David
- Paredes, Smith
 
## PREGUNTAS TP
- 1. ¿Puedes identificar preubas de unidad y de integracion en la practica que realizaste?
- 2. Podría haber escrito las pruebas primero antes de modificar el código de la aplicación?
¿Cómo sería el proceso de escribir primero los tests?
- 3. En lo que va del trabajo práctico, ¿puedes identificar 'Controladores' y 'Resguardos'?
- 4. ¿Qué es un mock? ¿Hay otros nombres para los objetos/funciones simulados? 
- 5. ¿Qué ventajas ve en el uso de fixtures? ¿Qué enfoque estaría aplicando?
- 6. Explique los conceptos de Setup y Teardown en testing.
- 7. ¿Puede describir una situación de desarrollo para este caso en donde se plantee pruebas de
integración ascendente? Describa la situación.


## RESPUESTAS TP
- 1. 
    - Pruebas de unidad:
        - EliminarProductoExistente()
        - BuscarProductoExistente()
    - Pruebas de integración:
        - AgregarProductoNoExistente()
        - AgregarProductoExistente()
        - BuscarProductoNoExistente()

- 2. Primero escribes los tests definiendo el comportamiento esperado con ayuda de mocks e interfaces. Esto te permite simular dependencias externas y validar la lógica sin tener que implementar toda la funcionalidad. Luego, cuando los tests fallan (lo cual confirma que la prueba es válida y que la funcionalidad aún no está implementada), comienzas a desarrollar el código hasta que los tests pasen, asegurando que la implementación cumpla con lo que los tests requieren.

- 3. 


## COMANDOS .NET
- `dotnet new <type>` inicio de nuevo proyecto `dotnet new classlib -n tests` para proyecto de libreria de test
- `dotnet new <type>` inicio de nuevo proyecto `dotnet new console -n sistema_tienda` para proyecto de consola
- `dotnet new class -n <nombre>` creación de una clase `dotnet new class -n Tienda`
- `dotnet add package <PACKAGE_NAME>` Agrega un paquete al proyecto desde nuget
- `dotnet add package <PACKAGE_NAME> -v <VERSION>` Agrega un paquete en una nueva versión
- `dotnet restore` Para instalar el paquete

## INSTALACIÓN XUNIT
- `dotnet add package xunit` instalación de la librería / framework de testing
- `dotnet add package xunit.runner.visualstudio` instalación del runner de xunit, comandos para correr tests
 
## CREACIÓN DEL PROYECTO DE TESTS
Es una practica comun crear un proyecto de test separado del proyecto original
- `dotnet new xunit -n <MiProyecto>.Tests` lo cual sería `dotnet new xunit -n TP1-ALT.Tests`
El la carpeta de tests del proyecto ejecuta el comando para agregar la referencia al proyecto de consola
- `dotnet add reference ../<MiProyecto>/<MiProyecto>.csproj` lo cual sería `dotnet add reference ../TPI_INGENIERIA_DE_SOFTWARE/tp1_ingenieria_de_software.csproj`
- 

## PREGUNTAS
- ¿Si poner los metodos o simplemente poner buscar un producto existente?
- Punto 1: aclaraciones sobre cuales son de u y de integracion.