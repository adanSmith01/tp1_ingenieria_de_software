namespace Sistema_gestion;

public interface IProducto{
    string Nombre();
    double Precio();
    string Categoria();
    void CambiarPrecio(double precio);
}

public class Producto: IProducto
{
    private string nombre;
    private double precio;
    private string categoria; 

    public Producto(string nombre, double precio, string categoria)
    {
        this.nombre = nombre;
        this.precio = precio;
        this.categoria = categoria;
    }

    public string Nombre()
    {
        return nombre;
    }

    public void Nombre(string nombre)
    {
        this.nombre = nombre;
    }

    public string Categoria()
    {
        return categoria;
    }

    public void Categoria(string categoria)
    {
        this.categoria = categoria;
    }

    public double Precio()
    {
        return precio;
    }

    public void Precio(double precio)
    {
        this.precio = precio;
    }


    public void CambiarPrecio(double precio)
    {
        if(precio < 0){
            throw new Exception("No puede ser el precio negativo");
        }else{
            this.precio = precio;
        }
        
    }
}