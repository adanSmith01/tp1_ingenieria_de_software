# Trabajo Práctico N° 1

## Integrantes
- Gramajo, Cristian
- Flores, Jorgelina
- Muñoz, David
- Paredes, Smith
 
## PREGUNTAS TP
1. ¿Puedes identificar preubas de unidad y de integracion en la practica que realizaste?
2. Podría haber escrito las pruebas primero antes de modificar el código de la aplicación?
¿Cómo sería el proceso de escribir primero los tests?
3. En lo que va del trabajo práctico, ¿puedes identificar 'Controladores' y 'Resguardos'?
4. ¿Qué es un mock? ¿Hay otros nombres para los objetos/funciones simulados? 
5. ¿Qué ventajas ve en el uso de fixtures? ¿Qué enfoque estaría aplicando?
6. Explique los conceptos de Setup y Teardown en testing.
7. ¿Puede describir una situación de desarrollo para este caso en donde se plantee pruebas de
integración ascendente? Describa la situación.


## RESPUESTAS TP
1. 
    - Pruebas de unidad:
        - PruebaConstructorProducto()
    - Pruebas de integración:
        - AgregarProductoNoExistente()
        - AgregarProductoExistente()
        - BuscarProductoExistente()
        - BuscarProductoNoExistente()
        - EliminarProductoExistente()
        - EliminarProductoNoExistente()
        
        

<br>
    Todos los métodos descritos en la sección de pruebas de integración se consideran pruebas de integración, ya que, en el contexto de un sistema de gestión de productos, están diseñados para verificar la interacción entre los distintos módulos y componentes del sistema. Estas pruebas garantizan que las funcionalidades trabajen en conjunto de manera correcta.
<br>

2. Primero escribes los tests definiendo el comportamiento esperado con ayuda de mocks e interfaces. Esto te permite simular dependencias externas y validar la lógica sin tener que implementar toda la funcionalidad. Luego, cuando los tests fallan (lo cual confirma que la prueba es válida y que la funcionalidad aún no está implementada), comienzas a desarrollar el código hasta que los tests pasen, asegurando que la implementación cumpla con lo que los tests requieren.

<br>

3. - Controladores: No hay
    - Resguardos: Mock de producto 
    
    <br>
4. Los Mocks “son objetos preprogramados con expectativas que conforman la especificación de lo que se espera que reciban las llamadas”, es decir, son objetos que se usan para probar que se realizan correctamente llamadas a otros métodos, por ejemplo, a una web API, por lo que se utilizan para verificar el comportamiento de los objetos. El propósito de esto es que, al probar el programa, se utilice el mock en vez del objeto real.
<br>
Existen varios términos para referirse a componentes que simulan el código real en pruebas, entre los más comunes se encuentran:
* Stub (Resguardo): Simula la respuesta de una dependencia, pero sin verificar interacciones.
Proporcionan respuestas predefinidas (datos predefinidos) a ciertas llamadas durante los test, sin responder a otra cosa para la que no hayan sido programados, es decir, los stubs son configurados para que devuelvan valores que se ajusten a lo que la prueba unitaria quiere probar, por lo que se utilizan para verificar el estado de los objetos..
* Fake: Es una implementación funcional pero simplificada de una dependencia real. Por ejemplo, un objeto "fake" podría simular una base de datos en memoria.
* Spy (Controlador): Similar a un mock, pero se enfoca principalmente en espiar las interacciones de un objeto, permitiendo verificar cuántas veces o cómo se llamó a un método.
* Dummy: Un objeto que se pasa a un método pero no se utiliza, generalmente para cumplir con los requisitos de firma de un método. Solo tiene la estructura mínima necesaria para compilar o ejecutar.

<br>

 5.  Ventajas principales en el uso de Fixture:
 * Precisión y Calidad: Los fixtures aseguran que las piezas se mantengan en una posición fija y precisa durante el proceso de fabricación, lo que reduce errores y mejora la calidad del producto final.
 * Aumento de la Productividad: Al mantener las piezas en su lugar, los fixtures permiten una producción más rápida y eficiente, reduciendo el tiempo de configuración y cambio entre diferentes tareas.
 * Reducción de Mano de Obra Calificada: Simplifican el proceso de ensamblaje, lo que disminuye la necesidad de mano de obra altamente calificada y permite que los operarios menos experimentados realicen tareas complejas.
 * Consistencia: Garantizan que cada pieza producida sea idéntica a las demás, lo cual es crucial en la producción en masa.

 <br>
 El enfoque que se estaría aplicando no es caja negra ni caja blanca siendo que los fixture no tienen relacion con el enfoque de las pruebas. Es irrelevante el enfoque (en el sentido caja negra o blanca) 
 dado que la naturaleza de los fixtures permiten establecer datos predeterminados que pueden ser utilzados en distintas partes.
 
 <br>

 6. SetUp es un método ejecutado antes de cada test, para inicializar las variables y el entorno en un estado conocido. De la misma forma TearDown es ejecutado después de cada test, pasen o falle, para limpiar las variables inicializadas.
 En XUnit, TearDown se ejecuta automáticamente por cada test.
 
 <br>
 
 7. Estás desarrollando una aplicación de gestión de tienda en la que los clientes pueden comprar productos. La aplicación tiene dos componentes principales: el módulo de productos y el módulo de tienda. El módulo de productos gestiona la información de los artículos disponibles, mientras que el módulo de tienda maneja la lógica relacionada con los productos. 
 En este caso, sería coherente comenzar desarrollando primero el módulo de productos, ya que proporciona la base de datos necesaria para que el módulo de tienda funcione correctamente. Después de implementar y probar el módulo de productos, puedes desarrollar el módulo de tienda y luego realizar una prueba de integración ascendente. 


## PRE-REQUISITOS
- .NET 8
- Framework de prueba: XUnit
- Entorno de ejecución: Visual Studio Code o Visual Studio

## PASOS A SEGUIR
- 1. Clonar repositorio: `git clone https://github.com/adanSmith01/tp1_ingenieria_de_software.git`
- 2. Re instalar los paquetes del proyecto: `dotnet restore` 
- 3. Con el proyecto abierto, y desde la carpeta raíz del mismo `CNTRL+SHIFT+C` para abrir la terminal, o simplemente abrir la terminal integrada del IDE
- 4. Ingresar a la carpeta tests `cd tests` y orrer los tests con `dotnet test`


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

## ACLARACIÓN
EN la carpeta de tests del proyecto ejecuta el comando para agregar la referencia al proyecto de consola

```dotnet add reference ../<MiProyecto>/<MiProyecto>.csproj` lo cual sería `dotnet add reference ../tp1_ingenieria_de_software/tp1_ingenieria_de_software.csproj```
