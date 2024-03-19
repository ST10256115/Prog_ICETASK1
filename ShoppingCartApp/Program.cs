public enum ProductCategory
{
    Clothing,
    Electronics,
    Home,
    Beauty,
    Groceries
}


namespace ShoppingCartApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new shopping cart
            ShoppingCart cart = new ShoppingCart(5);

            // Adding products to the shopping cart
            AddProductToCart(cart);

            // Displaying products in the shopping cart
            DisplayShoppingCart(cart);
        }

        static void AddProductToCart(ShoppingCart cart)
        {
            Console.WriteLine("Adding products to the shopping cart:");

            while (true)
            {
                Console.WriteLine("Enter product details (name, price, category):");
                string[] productDetails = Console.ReadLine().Split(',');
                if (productDetails.Length != 3)
                {
                    Console.WriteLine("Invalid input. Please try again.");
                    continue;
                }

                string name = productDetails[0].Trim();
                if (!double.TryParse(productDetails[1].Trim(), out double price))
                {
                    Console.WriteLine("Invalid price. Please try again.");
                    continue;
                }

                if (!Enum.TryParse(productDetails[2].Trim(), out ProductCategory category))
                {
                    Console.WriteLine("Invalid category. Please try again.");
                    continue;
                }

                // Create product based on category
                Product product;
                if (category == ProductCategory.Clothing)
                {
                    Console.WriteLine("Enter size:");
                    string size = Console.ReadLine().Trim();
                    Console.WriteLine("Enter color:");
                    string color = Console.ReadLine().Trim();
                    product = new ClothingProduct(name, price, category, size, color);
                }
                else if (category == ProductCategory.Electronics)
                {
                    Console.WriteLine("Enter brand:");
                    string brand = Console.ReadLine().Trim();
                    Console.WriteLine("Enter model:");
                    string model = Console.ReadLine().Trim();
                    product = new ElectronicsProduct(name, price, category, brand, model);
                }
                else
                {
                    product = new Product(name, price, category);
                }

                // Add product to cart
                cart.AddProduct(product);

                Console.WriteLine("Product added to cart. Do you want to add another product? (yes/no)");
                string choice = Console.ReadLine().ToLower().Trim();
                if (choice != "yes")
                    break;
            }
        }

        static void DisplayShoppingCart(ShoppingCart cart)
        {
            Console.WriteLine("\nProducts in the shopping cart:");
            foreach (Product product in cart.GetProducts())
            {
                if (product != null)
                {
                    product.GetInfo();
                }
            }
        }
    }
}
