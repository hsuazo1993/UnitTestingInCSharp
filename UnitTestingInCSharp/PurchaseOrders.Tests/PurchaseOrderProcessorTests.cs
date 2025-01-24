using Moq;

namespace PurchaseOrders.Tests
{
    public class PurchaseOrderProcessorTests
    {
        [Fact]
        public void Process_ShouldThrowException_WhenPurchaseOrderIsNull()
        {
            // Arrange
            var inventoryServiceMock = new Mock<IInventoryService>();
            var notificationServiceMock = new Mock<INotificationService>();
            var processor = new PurchaseOrderProcessor(inventoryServiceMock.Object, notificationServiceMock.Object);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => processor.Process(null));
        }

        [Fact]
        public void Process_ShouldThrowException_WhenPurchaseOrderHasNoItems()
        {
            // Arrange
            var inventoryServiceMock = new Mock<IInventoryService>();
            var notificationServiceMock = new Mock<INotificationService>();
            var processor = new PurchaseOrderProcessor(inventoryServiceMock.Object, notificationServiceMock.Object);
            var purchaseOrder = new PurchaseOrder(); // Empty purchase order

            // Act & Assert
            Assert.Throws<ArgumentException>(() => processor.Process(purchaseOrder));
        }

        [Fact]
        public void Process_ShouldUpdateInventory_ForEachItem()
        {
            // Arrange
            var inventoryServiceMock = new Mock<IInventoryService>();
            var notificationServiceMock = new Mock<INotificationService>();
            var processor = new PurchaseOrderProcessor(inventoryServiceMock.Object, notificationServiceMock.Object);
            var purchaseOrder = new PurchaseOrder
            {
                Items = new List<OrderItem>
            {
                new OrderItem { ProductName = "Product A", Quantity = 2 },
                new OrderItem { ProductName = "Product B", Quantity = 1 }
            }
            };

            // Act
            processor.Process(purchaseOrder);

            // Assert
            inventoryServiceMock.Verify(mock => mock.UpdateInventory("Product A", 2), Times.Once);
            inventoryServiceMock.Verify(mock => mock.UpdateInventory("Product B", 1), Times.Once);
        }

        [Fact]
        public void Process_ShouldSendNotification_OnSuccessfulProcessing()
        {
            // Arrange
            var inventoryServiceMock = new Mock<IInventoryService>();
            var notificationServiceMock = new Mock<INotificationService>();
            var processor = new PurchaseOrderProcessor(inventoryServiceMock.Object, notificationServiceMock.Object);
            var purchaseOrder = new PurchaseOrder
            {
                Items = new List<OrderItem>
            {
                new OrderItem { ProductName = "Product A", Quantity = 1 }
            }
            };

            // Act
            processor.Process(purchaseOrder);

            // Assert
            notificationServiceMock.Verify(mock => mock.SendNotification("Purchase order processed successfully!", "admin@example.com"), Times.Once);
        }
    }
}
