using KT.src;

class Program
{
    public interface IDiscountable
    {
        double ApplyDiscount(double price);
    }

    public class Product : IDiscountable
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public Product(string name, double price)
        {
            Name = name;
            Price = price;
        }

        public double ApplyDiscount(double discountPercentage)
        {
            double discountedPrice = Price - Price * discountPercentage / 100;
            Console.WriteLine($"Discount applied to {Name}: {discountedPrice:C}");
            return discountedPrice;
        }
    }
    public class Customer
    {
        public string Name { get; set; }
        public ShoppingCart Cart { get; set; }

        public Customer(string name)
        {
            Name = name;
            Cart = new ShoppingCart();
        }

        public void AddToCart(Product product)
        {
            Cart.AddProduct(product);
        }

        public double Checkout()
        {
            double total = Cart.CalculateTotal();
            Console.WriteLine($"Total amount to pay: {total:C}");
            return total;
        }
    }
    public class ShoppingCart
    {
        public List<Product> Products { get; set; }

        public ShoppingCart()
        {
            Products = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            Products.Add(product);
            Console.WriteLine($"{product.Name} added to the shopping cart.");
        }

        public double CalculateTotal()
        {
            double total = 0;
            foreach (Product product in Products)
            {
                total += product.Price;
            }
            return total;
        }
    }
    public class Store
    {
        public List<Product> AvailableProducts { get; set; }

        public Store()
        {
            AvailableProducts = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            AvailableProducts.Add(product);
            Console.WriteLine($"{product.Name} added to the store.");
        }
    }
    static void Main(string[] args)
    {
        Store store = new Store();

        Product product1 = new Product("Laptop", 999.99);
        Product product2 = new Product("Headphones", 49.99);

        store.AddProduct(product1);
        store.AddProduct(product2);

        Customer customer = new Customer("Alice");

        customer.AddToCart(product1);
        customer.AddToCart(product2);

        double totalAmount = customer.Checkout();

        // Applying discount
        double discountPercentage = 10;
        double discountedPrice = product1.ApplyDiscount(discountPercentage);
    }
}