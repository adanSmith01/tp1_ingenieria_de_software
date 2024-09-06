namespace Sistema_gestion;

public interface IProductoRepositorio
{
    Producto BuscarProducto(string nombre);
    void ActualizarProducto(Producto producto);
}
public class Tienda
{
    public List<Producto> Inventario;
    private readonly IProductoRepositorio _productRepositorio;

    public Tienda(IProductoRepositorio productRepositorio)
    {
        Inventario = new List<Producto>();
        _productRepositorio = productRepositorio;
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

    public void AplicarDescuento(string nombre, double porcentaje)
    {
        Producto producto = _productRepositorio.BuscarProducto(nombre);
        if (producto != null)
        {
            producto.Precio -= producto.Precio * (porcentaje / 100);
            _productRepositorio.ActualizarProducto(producto);
        }
    }

}