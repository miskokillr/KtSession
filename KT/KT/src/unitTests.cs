
using Xunit;
using static Program;


namespace KT.src

{
    public class unitTests
    {

        public class ProductTests
        {
            [Fact]
            public void Product_Constructor_NameAndPriceAreSet()
            {
                // Arrange
                string name = "Laptop";
                double price = 999.99;

                // Act
                Product product = new Product(name, price);

                // Assert
                Assert.Equal(name, product.Name);
                Assert.Equal(price, product.Price);
            }

            [Fact]
            public void ApplyDiscount_DiscountAppliedCorrectly()
            {
                // Arrange
                Product product = new Product("Laptop", 999.99);
                double discountPercentage = 10;

                // Act
                double discountedPrice = product.ApplyDiscount(discountPercentage);

                // Assert
                double expectedDiscountedPrice = 899.99;
                Assert.Equal(expectedDiscountedPrice, discountedPrice);
            }
        }

        public class ShoppingCartTests
        {
            [Fact]
            public void AddProduct_ProductAddedToCart()
            {
                // Arrange
                ShoppingCart cart = new ShoppingCart();
                Product product = new Product("Laptop", 999.99);

                // Act
                cart.AddProduct(product);

                // Assert
                Assert.Contains(product, cart.Products);
            }

            [Fact]
            public void CalculateTotal_TotalCalculatedCorrectly()
            {
                // Arrange
                ShoppingCart cart = new ShoppingCart();
                Product product1 = new Product("Laptop", 999.99);
                Product product2 = new Product("Headphones", 49.99);

                cart.AddProduct(product1);
                cart.AddProduct(product2);

                // Act
                double total = cart.CalculateTotal();

                // Assert
                double expectedTotal = 1049.98;
                Assert.Equal(expectedTotal, total);
            }
        }

        public class CustomerTests
        {
            [Fact]
            public void Constructor_NameIsSet()
            {
                // Arrange
                string name = "Alice";

                // Act
                Customer customer = new Customer(name);

                // Assert
                Assert.Equal(name, customer.Name);
            }

            [Fact]
            public void AddToCart_ProductAddedToCart()
            {
                // Arrange
                Customer customer = new Customer("Alice");
                Product product = new Product("Laptop", 999.99);

                // Act
                customer.AddToCart(product);

                // Assert
                Assert.Contains(product, customer.Cart.Products);
            }

            [Fact]
            public void Checkout_TotalAmountToPayCorrect()
            {
                // Arrange
                Customer customer = new Customer("Alice");
                Product product1 = new Product("Laptop", 999.99);
                Product product2 = new Product("Headphones", 49.99);

                customer.AddToCart(product1);
                customer.AddToCart(product2);

                // Act
                double totalAmount = customer.Checkout();

                // Assert
                double expectedTotalAmount = 1049.98;
                Assert.Equal(expectedTotalAmount, totalAmount);
            }
        }

        public class StoreTests
        {
            [Fact]
            public void AddProduct_ProductAddedToStore()
            {
                // Arrange
                Store store = new Store();
                Product product = new Product("Laptop", 999.99);

                // Act
                store.AddProduct(product);

                // Assert
                Assert.Contains(product, store.AvailableProducts);
            }
        }
    }
}