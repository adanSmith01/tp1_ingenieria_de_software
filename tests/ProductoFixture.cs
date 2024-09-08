namespace tests;
using Sistema_gestion;

public class TiendaFixture : IDisposable
{
    public List<IProducto> productosPrueba { get; private set; }
    
    public TiendaFixture()
    {
        productosPrueba = new List<IProducto>();
        for(int i = 0; i < 9; i++)
        {
            string nombre = "prod-" + (i+1).ToString();
            string categoria = "cat-" + (i+1).ToString();
            productosPrueba.Add(new Producto(nombre, 1000*(i+1), categoria));
        };
    }

    public void Dispose()
    {
    }

}