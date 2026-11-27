using Store_inventory_system.DLL.Models;

namespace Store_inventory_system.BLL.Services
{
    public interface IInventoryService
    {
        IReadOnlyList<Product> GetAllProducts();
        Product GetProduct(int id);

        Product AddProduct(string name, decimal price, int stockQuantity, int reorderLevel = 10);
        Product UpdateProduct(int id, string newName, decimal newPrice);
        Product DeleteProduct(int id);

        Product StockIn(int id, int quantity);
        Product StockOut(int id, int quantity);

        IReadOnlyList<Product> GetLowStockProducts();
        void SaveChanges();
    }
}
