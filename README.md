# Trabajo Practico N°1

## Integrantes
- Gramajo, Cristian
- Flores, Jorgelina
- Muñoz, David
- Paredes, Smith
 
## PREGUNTAS TP
- 1. ¿Puedes identificar preubas de unidad y de integracion en la practica que realizaste?
- 2. 
- 

## RESPUESTAS TP
- 1. TestTienda.cs - preguntar
    - Pruebas de unidad:
        - EliminarProductoExistente()
        - EliminarProductoNoExistente()
    - Pruebas de integración:
        - AgregarProductoNoExistente()
        - AgregarProductoExistente()
        - BuscarProductoExistente()
        - BuscarProductoNoExistente()
- 2. 
- 3. 
- 4. 
- 5. ¿Puede describir una situación de desarrollo para este caso en donde se plantee pruebas de integración ascendente? Describa la situación
    - Repaso: Prueba de integración ascendente, es una estrategia en la que los módulos se prueban primero en jerarquía inferior (los componentes de nivel más bajo), y luego se integran gradualmente con módulos de niveles más altos hasta probar sistema completo.
    - En este ultimo ejemplo, se prueba la interacción de clases y sus interacciones sin necesidad de drivers o simulaciones de dependencias externas.
        - Producto (Product): Representa los productos con sus atributos, como nombre y precio
        - Carrito de Compras (ShoppingCart): Mantiene una lista de productos agregados por el cliente
        - Tienda (Store): Proporciona acceso a los productos disponibles y calcula el total de la compra.
    - Proceso de Prueba de Integración Ascendente
        - 1. Pruebas unitarias de Producto: Primero, probaríamos la clase más básica, que es Producto. Queremos asegurarnos de que los productos se crean correctamente y sus atributos son correctos
        - 2. Pruebas de Carrito de Compras: Una vez que los productos están funcionando correctamente, integramos y probamos la clase ShoppingCart, que interactúa con los productos. Aquí verificaríamos que el carrito puede agregar productos y calcular el total correctamente
        - 3. Pruebas de Tienda: Finalmente, integramos la clase Store, que proporciona acceso a productos y puede interactuar con el carrito. Aquí probamos que la tienda pueda ofrecer productos y calcular el total para el cliente utilizando el carrito
    - Este flujo asegura que cada componente básico (Producto, ShoppingCart, y Store) se pruebe por separado, y luego se integren de forma ascendente, confirmando que trabajan correctamente juntos


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