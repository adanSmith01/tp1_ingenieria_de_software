namespace tests;

using Moq;
using Sistema_gestion;
using Xunit;

public class TestTienda:IClassFixture<ProductoFixture>
{
    private ProductoFixture fixture;
    public TestTienda(ProductoFixture fixture)
    {
        this.fixture = fixture;
    }

    [Fact]
    public void AgregarProductoNoExistente()
    {
        var mockProducto = new Mock<IProducto>();
        mockProducto.Setup(p => p.Nombre).Returns("prod-11");
        mockProducto.Setup(p => p.Precio).Returns(1000);
        mockProducto.Setup(p => p.Categoria).Returns("cat-11");

        var tienda = new Tienda(fixture.productosPrueba);
        
        var cant_ant = tienda.Inventario.Count;

        tienda.AgregarProducto(mockProducto.Object);

        var cant_act = tienda.Inventario.Count;
        Assert.Equal(cant_ant+1, cant_act);
    }


    [Fact]
    public void AgregarProductoExistente()
    {
        var mockProducto = new Mock<IProducto>();

        var tienda = new Tienda(fixture.productosPrueba);
        
        mockProducto.Setup(p => p.Nombre).Returns("prod-1");
        mockProducto.Setup(p => p.Precio).Returns(1000);
        mockProducto.Setup(p => p.Categoria).Returns("cat-1");

        var cant_ant = tienda.Inventario.Count;
        tienda.AgregarProducto(mockProducto.Object);
        var cant_act = tienda.Inventario.Count;

        Assert.Equal(cant_ant, cant_act);
    }


    [Fact]
    public void BuscarProductoExistente()
    {
        var mockProducto = new Mock<IProducto>();
        mockProducto.Setup(p => p.Nombre).Returns("prod-11");
        mockProducto.Setup(p => p.Precio).Returns(1000);
        mockProducto.Setup(p => p.Categoria).Returns("cat-11");

        var tienda = new Tienda(fixture.productosPrueba);
        

        tienda.AgregarProducto(mockProducto.Object);

        var resultado = tienda.BuscarProducto("prod-11");

        Assert.NotNull(resultado);
    }

    [Fact]
    public void BuscarProductoNoExistente()
    {
        var tienda = new Tienda(fixture.productosPrueba);
        
        Assert.Throws<Exception>(()=>{tienda.BuscarProducto("prod-11");});
    }

    [Fact]
    public void EliminarProductoExistente()
    {
        var mockProducto = new Mock<IProducto>();
        mockProducto.Setup(p => p.Nombre).Returns("prod-11");
        mockProducto.Setup(p => p.Precio).Returns(1000);
        mockProducto.Setup(p => p.Categoria).Returns("cat-11");

        var tienda = new Tienda(fixture.productosPrueba);

        tienda.AgregarProducto(mockProducto.Object);

        var resultado = tienda.EliminarProducto("prod-11");

        Assert.True(resultado);
    }
    
    [Fact]
    public void EliminarProductoNoExistente()
    {
        var mocksProductoRepositorio = new Mock<IProducto>();
        var tienda = new Tienda(fixture.productosPrueba);

        Assert.Throws<Exception>(()=>{tienda.EliminarProducto("producto-1");});
    }

    [Fact]
    public void AplicarDescuentoCorrespondiente()
    {
        var mockProducto = new Mock<IProducto>();
        var tienda = new Tienda(fixture.productosPrueba);
        mockProducto.Setup(p => p.Nombre).Returns("prod-11");
        mockProducto.Setup(p => p.Precio).Returns(1000);
        mockProducto.Setup(p => p.Categoria).Returns("cat-11");
        mockProducto.Setup(p => p.ActualizarPrecio(It.IsAny<double>())).Callback<double>(nuevoPrecio => {
            mockProducto.Setup(p => p.Precio).Returns(nuevoPrecio);
        });
        tienda.AgregarProducto(mockProducto.Object);
        tienda.AplicarDescuento("prod-11", 10);

        Assert.Equal(900, tienda.BuscarProducto("prod-11").Precio);
    }

    private List<IProducto> GenerarCarritoDeProductos(List<string> nombresProductos, Tienda tienda)
    {
        var porcDescuento = 10;
        var carrito = new List<IProducto>();

        foreach(var nombProd in nombresProductos)
        {
            try
            {
                var producto = tienda.BuscarProducto(nombProd);
                tienda.AplicarDescuento(producto.Nombre, porcDescuento);
                carrito.Add(producto);
            }
            catch(Exception)
            {
                continue;
            }
            
        }

        return carrito;
    }

    [Fact]
    public void CalcularTotalCarritoDeProductosEnlistadosQueEstanEnElInventario()
    {
        var tienda = new Tienda(fixture.productosPrueba);

        var carrito = GenerarCarritoDeProductos(new List<string>{"prod-1", "prod-2", "prod-3", "prod-4"}, tienda);

        var totalCarrito = tienda.CalcularTotalCarrito(carrito);
        Assert.Equal(9000, totalCarrito);
    }

    [Fact]
    public void CalcularTotalCarritoDeAlgunosProductosEnlistadosQueEstanEnElInventario()
    {
        var tienda = new Tienda(fixture.productosPrueba);

        var carrito = GenerarCarritoDeProductos(new List<string>{"prod-1", "prod-12", "prod-3", "prod-14"}, tienda);

        var totalCarrito = tienda.CalcularTotalCarrito(carrito);
        Assert.Equal(3600, totalCarrito);
    }

    [Fact]
    public void CalcularTotalCarritoDeProductosEnlistadosQueNoEstanEnElInventario()
    {
        var tienda = new Tienda(fixture.productosPrueba);

        var carrito = GenerarCarritoDeProductos(new List<string>{"prod-11", "prod-12", "prod-13", "prod-14"}, tienda);

        var totalCarrito = tienda.CalcularTotalCarrito(carrito);
        Assert.Equal(0, totalCarrito);
    }
}
