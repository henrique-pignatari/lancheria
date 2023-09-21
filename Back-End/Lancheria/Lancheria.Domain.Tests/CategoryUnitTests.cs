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

        [Fact(DisplayName = "Can´t Create Category With Null Name")]
        public void CreateCategory_WithNullName_DomainException()
        {
            Action action = () => new Category(1, null);

            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Category Name. Name is required.");
        }

        [Fact(DisplayName = "Can't Create Category With Empity or Whitespace Name")]
        public void CreateCategory_WithEmpityName_DomainException()
        {
            Action empityNameAction = () => new Category(1, "");
            Action whitespaceNameAction = () => new Category(1, "  ");

            empityNameAction.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Category Name. Name is required.");

            whitespaceNameAction.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Category Name. Name is required.");
        }

        [Fact(DisplayName = "Can't Create Category With Short Name")]
        public void CreateCategory_WithShortName_DomainException()
        {
            Action action = () => new Category(1, "Ca");

            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Category Name. Name must have 3 or more characters.");
        }

        [Fact(DisplayName = "Can't Create Category With Long name")]
        public void CreateCategory_WithLongDescription_DomainException()
        {
            Action action = () => new Category(1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus eleifend enim eu justo tristique, eu blandit nisi consectetur. Nullam nec ultrices libero. Praesent interdum consectetur tortor, vel pellentesque justo dignissim in. Fusce laoreet facilisis efficitur.");

            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Category Name. Name must be under 100 characters.");
        }
    }
}
