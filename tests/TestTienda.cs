namespace tests;
using Sistema_gestion;
using Xunit;

public class TestTienda
{
    [Fact]
    public void AgregarProductoNoExistente()
    {
        var tienda = new Tienda();
        var producto = new Producto{Nombre = "prod-1", Precio=200, Categoria="cat-1"};
        var cant_ant = tienda.Inventario.Count;

        tienda.AgregarProducto(producto);

        var cant_act = tienda.Inventario.Count;

        Assert.Equal<int>(cant_ant+1, cant_act);
    }


    [Fact]
    public void AgregarProductoExistente()
    {
        var tienda = new Tienda();
        var producto = new Producto{Nombre = "prod-1", Precio=200, Categoria="cat-1"};
        var producto_1 = new Producto{Nombre = "prod-1", Precio=400, Categoria="cat-2"};

        tienda.AgregarProducto(producto);

        var cant_ant = tienda.Inventario.Count;

        tienda.AgregarProducto(producto_1);

        var cant_act = tienda.Inventario.Count;

        Assert.Equal<int>(cant_ant, cant_act);
    }


    [Fact]
    public void BuscarProductoExistente()
    {
        var tienda = new Tienda();
        var producto = new Producto{Nombre = "prod-1", Precio=200, Categoria="cat-1"};

        tienda.AgregarProducto(producto);

        var resultado = tienda.BuscarProducto(producto.Nombre);

        Assert.NotNull(resultado);
    }

    [Fact]
    public void BuscarProductoNoExistente()
    {
        var tienda = new Tienda();
        //Assert.Null(resultado);
        //Assert.Throws<Exception>(resultado);
        Assert.Throws<Exception>(()=>{tienda.BuscarProducto("orteguita");});
    }

    [Fact]
    public void EliminarProductoExistente()
    {
        var tienda = new Tienda();
        var producto = new Producto{Nombre = "prod-1", Precio=200, Categoria="cat-1"};

        tienda.AgregarProducto(producto);

        var resultado = tienda.EliminarProducto("prod-1");

        Assert.True(resultado);
    }
    
    [Fact]
    public void EliminarProductoNoExistente()
    {
        var tienda = new Tienda();

        //var resultado = tienda.EliminarProducto("orgetuasd");
        //Assert.False(resultado);
        Assert.Throws<Exception>(()=>{tienda.EliminarProducto("orgetuasd");});
    }
}
