namespace PurchaseOrders
{
    public interface IInventoryService
    {
        void AddProduct(string productName, int initialQuantity);
        void UpdateInventory(string productName, int quantity);
        int GetProductQuantity(string productName);
    }
}
