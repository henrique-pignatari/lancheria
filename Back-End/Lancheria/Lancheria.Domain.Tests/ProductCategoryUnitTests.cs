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
    public class ProductCategoryUnitTests
    {
        [Fact(DisplayName = "Create ProductCategory With Valid State")]
        public void CreateProductCategory_WithValidParameters_ValidObject()
        {
            Action action = () => new ProductCategory(1, 1, 1);

            action.Should()
                .NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Can't Create ProductCategory With Negative Id")]
        public void CreateProductCategory_WithNegativeId_DomainException()
        {
            Action action = () => new ProductCategory(-1, 1, 1);

            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Id. Id can't be negative.");
        }

        [Fact(DisplayName = "Can't Create ProductCategory With Negative ProductId")]
        public void CreateProductCategory_WithNegativeProductId_DomainException()
        {
            Action action = () => new ProductCategory(-1, -1, 1);

            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid ProductId. ProductId can't be negative.");
        }

        [Fact(DisplayName = "Can't Create ProductCategory With Negative CategoryId")]
        public void CreateProductCategory_WithNegativeCategoryId_DomainException()
        {
            Action action = () => new ProductCategory(1, 1, -1);

            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid CategoryId. CategoryId can't be negative.");
        }
    }
}
