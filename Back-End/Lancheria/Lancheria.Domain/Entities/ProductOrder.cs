using Lancheria.Domain.Validation;
#pragma warning disable CS8618

namespace Lancheria.Domain.Entities
{
    public class ProductOrder : Entity
    {
        public int ProductId { get; private set; }
        public Product Product { get; set; }
        public int OrderId { get; private set; }
        public Order Order { get; set; }
        public int Quantity { get; private set; }

        public ProductOrder(int id, int productId, int orderId, int quantity) : this(productId, orderId, quantity)
        {
            EntityValidation.ValidateId(id);
            Id = id;
        }

        public ProductOrder(int productId, int orderId, int quantity) : base()
        {
            ValidateDomain(productId, orderId, quantity);
        }

        private void ValidateDomain(int productId, int orderId, int quantity)
        {
            ProductOrderValidation.ValidateProductId(productId);
            ProductOrderValidation.ValidateOrderId(orderId);
            ProductOrderValidation.ValidateQuantity(quantity);

            ProductId = productId;
            OrderId = orderId;
            Quantity = quantity;
        }

        public void Update(int qunatity)
        {
            ValidateDomain(ProductId, OrderId, qunatity);
        }
    }
}
