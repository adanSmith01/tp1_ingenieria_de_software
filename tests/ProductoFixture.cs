namespace tests;
using Sistema_gestion;

public class ProductoFixture : IDisposable
{
    public List<Producto> productosPrueba { get; private set; }
    
    public ProductoFixture()
    {
        productosPrueba = GenerarProductosPrueba();
    }

    public List<Producto> GenerarProductosPrueba()
    {
        productosPrueba = new List<Producto>();
        
        for(int i = 0; i < 9; i++)
        {
            string nombre = "prod-" + (i+1).ToString();
            string categoria = "cat-" + (i+1).ToString();
            productosPrueba.Add(new Producto(nombre, 1000*(i+1), categoria));
        }
        return productosPrueba;
    }

    public void Reset()
    {
        productosPrueba = GenerarProductosPrueba();
    }

    public void Dispose()
    {
    }

}