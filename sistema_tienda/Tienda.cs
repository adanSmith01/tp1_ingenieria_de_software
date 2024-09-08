namespace Sistema_gestion;

/*public interface IProductoRepositorio
{
    Producto BuscarProducto(string nombre);
    void ActualizarProducto(Producto producto);
    List<Producto> ObtenerInventario();
}

public class Tienda
{
    public List<Producto> Inventario;
    //private readonly IProductoRepositorio _productRepositorio;

    public Tienda(List<Producto> productos)
    {
        Inventario = productos;
    }

    public Tienda()
    {
        Inventario = new List<Producto>();
    }

    public void AgregarProducto(Producto p)
    {
        if(!EstaEnElInventario(p)) Inventario.Add(p);
    }

    private bool EstaEnElInventario(Producto p)
    {
        foreach(var prod in Inventario)
        {
            if(prod.Nombre == p.Nombre)
            {
                return true;
            }
        }

        return false;
    }

    public Producto BuscarProducto(string nombre)
    {
        foreach(var prod in Inventario)
        {
            if(prod.Nombre == nombre)
            {
                return prod;
            }
        }
        throw new Exception("Error al buscar");
    }

    public bool EliminarProducto(string nombre)
    {
        foreach(var prod in Inventario)
        {
            if(prod.Nombre == nombre) Inventario.Remove(prod);

            return true;
        }

        throw new Exception("Error al eliminar el producto");
    }

    /*public void AplicarDescuento(string nombre, double porcentaje)
    {
        Producto producto = _productRepositorio.BuscarProducto(nombre);
        if (producto != null)
        {
            var nuevoPrecio = producto.Precio * (1 - (porcentaje / 100));
            producto.CambiarPrecio(nuevoPrecio);
        }
    }*/

    public double CalcularTotalCarrito(List<string> nombres)
    {
        double total = 0;
        List<Producto> carrito = new List<Producto>();
        foreach(var nombreProd in nombres)
        {
            var producto = BuscarProducto(nombreProd);
            if (producto != null)
            {
                carrito.Add(producto);
            }
        }
        return total;
    }
}