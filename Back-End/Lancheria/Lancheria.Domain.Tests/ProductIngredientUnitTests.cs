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
    public class ProductIngredientUnitTests
    {
        [Fact(DisplayName = "Create ProductIngredient With Valid State")]
        public void CreateProductIngredient_WithValidParameters_ValidObjectState()
        {
            Action action = () => new ProductIngredient(1, 1, 1, 1.0m);

            action.Should()
                .NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Can't Create ProductIngredient With Negative Id")]
        public void CreateProductIngredient_WithNegativeId_DomainException()
        {
            Action action = () => new ProductIngredient(-1, 1, 1, 1.0m);
            
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Id. Id can't be negative.");
        }

        [Fact(DisplayName = "Can't Create ProductIngredient With Negative ProductId")]
        public void CreateProductIngredient_WithNegativeProductId_DomainException()
        {
            Action action = () => new ProductIngredient(1, -1, 1, 1.0m);

            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid ProductId. ProductId can't be negative.");
        }

        [Fact(DisplayName = "Can't Create ProductIngredient With Negative IngredientId")]
        public void CreateProductIngredient_WithNegativeIngredientId_DomainException()
        {
            Action action = () => new ProductIngredient(1, 1, -1, 1.0m);

            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid IngredientId. IngredientId can't be negative.");
        }

        [Fact(DisplayName = "Can't Create ProductIngredient With Negative Quantity")]
        public void CreateProductIngredient_WithNegativeQuantity_DomainException()
        {
            Action action = () => new ProductIngredient(1, 1, 1, -10m);

            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid ProductIngredient Quantity. Quantity can't be negative.");
        }

        [Fact(DisplayName = "Can't Update ProductIngredient With Negative Quantity")]
        public void UpdateProductIngredient_WithNegativeQuantity_DomainException()
        {
            Action action = () =>
            {
                var productIngredient = new Moq.Mock<ProductIngredient>(1, 1, 1, 10m).Object;
                productIngredient.Update(-1);
            };

            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid ProductIngredient Quantity. Quantity can't be negative.");
        }

    }
}
