using Store_inventory_system.DLL.Models;

namespace Store_inventory_system.DLL.Repositories
{
    /// <summary>
    /// Contract for storing and retrieving products.
    /// The BLL depends on this interface, so the storage (JSON file, SQL, ...) can be swapped.
    /// </summary>
    public interface IProductRepository
    {
        IReadOnlyList<Product> GetAll();
        Product? GetById(int id);
        Product? GetByName(string name);
        Product Add(Product product);
        void Update(Product product);
        bool Delete(int id);

        /// <summary>Persist all pending changes ("Save and exit").</summary>
        void Save();
    }
}
