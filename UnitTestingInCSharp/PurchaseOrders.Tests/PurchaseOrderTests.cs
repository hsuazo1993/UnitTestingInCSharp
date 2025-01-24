namespace PurchaseOrders.Tests
{
    public class PurchaseOrderTests
    {
        [Fact]
        public void CalculateTotals_ShouldCalculateCorrectTotals()
        {
            // Arrange
            var purchaseOrder = new PurchaseOrder
            {
                Items = new List<OrderItem>
            {
                new OrderItem { ProductName = "Product A", Quantity = 2, UnitPrice = 10 },
                new OrderItem { ProductName = "Product B", Quantity = 1, UnitPrice = 15 }
            },
                Discount = 5
            };

            // Act
            purchaseOrder.CalculateTotals();

            // Assert
            Assert.Equal(35, purchaseOrder.Subtotal);
            Assert.Equal(5.25m, purchaseOrder.TaxAmount);
            Assert.Equal(35.25m, purchaseOrder.Total);
        }

        [Fact]
        public void CalculateTotals_ShouldCalculateCorrectTotals_WithDiscount()
        {
            // Arrange
            var purchaseOrder = new PurchaseOrder
            {
                Items = new List<OrderItem>
        {
            new OrderItem { ProductName = "Product A", Quantity = 2, UnitPrice = 10 },
            new OrderItem { ProductName = "Product B", Quantity = 1, UnitPrice = 15 }
        },
                Discount = 10 // Adding a discount
            };

            // Act
            purchaseOrder.CalculateTotals();

            // Assert
            Assert.Equal(35, purchaseOrder.Subtotal);
            Assert.Equal(5.25m, purchaseOrder.TaxAmount);
            Assert.Equal(30.25m, purchaseOrder.Total); // Total should reflect the discount
        }

        [Fact]
        public void CalculateTotals_ShouldCalculateCorrectTotals_WithZeroItems()
        {
            // Arrange
            var purchaseOrder = new PurchaseOrder(); // No items added

            // Act
            purchaseOrder.CalculateTotals();

            // Assert
            Assert.Equal(0, purchaseOrder.Subtotal);
            Assert.Equal(0, purchaseOrder.TaxAmount);
            Assert.Equal(0, purchaseOrder.Total);
        }

        [Fact]
        public void CalculateTotals_ShouldApplyTaxToSubtotal()
        {
            // Arrange
            var purchaseOrder = new PurchaseOrder
            {
                Items = new List<OrderItem>
        {
            new OrderItem { ProductName = "Product A", Quantity = 1, UnitPrice = 100 }
        },
                TaxRate = 0.07m // Set a specific tax rate
            };

            // Act
            purchaseOrder.CalculateTotals();

            // Assert
            Assert.Equal(100, purchaseOrder.Subtotal);
            Assert.Equal(7, purchaseOrder.TaxAmount); // Tax should be 7% of the subtotal
            Assert.Equal(107, purchaseOrder.Total);
        }
        // More tests to come...
    }
}
