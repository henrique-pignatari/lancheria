using Lancheria.Domain.Enums;

namespace Lancheria.Domain.Validation
{
    public static class OrderValidation
    {
        public static void ValidatePrice(decimal price)
        {
            DomainExceptionValidation.When(price < 0, "Invalid Purchase TotalPrice. TotalPrice can't be negative.");
        }

        public static void ValidateStatus(OrderStatus status)
        {
            var isDefined = Enum.IsDefined(typeof(OrderStatus), status);
            DomainExceptionValidation.When(!isDefined, "Invalid Order Status. Order Status is not defined.");
        }

        public static void ValidarePaymentMethod(PaymentMethod paymentMethod)
        {
            var isDefined = Enum.IsDefined(typeof(PaymentMethod), paymentMethod);
            DomainExceptionValidation.When(!isDefined, "Invalid Payment Method. Payment Method is not defined");
        }
    }
}
