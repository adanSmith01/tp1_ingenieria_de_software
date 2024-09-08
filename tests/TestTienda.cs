namespace tests;
using Moq;
using Sistema_gestion;
using Xunit;

public class TestTienda:IClassFixture<TiendaFixture>
{
    private TiendaFixture fixture;
    public TestTienda(TiendaFixture fixture)
    {
        this.fixture = fixture;
    }

    [Fact]
    public void AgregarProductoNoExistente()
    {
        var mockProducto = new Mock<IProducto>();
        mockProducto.Setup(p => p.Nombre()).Returns("prod-11");
        mockProducto.Setup(p => p.Precio()).Returns(1000);
        mockProducto.Setup(p => p.Categoria()).Returns("cat-11");

        var tienda = new Tienda(fixture.productosPrueba);
        var cant_ant = tienda.Inventario.Count;

        tienda.AgregarProducto(mockProducto.Object);

        var cant_act = tienda.Inventario.Count;

        Assert.Equal<int>(cant_ant+1, cant_act);
    }


    /*[Fact]
    public void AgregarProductoExistente()
    {
        var mocksProductoRepositorio = new Mock<IProductoRepositorio>();
        var tienda = new Tienda(mocksProductoRepositorio.Object);
        var producto = fixture.productosPrueba[0];
        var producto_1 = fixture.productosPrueba[0];

        tienda.AgregarProducto(producto);

        var cant_ant = tienda.Inventario.Count;

        tienda.AgregarProducto(producto_1);

        var cant_act = tienda.Inventario.Count;

        Assert.Equal<int>(cant_ant, cant_act);
    }


    [Fact]
    public void BuscarProductoExistente()
    {
        var mocksProductoRepositorio = new Mock<IProductoRepositorio>();
        var tienda = new Tienda(mocksProductoRepositorio.Object);
        var producto = fixture.productosPrueba[0];

        tienda.AgregarProducto(producto);

        var resultado = tienda.BuscarProducto(producto.Nombre);

        Assert.NotNull(resultado);
    }

    [Fact]
    public void BuscarProductoNoExistente()
    {
        var mocksProductoRepositorio = new Mock<IProductoRepositorio>();
        var tienda = new Tienda(mocksProductoRepositorio.Object);
        
        Assert.Throws<Exception>(()=>{tienda.BuscarProducto("producto-1");});
    }

    [Fact]
    public void EliminarProductoExistente()
    {
        var mocksProductoRepositorio = new Mock<IProductoRepositorio>();
        var tienda = new Tienda(mocksProductoRepositorio.Object);
        var producto = fixture.productosPrueba[0];

        tienda.AgregarProducto(producto);

        var resultado = tienda.EliminarProducto("prod-1");

        Assert.True(resultado);
    }
    
    [Fact]
    public void EliminarProductoNoExistente()
    {
        var mocksProductoRepositorio = new Mock<IProductoRepositorio>();
        var tienda = new Tienda(mocksProductoRepositorio.Object);

        Assert.Throws<Exception>(()=>{tienda.EliminarProducto("producto-1");});
    }

    [Fact]
    public void AplicarDescuentoCorrespondiente()
    {
        // Arrange
        Mock<IProductoRepositorio> mocksProductoRepositorio = new Mock<IProductoRepositorio>();
        Producto producto = fixture.productosPrueba[0];
        mocksProductoRepositorio.Setup(repo => repo.BuscarProducto("prod-1")).Returns(producto);

        Tienda tienda = new Tienda(mocksProductoRepositorio.Object);

        // Act
        tienda.AplicarDescuento("prod-1", 10); // Applying 10% discount

        // Assert
        Assert.Equal(900, producto.Precio); // The price should be 1000 - 10% = 900
        /* This line is using Moq to verify that a specific method, ActualizarProducto, was called on the mock object (mocksProductoRepositorio) during the execution of the test. */
    //}

    //[Fact]
    /*public void CalcularTotalCarrito_Test1()
    {
        var mockProductoRepositorio = new Mock<IProductoRepositorio>();
        mockProductoRepositorio.Setup(repo => repo.ObtenerInventario()).Returns(fixture.productosPrueba);

        var tienda = new Tienda(mockProductoRepositorio.Object);
        var carrito = new List<string>{}
    }*/
}
