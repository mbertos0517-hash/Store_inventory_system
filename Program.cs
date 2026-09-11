using System.ComponentModel.Design;

namespace Store_inventory_system
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Store Inventory System");
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. Update Product");
            Console.WriteLine("3. Stock in / Stock out");
            Console.WriteLine("4. Low stock report");
            Console.WriteLine("5. Save and exit");
            int inventory = Convert.ToInt16(Console.ReadLine());


            switch (inventory)
            {
                case 1:
                    Console.WriteLine("Enter name of the product: ");
                    string product = Console.ReadLine();
                    Console.WriteLine("Enter Value of product: ");
                    int value = Convert.ToInt16(Console.ReadLine());
                    Console.WriteLine("Enter Stock Quantity: ");
                    int stock = Convert.ToInt16(Console.ReadLine());
                    break;

                case 2:
                    Console.WriteLine("Choose a product You want to update:");
                    Console.WriteLine("1. Shampoo");
                    Console.WriteLine("2. Biscuits");
                    Console.WriteLine("3. Canned Foods");
                    int Stock_inventory = Convert.ToInt16(Console.ReadLine());

                    if (Stock_inventory == 1)
                    {
                        Console.WriteLine("rename the product: ");
                        string name = Console.ReadLine();
                        Console.WriteLine("change the value of the product: ");
                        int Stockvalue = Convert.ToInt16((string)Console.ReadLine());
                        Console.WriteLine("product successfully changed");
                    }
                    if (Stock_inventory == 2)
                    {
                        Console.WriteLine("rename the product: ");
                        string name = Console.ReadLine();
                        Console.WriteLine("change the value of the product: ");
                        int Stockvalue = Convert.ToInt16((string)Console.ReadLine());
                        Console.WriteLine("product successfully changed");
                    }
                    else
                    {
                        Console.WriteLine("rename the product: ");
                        string name = Console.ReadLine();
                        Console.WriteLine("change the value of the product: ");
                        int Stockvalue = Convert.ToInt16((string)Console.ReadLine());
                        Console.WriteLine("product successfully changed");
                    }
                    break;
                case 3:
                    Console.WriteLine("stock quantity editor");
                    Console.WriteLine("1. add");
                    Console.WriteLine("2. remove");
                    int stockquantity = Convert.ToInt16((string)Console.ReadLine());

                    if (stockquantity == 1)
                    {
                        Console.WriteLine("Choose a product You want to add a stock:");
                        Console.WriteLine("1. Shampoo");
                        Console.WriteLine("2. Biscuits");
                        Console.WriteLine("3. Canned Foods");
                        int Stockunitquantity = Convert.ToInt16(Console.ReadLine());
                        Console.WriteLine("added successfully");


                    }
                    if (stockquantity == 2)
                    {
                        Console.WriteLine("Choose a product You want to remove a stock:");
                        Console.WriteLine("1. Shampoo");
                        Console.WriteLine("2. Biscuits");
                        Console.WriteLine("3. Canned Foods");
                        int Stockunitquantity = Convert.ToInt16(Console.ReadLine());
                        Console.WriteLine("added successfully");
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                    break;
            }
        }
    }
}