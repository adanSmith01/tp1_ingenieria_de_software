namespace Sistema_gestion;

public class Tienda
{
    public List<IProducto> Inventario;

    public Tienda(List<Producto> productos)
    {
        Inventario = new List<IProducto>();
        for (int i = 0; i < productos.Count; i++)
        {
            Inventario.Add(productos[i]);
        }
    }

    public void AgregarProducto(IProducto p)
    {
        if(!EstaEnElInventario(p)) Inventario.Add(p);
    }

    private bool EstaEnElInventario(IProducto p)
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

    public IProducto BuscarProducto(string nombre)
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
        foreach(var prod in Inventario)
        {
            if(prod.Nombre == nombre)
            {
                var nuevoPrecio = prod.Precio * (1 - (porcentaje / 100));
                prod.ActualizarPrecio(nuevoPrecio);
            }
            
        }
    }

    public double CalcularTotalCarrito(List<IProducto> productos)
    {
        double total = 0;
        foreach(var prod in productos)
        {
            total += prod.Precio;
        }

        return total;
    }

}