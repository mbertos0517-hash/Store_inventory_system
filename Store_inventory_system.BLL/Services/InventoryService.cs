using Store_inventory_system.BLL.Exceptions;
using Store_inventory_system.DLL.Models;
using Store_inventory_system.DLL.Repositories;

namespace Store_inventory_system.BLL.Services
{
    /// <summary>
    /// All business rules for the store inventory live here.
    /// </summary>
    public class InventoryService : IInventoryService
    {
        private readonly IProductRepository _repository;

        public InventoryService(IProductRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public IReadOnlyList<Product> GetAllProducts() =>
            _repository.GetAll().OrderBy(p => p.Id).ToList();

        public Product GetProduct(int id) =>
            _repository.GetById(id) ?? throw new InventoryException($"Product with id {id} does not exist.");

        public Product AddProduct(string name, decimal price, int stockQuantity, int reorderLevel = 10)
        {
            name = ValidateName(name);
            ValidatePrice(price);
            if (stockQuantity < 0)
                throw new InventoryException("Stock quantity cannot be negative.");
            if (reorderLevel < 0)
                throw new InventoryException("Reorder level cannot be negative.");
            if (_repository.GetByName(name) is not null)
                throw new InventoryException($"A product named '{name}' already exists.");

            return _repository.Add(new Product
            {
                Name = name,
                Price = price,
                StockQuantity = stockQuantity,
                ReorderLevel = reorderLevel
            });
        }

        public Product UpdateProduct(int id, string newName, decimal newPrice)
        {
            var product = GetProduct(id);
            newName = ValidateName(newName);
            ValidatePrice(newPrice);

            var sameName = _repository.GetByName(newName);
            if (sameName is not null && sameName.Id != id)
                throw new InventoryException($"A product named '{newName}' already exists.");

            product.Name = newName;
            product.Price = newPrice;
            _repository.Update(product);
            return product;
        }

        /// <summary>Removes a product permanently and returns the product that was removed.</summary>
        public Product DeleteProduct(int id)
        {
            var product = GetProduct(id); // throws if the product doesn't exist

            if (!_repository.Delete(id))
                throw new InventoryException($"Product '{product.Name}' could not be deleted.");

            return product;
        }

        public Product StockIn(int id, int quantity)
        {
            if (quantity <= 0)
                throw new InventoryException("Quantity to add must be greater than zero.");

            var product = GetProduct(id);
            try
            {
                product.StockQuantity = checked(product.StockQuantity + quantity);
            }
            catch (OverflowException)
            {
                throw new InventoryException("Resulting stock quantity is too large.");
            }

            _repository.Update(product);
            return product;
        }

        public Product StockOut(int id, int quantity)
        {
            if (quantity <= 0)
                throw new InventoryException("Quantity to remove must be greater than zero.");

            var product = GetProduct(id);
            if (quantity > product.StockQuantity)
                throw new InventoryException(
                    $"Not enough stock for '{product.Name}'. Available: {product.StockQuantity}, requested: {quantity}.");

            product.StockQuantity -= quantity;
            _repository.Update(product);
            return product;
        }

        public IReadOnlyList<Product> GetLowStockProducts() =>
            _repository.GetAll()
                       .Where(p => p.StockQuantity <= p.ReorderLevel)
                       .OrderBy(p => p.StockQuantity)
                       .ToList();

        public void SaveChanges() => _repository.Save();

        private static string ValidateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new InventoryException("Product name is required.");
            return name.Trim();
        }

        private static void ValidatePrice(decimal price)
        {
            if (price < 0)
                throw new InventoryException("Price cannot be negative.");
        }
    }
}
