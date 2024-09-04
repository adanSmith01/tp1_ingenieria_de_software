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
}
