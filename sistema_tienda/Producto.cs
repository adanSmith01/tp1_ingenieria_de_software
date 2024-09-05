namespace Sistema_gestion;

public class Producto
{
    public string Nombre { get; set;}
    public double Precio { get; set;}
    public string Categoria { get; set;}

    public void CambiarPrecio(double precio)
    {
        if(precio < 0){
            throw new Exception("No puede ser el precio negativo");
        }else{
            this.Precio = precio;
        }
        
    }
}