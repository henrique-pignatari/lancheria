using FluentAssertions;
using Lancheria.Domain.Entities;
using Lancheria.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lancheria.Domain.Tests
{
    public class ProductOrderUnitTests
    {
        [Fact(DisplayName = "Create Product Order With Valid State")]
        public void CreateProductOrder_WithValidParameters_ValidObjectState()
        {
            Action action = () => new ProductOrder(1, 1, 1, 1);

            action.Should()
                .NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Can't Create ProductOrder With Negative Id")]
        public void CreateProductOrder_WithNegativeId_DomainException()
        {
            Action action = () => new ProductOrder(-1, 1, 1, 1);

            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Id. Id can't be negative.");
        }

        [Fact(DisplayName = "Can't Create ProductOrder With Negative ProductId")]
        public void CreateProductOrder_WithNegativeProductId_DomainException()
        {
            Action action = () => new ProductOrder(1, -1, 1, 1);

            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid ProductId. ProductId can't be negative.");
        }

        [Fact(DisplayName = "Can't Create ProductOrder With Negative OrderId")]
        public void CreateProductOrder_WithNegativeOrderId_DomainException()
        {
            Action action = () => new ProductOrder(1, 1, -1, 1);

            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid OrderId. OrderId can't be negative.");
        }

        [Fact(DisplayName = "Can't Create ProductOrder With Negative Quantity")]
        public void CreateProductOrder_WithNegativeQuantity_DomainException()
        {
            Action action = () => new ProductOrder(1, 1, 1, -1);

            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Quantity. Quantity can't be negative.");
        }

        [Fact(DisplayName = "Can't Update ProductOrder With Negative Quantity")]
        public void UpdateProductOrder_WithNegativeQuantity_DomainException()
        {
            Action action = () =>
            {
                var productOrder = new ProductOrder(1, 1, 1, -1);

                productOrder.Update(-1);
            };

            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Quantity. Quantity can't be negative.");
        }
    }
}
