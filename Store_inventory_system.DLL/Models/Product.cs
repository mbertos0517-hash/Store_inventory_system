namespace Store_inventory_system.DLL.Models
{
    /// <summary>
    /// A product stored in the inventory.
    /// </summary>
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }

        /// <summary>
        /// When StockQuantity is at or below this number the product counts as "low stock".
        /// </summary>
        public int ReorderLevel { get; set; } = 10;
    }
}
