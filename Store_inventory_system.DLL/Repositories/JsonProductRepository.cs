using System.Text.Json;
using Store_inventory_system.DLL.Models;

namespace Store_inventory_system.DLL.Repositories
{
    /// <summary>
    /// Keeps products in memory and reads/writes them to a JSON file.
    /// </summary>
    public class JsonProductRepository : IProductRepository
    {
        private static readonly JsonSerializerOptions JsonOptions = new() { WriteIndented = true };

        private readonly string _filePath;
        private readonly List<Product> _products;
        private int _nextId;

        public JsonProductRepository(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentException("File path is required.", nameof(filePath));

            _filePath = filePath;
            _products = Load();
            _nextId = _products.Count == 0 ? 1 : _products.Max(p => p.Id) + 1;
        }

        public IReadOnlyList<Product> GetAll() => _products.Select(Clone).ToList();

        public Product? GetById(int id)
        {
            var found = _products.FirstOrDefault(p => p.Id == id);
            return found is null ? null : Clone(found);
        }

        public Product? GetByName(string name)
        {
            var found = _products.FirstOrDefault(p =>
                string.Equals(p.Name, name?.Trim(), StringComparison.OrdinalIgnoreCase));
            return found is null ? null : Clone(found);
        }

        public Product Add(Product product)
        {
            var stored = Clone(product);
            stored.Id = _nextId++;
            _products.Add(stored);
            return Clone(stored);
        }

        public void Update(Product product)
        {
            var index = _products.FindIndex(p => p.Id == product.Id);
            if (index < 0)
                throw new KeyNotFoundException($"Product with id {product.Id} was not found.");

            _products[index] = Clone(product);
        }

        public bool Delete(int id) => _products.RemoveAll(p => p.Id == id) > 0;

        public void Save()
        {
            var directory = Path.GetDirectoryName(Path.GetFullPath(_filePath));
            if (!string.IsNullOrEmpty(directory))
                Directory.CreateDirectory(directory);

            // Write to a temp file first so a crash can't leave a half-written data file.
            var tempPath = _filePath + ".tmp";
            File.WriteAllText(tempPath, JsonSerializer.Serialize(_products, JsonOptions));
            File.Move(tempPath, _filePath, overwrite: true);
        }

        private List<Product> Load()
        {
            if (!File.Exists(_filePath))
                return new List<Product>();

            var json = File.ReadAllText(_filePath);
            if (string.IsNullOrWhiteSpace(json))
                return new List<Product>();

            return JsonSerializer.Deserialize<List<Product>>(json) ?? new List<Product>();
        }

        // Callers get copies so they can't change stored data without going through Update().
        private static Product Clone(Product p) => new()
        {
            Id = p.Id,
            Name = p.Name,
            Price = p.Price,
            StockQuantity = p.StockQuantity,
            ReorderLevel = p.ReorderLevel
        };
    }
}
