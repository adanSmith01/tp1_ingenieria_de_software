namespace tests;
using Sistema_gestion;
using Xunit;

public class TestProducto
{
    [Fact]
    public void ActualizarPrecioDeProductoNegativo()
    {
        var producto = new Producto("prod-1", 1000, "cat-1");

        Assert.Throws<Exception>(()=>{producto.ActualizarPrecio(-100);});
    }

    [Fact]
    public void ActualizarPrecioDeProductoPositivo()
    {
        var producto = new Producto("prod-1", 1000, "cat-1");

        Assert.Equal(1000, producto.Precio);
    }
}

