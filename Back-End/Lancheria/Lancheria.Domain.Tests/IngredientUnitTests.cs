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
    public class IngredientUnitTests
    {
        [Fact(DisplayName = "Create Ingredient With Valid State")]
        public void CreateIngredient_WithValidParameters_ValidObjectState()
        {
            Action action = () => new Ingredient(1, "Ingredient", 1.0m, 1, IngredientMeasure.Unit);

            action.Should()
                .NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Can't create Ingredient With Negative Id")]
        public void CreateIngredient_WithNegativeId_DomainException()
        {
            Action action = () => new Ingredient(-1, "Ingredient", 1.0m, 1, IngredientMeasure.Unit);

            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Id. Id can't be negative.");
        }

        [Theory(DisplayName = "Can't Create Ingredient With Null Or Empty Name")]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void CreateIngredient_WithNullOrEmptyName_DomainException(string name)
        {
            Action action = () => new Ingredient(1, name, 1.0m, 1, IngredientMeasure.Unit);

            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Product Name. Product Name is required.");
        }

        [Theory(DisplayName = "Can't Create Ingredient With Long Or Short Name")]
        [InlineData("IN", "Invalid Product Name. Product Name must have 3 or more characters.")]
        [InlineData("Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.", "Invalid Product Name. Product Name must be under 100 characters.")]
        public void CreateIngredient_WithLongOrShortName_DomainException(string name, string errorMessage)
        {
            Action action = () => new Ingredient(1, name, 1.0m, 1, IngredientMeasure.Unit);

            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage(errorMessage);
        }

        [Fact(DisplayName = "Can't Create Ingredient With Negative Price")]
        public void CreateIngredient_WithNegativePrice_DomainException()
        {
            Action action = () => new Ingredient(1, "Ingredient", -1.0m, 1, IngredientMeasure.Unit);

            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Product Price. Price can't be negative.");
        }

        [Fact(DisplayName = "Can't Create Ingredient With Negative Stock")]
        public void CreateIngredient_WithNegativeStock_DomainException()
        {
            Action action = () => new Ingredient(1, "Ingredient", 1.0m, -1, IngredientMeasure.Unit);

            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Stock quantity. Stock can't be negative.");
        }

        public static IEnumerable<object[]> CreateIngredient_InvalidIngredientMeasure_TestData()
        {
            var maxIndex = Enum.GetValues<IngredientMeasure>().Length;
            yield return new object[] { maxIndex };
        }

        [Theory(DisplayName = "Can't Creat Ingredient With Invalid IngredientMeasure")]
        [InlineData(-1)]
        [MemberData(nameof(CreateIngredient_InvalidIngredientMeasure_TestData))]
        public void CreateIngredient_WithInvalidIngredientMeasure_DomainException(int measureIndex)
        {
            var ingredientMeasure = (IngredientMeasure)measureIndex;

            Action action = () => new Ingredient(1, "Ingredient", 1.0m, 1, ingredientMeasure);

            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Measure. Measure is not part of defined measure types.");
        }
    }
}
