namespace PurchaseOrders
{
    public class InventoryService : IInventoryService
    {
        private readonly Dictionary<string, int> _inventory = new Dictionary<string, int>();

        public void AddProduct(string productName, int initialQuantity)
        {
            if (_inventory.ContainsKey(productName))
            {
                throw new ArgumentException($"Product '{productName}' already exists in inventory.");
            }
            _inventory[productName] = initialQuantity;
        }

        public void UpdateInventory(string productName, int quantityChange)
        {
            if (!_inventory.ContainsKey(productName))
            {
                throw new ArgumentException($"Product '{productName}' not found in inventory.");
            }
            _inventory[productName] += quantityChange;
        }

        public int GetProductQuantity(string productName)
        {
            if (!_inventory.ContainsKey(productName))
            {
                throw new ArgumentException($"Product '{productName}' not found in inventory.");
            }
            return _inventory[productName];
        }
    }
}
