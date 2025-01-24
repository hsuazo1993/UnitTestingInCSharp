using FluentAssertions;

namespace PurchaseOrders.Tests
{
    // Examples of using FluentAssertions
    public class InventoryServiceTests
    {
        [Fact]
        public void AddProduct_ShouldAddProductToInventory()
        {
            // Arrange
            var inventoryService = new InventoryService();
            string productName = "Product A";
            int initialQuantity = 10;

            // Act
            inventoryService.AddProduct(productName, initialQuantity);

            // Assert
            inventoryService.GetProductQuantity(productName).Should().Be(initialQuantity);
        }

        [Fact]
        public void AddProduct_ShouldThrowException_WhenProductAlreadyExists()
        {
            // Arrange
            var inventoryService = new InventoryService();
            string productName = "Product A";
            int initialQuantity = 10;
            inventoryService.AddProduct(productName, initialQuantity);

            // Act & Assert
            Action act = () => inventoryService.AddProduct(productName, 5);
            act.Should().Throw<ArgumentException>().WithMessage($"Product '{productName}' already exists in inventory.");
        }

        [Fact]
        public void UpdateInventory_ShouldUpdateProductQuantity()
        {
            // Arrange
            var inventoryService = new InventoryService();
            string productName = "Product A";
            int initialQuantity = 10;
            inventoryService.AddProduct(productName, initialQuantity);

            // Act
            inventoryService.UpdateInventory(productName, 5); // Add 5 to quantity

            // Assert
            inventoryService.GetProductQuantity(productName).Should().Be(15);
        }

        [Fact]
        public void UpdateInventory_ShouldThrowException_WhenProductNotFound()
        {
            // Arrange
            var inventoryService = new InventoryService();
            string productName = "Product A";

            // Act & Assert
            Action act = () => inventoryService.UpdateInventory(productName, 5);
            act.Should().Throw<ArgumentException>().WithMessage($"Product '{productName}' not found in inventory.");
        }

        [Fact]
        public void GetProductQuantity_ShouldReturnCorrectQuantity()
        {
            // Arrange
            var inventoryService = new InventoryService();
            string productName = "Product A";
            int initialQuantity = 10;
            inventoryService.AddProduct(productName, initialQuantity);

            // Act
            int quantity = inventoryService.GetProductQuantity(productName);

            // Assert
            quantity.Should().Be(initialQuantity);
        }

        [Fact]
        public void GetProductQuantity_ShouldThrowException_WhenProductNotFound()
        {
            // Arrange
            var inventoryService = new InventoryService();
            string productName = "Product A";

            // Act & Assert
            Action act = () => inventoryService.GetProductQuantity(productName);
            act.Should().Throw<ArgumentException>().WithMessage($"Product '{productName}' not found in inventory.");
        }
    }
}
