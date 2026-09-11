namespace Store_inventory_system
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Store Inventory System");
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. View All Product");
            Console.WriteLine("3. Update Product");
            Console.WriteLine("4. Delete Product");
            Console.WriteLine("5. Search product");
            Console.WriteLine("6. Stock in / Stock out");
            Console.WriteLine("7. Low stock report");
            Console.WriteLine("8. Save and exit");
            int inventory = Convert.ToInt16(Console.ReadLine());



            switch(inventory)
            {
                case 1:
                    Console.WriteLine("Enter name of the product: ");
                    string product = Console.ReadLine();
                    Console.WriteLine("Enter Value of product: ");
                    int value = Convert.ToInt16(Console.ReadLine());
                    Console.WriteLine("Enter Stock Quantity");
                    int stock = Convert.ToInt16(Console.ReadLine());
                    break;




            }














        }
    }
}
