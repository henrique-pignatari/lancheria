using Lancheria.Domain.Enums;
using Lancheria.Domain.Validation;
#pragma warning disable CS8618

namespace Lancheria.Domain.Entities
{
    public class Order : Entity
    {
        public DateTime PurchaseDate { get; private set; }
        public decimal TotalPrice { get; private set; }
        public OrderStatus Status { get; private set; }
        public PaymentMethod PaymentMethod { get; private set; }
        public IEnumerable<ProductOrder> ProductsOders { get; set; }

        public Order(int id, DateTime purchaseDate, decimal totalPrice, OrderStatus status, PaymentMethod paymentMethod) :
            this(purchaseDate, totalPrice, status, paymentMethod)
        {
            EntityValidation.ValidateId(id);
            Id = id;
        }

        public Order(DateTime purchaseDate, decimal totalPrice, OrderStatus status, PaymentMethod paymentMethod) : base()
        {
            ValidateDomain(totalPrice, status, paymentMethod);
            PurchaseDate = purchaseDate;
        }

        private void ValidateDomain(decimal totalPrice, OrderStatus status, PaymentMethod paymentMethod)
        {
            OrderValidation.ValidatePrice(totalPrice);
            OrderValidation.ValidateStatus(status);
            OrderValidation.ValidarePaymentMethod(paymentMethod);

            TotalPrice = totalPrice;
            Status = status;
            PaymentMethod = paymentMethod;
        }

        public void UpdateStatus(OrderStatus status)
        {
            ValidateDomain(TotalPrice, status, PaymentMethod);
        }

        public void UpdatePaymentMethod(PaymentMethod paymentMethod)
        {
            ValidateDomain(TotalPrice, Status, paymentMethod);
        }
    }
}
