namespace Lancheria.Domain.Validation
{
    public static class ProductOrderValidation
    {
        public static void ValidateProductId(int productId)
        {
            DomainExceptionValidation.When(productId < 0, "Invalid ProductId. ProductId can't be negative.");
        }

        public static void ValidateOrderId(int orderId)
        {
            DomainExceptionValidation.When(orderId < 0, "Invalid OrderId. OrderId can't be negative.");
        }

        public static void ValidateQuantity(int quantity)
        {
            DomainExceptionValidation.When(quantity < 0, "Invalid Quantity. Quantity can't be negative.");
        }
    }
}
