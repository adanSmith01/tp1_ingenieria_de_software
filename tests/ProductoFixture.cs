namespace tests;
using Sistema_gestion;

public class ProductoFixture : IDisposable
{
    public Producto productoPrueba { get; private set; }
    
    public ProductoFixture()
    {
        productoPrueba = new Producto{Nombre="prod-1", Precio=1000, Categoria="cat-1"};
    }

    public void Dispose()
    {
    }

}