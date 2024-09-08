In .NET, an integration test typically focuses on testing how different components (classes, methods, etc.) work together in a system, rather than testing each in isolation. You can use mocks and fixtures to set up dependencies, but integration tests often avoid mocks in favor of testing actual interactions between real components. They can involve multiple assertions to verify that the components interact correctly.

Here’s a simple example of an integration test for a `Store` and `ShoppingCart` scenario, assuming you're using **xUnit**, **Moq**, and **fixtures**.

### Scenario
- **Store**: Manages a list of products and allows adding them to the cart.
- **Product**: Represents an item in the store.
- **ShoppingCart**: Holds products added by the user and calculates the total.

The integration test will check that adding products to the cart works correctly and that the total cart amount is calculated properly.

### Classes

#### `Product` class:

```csharp
public class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }

    public Product(string name, decimal price)
    {
        Name = name;
        Price = price;
    }
}
```

#### `ShoppingCart` class:

```csharp
public class ShoppingCart
{
    private List<Product> _products = new List<Product>();

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public decimal GetTotalAmount()
    {
        return _products.Sum(p => p.Price);
    }

    public List<Product> GetProducts()
    {
        return _products;
    }
}
```

#### `Store` class:

```csharp
public class Store
{
    public ShoppingCart ShoppingCart { get; private set; }

    public Store(ShoppingCart shoppingCart)
    {
        ShoppingCart = shoppingCart;
    }

    public void AddProductToCart(Product product)
    {
        ShoppingCart.AddProduct(product);
    }
}
```

### Fixture

The fixture is used to set up common objects (like `Store` and `ShoppingCart`) for the integration test.

```csharp
public class StoreFixture : IDisposable
{
    public Store Store { get; private set; }
    public ShoppingCart ShoppingCart { get; private set; }
    public Product Product1 { get; private set; }
    public Product Product2 { get; private set; }

    public StoreFixture()
    {
        // Create the common objects needed for tests
        ShoppingCart = new ShoppingCart();
        Store = new Store(ShoppingCart);

        Product1 = new Product("Laptop", 1000m);
        Product2 = new Product("Mouse", 50m);
    }

    public void Dispose()
    {
        // Clean up resources if necessary
    }
}
```

### Integration Test Example

The following test will:
1. Add products to the shopping cart using the `Store`.
2. Verify that the products are added correctly.
3. Check that the total amount is calculated correctly.

```csharp
public class StoreIntegrationTests : IClassFixture<StoreFixture>
{
    private readonly StoreFixture _fixture;

    public StoreIntegrationTests(StoreFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void Store_AddProductToCart_ShouldAddProductsCorrectlyAndCalculateTotal()
    {
        // Arrange: Store and ShoppingCart are provided by the fixture
        var store = _fixture.Store;
        var product1 = _fixture.Product1;
        var product2 = _fixture.Product2;

        // Act: Add products to the cart through the store
        store.AddProductToCart(product1);
        store.AddProductToCart(product2);

        // Assert: Check that products were added to the cart
        var cartProducts = store.ShoppingCart.GetProducts();
        Assert.Contains(product1, cartProducts);
        Assert.Contains(product2, cartProducts);

        // Assert: Check that the total amount in the cart is calculated correctly
        var totalAmount = store.ShoppingCart.GetTotalAmount();
        Assert.Equal(1050m, totalAmount); // 1000 + 50 = 1050
    }
}
```

### Key Points:
- **Multiple assertions**: This integration test asserts two things: that the products are added to the cart correctly, and that the total amount is calculated properly. Integration tests often have multiple assertions because they test the interaction between components.
- **Fixture**: The `StoreFixture` is used to provide shared setup logic across tests.
- **No Mocks**: This test uses actual instances of `Store`, `ShoppingCart`, and `Product`, which is typical for integration tests. You could mock external services (like APIs or databases) if needed, but here we're focusing on internal component integration.

This integration test ensures that the `Store` and `ShoppingCart` classes work together as expected when adding products and calculating totals.