namespace Store_inventory_system.BLL.Exceptions
{
    /// <summary>
    /// Thrown when a business rule is broken (bad input, duplicate product, not enough stock...).
    /// The UI can show the message directly to the user.
    /// </summary>
    public class InventoryException : Exception
    {
        public InventoryException(string message) : base(message) { }
    }
}
