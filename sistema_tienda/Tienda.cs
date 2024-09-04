namespace Sistema_gestion;

public class Tienda
{
    public List<Producto> Inventario;

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

        return null;
    }

    public bool EliminarProducto(string nombre)
    {
        foreach(var prod in Inventario)
        {
            if(prod.Nombre == nombre) Inventario.Remove(prod);

            return true;
        }

        return false;
    }

}