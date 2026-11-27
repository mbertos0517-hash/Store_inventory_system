using Store_inventory_system.BLL.Exceptions;
using Store_inventory_system.BLL.Services;
using Store_inventory_system.DLL.Models;
using Store_inventory_system.DLL.Repositories;

namespace Store_inventory_system
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Connection string: set the STORE_INVENTORY_DB environment variable to override this default.
            // The database "store_inventory" is created automatically if it doesn't exist.
            string connectionString =
                Environment.GetEnvironmentVariable("STORE_INVENTORY_DB")
                ?? "Server=localhost;Port=3306;Database=store_inventory;User ID=root;Password=;";

            IInventoryService service;
            try
            {
                service = new InventoryService(new MySqlProductRepository(connectionString));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Could not connect to MySQL: " + ex.Message);
                Console.WriteLine("Check that the MySQL server is running and set the STORE_INVENTORY_DB");
                Console.WriteLine("environment variable to your connection string.");
                return;
            }

            bool running = true;
            while (running)
            {
                Console.WriteLine();
                Console.WriteLine("Store Inventory System");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. Update Product");
                Console.WriteLine("3. Stock in / Stock out");
                Console.WriteLine("4. Low stock report");
                Console.WriteLine("5. Delete Product");
                Console.WriteLine("6. Save and exit");

                int choice = ReadInt("Choose an option: ");

                try
                {
                    switch (choice)
                    {
                        case 1: AddProduct(service); break;
                        case 2: UpdateProduct(service); break;
                        case 3: ChangeStock(service); break;
                        case 4: LowStockReport(service); break;
                        case 5: DeleteProduct(service); break;
                        case 6:
                            service.SaveChanges();
                            Console.WriteLine("Saved. Goodbye!");
                            running = false;
                            break;
                        default:
                            Console.WriteLine("Invalid option.");
                            break;
                    }
                }
                catch (InventoryException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        static void AddProduct(IInventoryService service)
        {
            string name = ReadString("Enter name of the product: ");
            decimal price = ReadDecimal("Enter Value of product: ");
            int stock = ReadInt("Enter Stock Quantity: ");

            var product = service.AddProduct(name, price, stock);
            Console.WriteLine($"Added '{product.Name}' (id {product.Id}).");
        }

        static void UpdateProduct(IInventoryService service)
        {
            var product = ChooseProduct(service, "Choose a product You want to update:");
            if (product is null) return;

            string name = ReadString("rename the product: ");
            decimal price = ReadDecimal("change the value of the product: ");

            service.UpdateProduct(product.Id, name, price);
            Console.WriteLine("product successfully changed");
        }

        static void ChangeStock(IInventoryService service)
        {
            Console.WriteLine("stock quantity editor");
            Console.WriteLine("1. add");
            Console.WriteLine("2. remove");
            int action = ReadInt("Choose an option: ");

            if (action != 1 && action != 2)
            {
                Console.WriteLine("error");
                return;
            }

            string verb = action == 1 ? "add a stock" : "remove a stock";
            var product = ChooseProduct(service, $"Choose a product You want to {verb}:");
            if (product is null) return;

            int quantity = ReadInt("Enter quantity: ");

            var updated = action == 1
                ? service.StockIn(product.Id, quantity)
                : service.StockOut(product.Id, quantity);

            Console.WriteLine(action == 1 ? "added successfully" : "removed successfully");
            Console.WriteLine($"'{updated.Name}' now has {updated.StockQuantity} in stock.");
        }

        static void DeleteProduct(IInventoryService service)
        {
            var product = ChooseProduct(service, "Choose a product You want to delete:");
            if (product is null) return;

            Console.WriteLine($"Delete '{product.Name}' (stock: {product.StockQuantity})? This cannot be undone. (y/n)");
            string? answer = Console.ReadLine();
            if (!string.Equals(answer?.Trim(), "y", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Cancelled. Nothing was deleted.");
                return;
            }

            var deleted = service.DeleteProduct(product.Id);
            Console.WriteLine($"Deleted '{deleted.Name}'.");
        }

        static void LowStockReport(IInventoryService service)
        {
            var lowStock = service.GetLowStockProducts();
            Console.WriteLine("Low stock report");

            if (lowStock.Count == 0)
            {
                Console.WriteLine("All products are sufficiently stocked.");
                return;
            }

            foreach (var p in lowStock)
                Console.WriteLine($"{p.Id}. {p.Name} - stock: {p.StockQuantity} (reorder level: {p.ReorderLevel})");
        }

        // Shows the product list from the BLL and lets the user pick one by number.
        static Product? ChooseProduct(IInventoryService service, string prompt)
        {
            var products = service.GetAllProducts();
            if (products.Count == 0)
            {
                Console.WriteLine("No products yet. Add a product first.");
                return null;
            }

            Console.WriteLine(prompt);
            foreach (var p in products)
                Console.WriteLine($"{p.Id}. {p.Name} - {p.Price:0.00} (stock: {p.StockQuantity})");

            int id = ReadInt("Enter product number: ");
            return service.GetProduct(id); // throws InventoryException if the id doesn't exist
        }

        static string ReadString(string prompt)
        {
            Console.WriteLine(prompt);
            return Console.ReadLine() ?? string.Empty;
        }

        static int ReadInt(string prompt)
        {
            while (true)
            {
                Console.WriteLine(prompt);
                if (int.TryParse(Console.ReadLine(), out int value))
                    return value;
                Console.WriteLine("Please enter a whole number.");
            }
        }

        static decimal ReadDecimal(string prompt)
        {
            while (true)
            {
                Console.WriteLine(prompt);
                if (decimal.TryParse(Console.ReadLine(), out decimal value))
                    return value;
                Console.WriteLine("Please enter a valid number.");
            }
        }
    }
}
