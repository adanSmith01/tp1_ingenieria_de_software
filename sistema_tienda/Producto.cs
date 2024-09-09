namespace Sistema_gestion;

public interface IProducto
{
    string Nombre { get; set;}
    double Precio { get; set;}
    string Categoria { get; set;}
    void ActualizarPrecio(double precio);
}

public class Producto: IProducto
{
    private string nombre;
    private double precio;
    private string categoria;

    public string Nombre {get => nombre; set => nombre = value;}
    public double Precio { get => precio; set => precio = value;}
    public string Categoria {get => categoria; set => categoria = value;}

    public Producto(string nombre, double precio, string categoria)
    {
        this.nombre = nombre;
        this.precio = precio;
        this.categoria = categoria;
    }

    public void ActualizarPrecio(double precio)
    {
        if(precio < 0){
            throw new Exception("No puede ser el precio negativo");
        }else{
            this.precio = precio;
        }
        
    }
}