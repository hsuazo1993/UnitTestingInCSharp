namespace PurchaseOrders
{
    public class PurchaseOrderProcessor
    {
        private readonly IInventoryService _inventoryService;
        private readonly INotificationService _notificationService;

        public PurchaseOrderProcessor(IInventoryService inventoryService, INotificationService notificationService)
        {
            _inventoryService = inventoryService;
            _notificationService = notificationService;
        }

        public void Process(PurchaseOrder purchaseOrder)
        {
            // 1. Validate the purchase order
            if (purchaseOrder == null || purchaseOrder.Items.Count == 0)
            {
                throw new ArgumentException("Invalid purchase order.");
            }

            // 2. Update inventory
            foreach (var item in purchaseOrder.Items)
            {
                _inventoryService.UpdateInventory(item.ProductName, item.Quantity);
            }

            // 3. Send notification
            _notificationService.SendNotification("Purchase order processed successfully!", "admin@example.com");
        }
    }
}
