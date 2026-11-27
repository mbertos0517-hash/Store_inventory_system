using System.Reflection;
using MySqlConnector;
using Store_inventory_system.DLL.Models;

namespace Store_inventory_system.DLL.Repositories
{
    /// <summary>
    /// Stores products in a MySQL database. Every change is written to the database
    /// immediately, so Save() has nothing left to do.
    /// </summary>
    public class MySqlProductRepository : IProductRepository
    {
        private const string SelectColumns = "Id, Name, Price, StockQuantity, ReorderLevel";

        private readonly string _connectionString;

        /// <param name="connectionString">
        /// e.g. "Server=localhost;Port=3306;Database=store_inventory;User ID=root;Password=...;"
        /// The database is created if it does not exist yet.
        /// </param>
        public MySqlProductRepository(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentException("Connection string is required.", nameof(connectionString));

            _connectionString = connectionString;
            EnsureDatabaseAndSchema();
        }

        public IReadOnlyList<Product> GetAll()
        {
            using var connection = Open();
            using var command = connection.CreateCommand();
            command.CommandText = $"SELECT {SelectColumns} FROM Products ORDER BY Id;";

            var products = new List<Product>();
            using var reader = command.ExecuteReader();
            while (reader.Read())
                products.Add(Map(reader));
            return products;
        }

        public Product? GetById(int id)
        {
            using var connection = Open();
            using var command = connection.CreateCommand();
            command.CommandText = $"SELECT {SelectColumns} FROM Products WHERE Id = @id;";
            command.Parameters.AddWithValue("@id", id);

            using var reader = command.ExecuteReader();
            return reader.Read() ? Map(reader) : null;
        }

        public Product? GetByName(string name)
        {
            using var connection = Open();
            using var command = connection.CreateCommand();
            // The table uses a case-insensitive collation, so this ignores letter case.
            command.CommandText = $"SELECT {SelectColumns} FROM Products WHERE Name = @name;";
            command.Parameters.AddWithValue("@name", name?.Trim() ?? string.Empty);

            using var reader = command.ExecuteReader();
            return reader.Read() ? Map(reader) : null;
        }

        public Product Add(Product product)
        {
            using var connection = Open();
            using var command = connection.CreateCommand();
            command.CommandText =
                "INSERT INTO Products (Name, Price, StockQuantity, ReorderLevel) " +
                "VALUES (@name, @price, @stock, @reorder);";
            command.Parameters.AddWithValue("@name", product.Name);
            command.Parameters.AddWithValue("@price", Math.Round(product.Price, 2));
            command.Parameters.AddWithValue("@stock", product.StockQuantity);
            command.Parameters.AddWithValue("@reorder", product.ReorderLevel);
            command.ExecuteNonQuery();

            return new Product
            {
                Id = Convert.ToInt32(command.LastInsertedId),
                Name = product.Name,
                Price = Math.Round(product.Price, 2),
                StockQuantity = product.StockQuantity,
                ReorderLevel = product.ReorderLevel
            };
        }

        public void Update(Product product)
        {
            using var connection = Open();
            using var command = connection.CreateCommand();
            command.CommandText =
                "UPDATE Products SET Name = @name, Price = @price, " +
                "StockQuantity = @stock, ReorderLevel = @reorder WHERE Id = @id;";
            command.Parameters.AddWithValue("@id", product.Id);
            command.Parameters.AddWithValue("@name", product.Name);
            command.Parameters.AddWithValue("@price", Math.Round(product.Price, 2));
            command.Parameters.AddWithValue("@stock", product.StockQuantity);
            command.Parameters.AddWithValue("@reorder", product.ReorderLevel);

            // Note: MySqlConnector reports "rows matched" by default, so saving identical values is fine.
            if (command.ExecuteNonQuery() == 0)
                throw new KeyNotFoundException($"Product with id {product.Id} was not found.");
        }

        public bool Delete(int id)
        {
            using var connection = Open();
            using var command = connection.CreateCommand();
            command.CommandText = "DELETE FROM Products WHERE Id = @id;";
            command.Parameters.AddWithValue("@id", id);
            return command.ExecuteNonQuery() > 0;
        }

        // Changes are already committed by each call above.
        public void Save() { }

        private MySqlConnection Open()
        {
            var connection = new MySqlConnection(_connectionString);
            connection.Open();
            return connection;
        }

        private void EnsureDatabaseAndSchema()
        {
            var builder = new MySqlConnectionStringBuilder(_connectionString);
            string database = builder.Database;
            if (string.IsNullOrWhiteSpace(database))
                throw new ArgumentException("The connection string must contain a Database name.");

            // 1) Create the database if needed (connect without selecting one).
            builder.Database = string.Empty;
            using (var serverConnection = new MySqlConnection(builder.ConnectionString))
            {
                serverConnection.Open();
                using var create = serverConnection.CreateCommand();
                create.CommandText =
                    $"CREATE DATABASE IF NOT EXISTS `{database.Replace("`", "``")}` CHARACTER SET utf8mb4;";
                create.ExecuteNonQuery();
            }

            // 2) Create the table and view if needed.
            using var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("schema.sql")
                ?? throw new InvalidOperationException("Embedded resource 'schema.sql' was not found.");
            using var script = new StreamReader(stream);

            using var connection = Open();
            using var command = connection.CreateCommand();
            command.CommandText = script.ReadToEnd();
            command.ExecuteNonQuery();
        }

        private static Product Map(MySqlDataReader reader) => new()
        {
            Id = reader.GetInt32(0),
            Name = reader.GetString(1),
            Price = reader.GetDecimal(2),
            StockQuantity = reader.GetInt32(3),
            ReorderLevel = reader.GetInt32(4)
        };
    }
}
