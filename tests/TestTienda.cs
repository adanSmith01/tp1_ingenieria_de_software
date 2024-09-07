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
        var mocksProductoRepositorio = new Mock<IProductoRepositorio>();
        var tienda = new Tienda(mocksProductoRepositorio.Object);
        var producto = fixture.productoPrueba;
        var cant_ant = tienda.Inventario.Count;

        tienda.AgregarProducto(producto);

        var cant_act = tienda.Inventario.Count;

        Assert.Equal<int>(cant_ant+1, cant_act);
    }


    [Fact]
    public void AgregarProductoExistente()
    {
        var mocksProductoRepositorio = new Mock<IProductoRepositorio>();
        var tienda = new Tienda(mocksProductoRepositorio.Object);
        var producto = fixture.productoPrueba;
        var producto_1 = fixture.productoPrueba;

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
        var producto = fixture.productoPrueba;

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
        var producto = fixture.productoPrueba;

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
        Producto producto = fixture.productoPrueba;
        
        mocksProductoRepositorio.Setup(repo => repo.BuscarProducto("Laptop")).Returns(producto);

        Tienda tienda = new Tienda(mocksProductoRepositorio.Object);

        // Act
        tienda.AplicarDescuento("Laptop", 10); // Applying 10% discount

        // Assert
        Assert.Equal(900, producto.Precio); // The price should be 1000 - 10% = 900
        mocksProductoRepositorio.Verify(repo => repo.ActualizarProducto(It.IsAny<Producto>()), Times.Once);
        /* This line is using Moq to verify that a specific method, ActualizarProducto, was called on the mock object (mocksProductoRepositorio) during the execution of the test. */
    }
}
