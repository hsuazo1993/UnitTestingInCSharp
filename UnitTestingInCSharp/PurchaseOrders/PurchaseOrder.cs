namespace PurchaseOrders
{
    public class PurchaseOrder
    {
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();
        public decimal Subtotal { get; private set; }
        public decimal TaxRate { get; set; } = 0.15m; // Default tax rate 15%
        public decimal TaxAmount { get; private set; }
        public decimal Discount { get; set; }
        public decimal Total { get; private set; }

        public void CalculateTotals()
        {
            Subtotal = Items.Sum(item => item.Quantity * item.UnitPrice);
            TaxAmount = Subtotal * TaxRate;
            Total = Subtotal + TaxAmount - Discount;
        }
    }

    public class OrderItem
    {
        public string ProductName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
