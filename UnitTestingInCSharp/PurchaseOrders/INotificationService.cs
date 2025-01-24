namespace PurchaseOrders
{
    public interface INotificationService
    {
        void SendNotification(string message, string recipient);
    }
}
