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
    public class CategoryUnitTests
    {
        [Fact(DisplayName = "Create Category With Valid State")]
        public void CrateCategory_WithValidParameters_ValidObjectState()
        {
            Action action = () => new Category(1, "Categoria");
            
            action.Should()
                .NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Can't Create Category With Negativ Id")]
        public void CreateCategory_WithNegativeId_DomainException()
        {
            Action action = () => new Category(-1, "Category");
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Id. Id can't be negative.");
        }

        [Theory(DisplayName = "Can´t Create Category With Null Or Empty Name")]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void CreateCategory_WithNullName_DomainException(string name)
        {
            Action action = () => new Category(1, name);

            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Category Name. Name is required.");
        }

        [Theory(DisplayName = "Can't Create Category With Long Or Short Name")]
        [InlineData("CA", "Invalid Category Name. Name must have 3 or more characters.")]
        [InlineData("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus eleifend enim eu justo tristique, eu blandit nisi consectetur. Nullam nec ultrices libero. Praesent interdum consectetur tortor, vel pellentesque justo dignissim in. Fusce laoreet facilisis efficitur.", "Invalid Category Name. Name must be under 100 characters.")]
        public void CreateCategory_WithLongOrShortName_DomainException(string name, string errorMessage)
        {
            Action action = () => new Category(1, name);

            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage(errorMessage);
        }
    }
}
