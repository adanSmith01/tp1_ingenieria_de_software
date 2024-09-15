namespace tests;
using Sistema_gestion;
using Xunit;

public class TestProducto
{
    [Fact]
    public void CambiarPrecioDeProductoNegativo()
    {
        var producto = new Producto{Nombre = "prod-1", Precio=200, Categoria="cat-1"};

        Assert.Throws<Exception>(()=>{producto.CambiarPrecio(-100);});
    }

    [Fact]
    public void CreacionProducto()
    {
        var producto = new Producto{Nombre = "prod-1", Precio=-200, Categoria="cat-1"};
        Assert.True(producto.Precio >= 0, "El precio del producto no puede ser negativo");
    }

    [Fact]
    public void CambiarPrecioDeProductoPositivo()
    {
        var producto = new Producto{Nombre = "prod-1", Precio=200, Categoria="cat-1"};

        producto.CambiarPrecio(100);
        //Assert.Throws<Exception>(()=>{producto.CambiarPrecio(100);});
        Assert.Equal(100, producto.Precio);
    }
}

