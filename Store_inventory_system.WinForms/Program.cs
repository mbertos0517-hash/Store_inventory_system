using Store_inventory_system.BLL.Services;
using Store_inventory_system.DLL.Repositories;

namespace Store_inventory_system.WinForms
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // Set the STORE_INVENTORY_DB environment variable to override this default.
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
                MessageBox.Show(
                    "Could not connect to MySQL:\n\n" + ex.Message +
                    "\n\nCheck that the MySQL server is running and, if needed, set the " +
                    "STORE_INVENTORY_DB environment variable to your connection string.",
                    "Store Inventory System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Application.Run(new MainForm(service));
        }
    }
}
