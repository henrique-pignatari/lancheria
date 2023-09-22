using FluentAssertions;
using Lancheria.Domain.Entities;
using Lancheria.Domain.Enums;
using Lancheria.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lancheria.Domain.Tests
{
    public class OrderUnitTests
    {
        [Fact(DisplayName = "Create Order With Valid State")]
        public void CreateOrder_WithValidParameters_ValidObjectState()
        {
            Action action = () => new Order(1, new DateTime(), 1.0m, OrderStatus.Completed, PaymentMethod.Cash);

            action.Should()
                .NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Can't Create Order With Negative Id")]
        public void CreateOrder_WithNegativeId_DomainException()
        {
            Action action = () => new Order(-1, new DateTime(), 1.0m, OrderStatus.Completed, PaymentMethod.Cash);
        
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Id. Id can't be negative.");
        }

        [Fact(DisplayName = "Can't Create Order WIth Negative price")]
        public void CreateOrder_WithNegativePrice_DoamainException()
        {
            Action action = () => new Order(1, new DateTime(), -1.0m, OrderStatus.Completed, PaymentMethod.Cash);

            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Purchase TotalPrice. TotalPrice can't be negative.");
        }

        public static IEnumerable<object[]> Order_InvalidOrderStatus_TestData()
        {
            var maxIndex = Enum.GetValues<OrderStatus>().Length;
            yield return new object[] { maxIndex };
        }

        [Theory(DisplayName = "Can't Create Order With Invalid Status")]
        [InlineData(-1)]
        [MemberData(nameof(Order_InvalidOrderStatus_TestData))]
        public void CreateOrder_WithInvalidStatus_DomainException(int statusIndex)
        {
            var status = (OrderStatus)statusIndex;

            Action action = () => new Order(1, new DateTime(), 1.0m, status, PaymentMethod.Cash);

            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Order Status. Order status is not defined.");
        }

        public static IEnumerable<object[]> Order_InvalidPaymentMethod_TestData()
        {
            var maxIndex = Enum.GetValues<PaymentMethod>().Length;
            yield return new object[] { maxIndex };
        }

        [Theory(DisplayName = "Can't Create Order With Invalid Payment Method")]
        [InlineData(-1)]
        [MemberData(nameof(Order_InvalidPaymentMethod_TestData))]
        public void CreateOrder_WithInvalidPaymentMethod_DomainException(int statusIndex)
        {
            var paymentMethod = (PaymentMethod)statusIndex;

            Action action = () => new Order(1, new DateTime(), 1.0m, OrderStatus.Completed, paymentMethod);

            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Payment Method. Payment Method is not defined");
        }

        [Theory(DisplayName = "Can't Update Order Status With Invalid Status")]
        [InlineData(-1)]
        [MemberData(nameof(Order_InvalidOrderStatus_TestData))]
        public void UpdateOrder_WithInvalidStatus_DomainException(int statusIndex)
        {
            Action action = () =>
            {
                var status = (OrderStatus)statusIndex;
                var order = new Order(1, new DateTime(), 1.0m, OrderStatus.Completed, PaymentMethod.Cash);

                order.UpdateStatus(status);
            };

            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Order Status. Order status is not defined.");
        }

        [Theory(DisplayName = "Can't Update Order Payment Method With Invalid Payment Method")]
        [InlineData(-1)]
        [MemberData(nameof(Order_InvalidPaymentMethod_TestData))]
        public void UpdateOrder_WithInvalidPaymentMethod_DomainException(int paymentMethodIndex)
        {
            Action action = () =>
            {
                var paymentMethod = (PaymentMethod)paymentMethodIndex;
                var order = new Order(1, new DateTime(), 1.0m, OrderStatus.Completed, PaymentMethod.Cash);

                order.UpdatePaymentMethod(paymentMethod);
            };
        }
    }
}
