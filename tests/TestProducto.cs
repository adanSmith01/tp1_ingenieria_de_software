namespace tests;
using Sistema_gestion;
using Xunit;

public class TestProducto
{
    [Fact]
    public void PruebaConstructorProducto()
    {
        // Arrange
        string nombreEsperado = "Laptop";
        double precioEsperado = 1500.99;
        string categoriaEsperada = "Electrónica";

        // Act
        Producto producto = new Producto(nombreEsperado, precioEsperado, categoriaEsperada);

        // Assert
        Assert.Equal(nombreEsperado, producto.Nombre);
        Assert.Equal(precioEsperado, producto.Precio);
        Assert.Equal(categoriaEsperada, producto.Categoria);
    }


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

