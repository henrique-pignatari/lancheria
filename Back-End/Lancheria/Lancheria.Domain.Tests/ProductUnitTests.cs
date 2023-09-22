using FluentAssertions;
using Lancheria.Domain.Entities;
using Lancheria.Domain.Validation;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace Lancheria.Domain.Tests
{
    public class ProductUnitTests
    {
        [Fact(DisplayName = "Create Product With Valid State")]
        public void CreateProduct_WithValidParameters_ValidObjectState()
        {
            Action action = () => new Product(1, "Pruduct", "Product", "Image", 10.0m, true, 12);

            action.Should()
                .NotThrow<DomainExceptionValidation>()
                .And
                .NotThrow<NullReferenceException>();
        }

        #region ID TESTS
        [Fact(DisplayName = "Can't Create Product With Negative Id")]
        public void CreateProduct_WithNegativeId_DomainException()
        {
            Action action = () => new Product(-1, "Pruduct", "Product", "Image", 10.0m, true, 12);

            action.Should()
                .Throw<DomainExceptionValidation>();

        }
        #endregion

        #region NAME TESTS
        [Theory(DisplayName = "Can't Create Product With Null Or Empty Name")]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void CreateProduct_WithNullOrEmptyName_DomainException(string name)
        {
            Action action = () => new Product(1, name, "Product", "Image", 10.0m, true, 12);

            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Product Name. Product Name is required.");
        }
        
        [Theory(DisplayName = "Can't Create Product With Long Or Short Name")]
        [InlineData("Pr", "Invalid Product Name. Product Name must have 3 or more characters.")]
        [InlineData("Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.", "Invalid Product Name. Product Name must be under 100 characters.")]
        public void CreateProduct_WithLongOrShortName_DomainException(string name, string errorMessage)
        {
            Action action = () => new Product(1, name, "Product", "Image", 10.0m, true, 12);

            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage(errorMessage);
        }
        #endregion

        #region DESCRIPTION TESTS
        [Theory(DisplayName = "Can't Create Product With Null Or Empty Description")]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void CreateProduct_WithNullOrEmptyDescription_DomainExcetion(string description)
        {
            Action action = () => new Product(1, "Pruduct", description, "Image", 10.0m, true, 12);

            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Product Description. Description is required.");
        }

        [Theory(DisplayName = "Can't Create Product With Long Or Short Description")]
        [InlineData("PR", "Invalid Product Description. Description must have 3 or more characters.")]
        [InlineData("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus eleifend enim eu justo tristique, eu blandit nisi consectetur. Nullam nec ultrices libero. Praesent interdum consectetur tortor, vel pellentesque justo dignissim in. Fusce laoreet facilisis efficitur.", "Invalid Product Description. Description must be under 200 characters.")]
        public void CreateProduct_WithLongOrShortDescription_DomainException(string description, string errorMessage)
        {
            Action action = () => new Product(1, "Pruduct", description, "Image", 10.0m, true, 12);

            action.Should()
               .Throw<DomainExceptionValidation>()
               .WithMessage(errorMessage);
        }
        #endregion

        #region IMAGE TESTS
        [Fact(DisplayName = "Create Product With Null Image Name Dont Throw Exception")]
        public void CreateProduct_WithNullImage_ValidObjectState()
        {
            Action action = () => new Product(1, "Pruduct", "Product", null, 10.0m, true, 12);

            action.Should()
                .NotThrow<DomainExceptionValidation>()
                .And
                .NotThrow<NullReferenceException>();
        }

        [Theory(DisplayName = "Can't Create Product With Empty Image")]
        [InlineData("")]
        [InlineData(" ")]
        public void CreateProduct_WithEmptyImage_DomainException(string image)
        {
            Action action = () => new Product(1, "Pruduct", "Product", image, 10.0m, true, 12);
            
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Image Name. Image name cant be empty or whitespace.");
        }

        [Fact(DisplayName = "Can't Create Product With Long Image Name")]
        public void CreateProduct_WithLongImage_DomainException()
        {
            Action action = () => new Product(1, "Pruduct", "Product", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus eleifend enim eu justo tristique, eu blandit nisi consectetur. Nullam nec ultrices libero. Praesent interdum consectetur tortor, vel pellentesque justo dignissim in. Fusce laoreet facilisis efficitur.", 10.0m, true, 12);

            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Image name. Image name too long, mus be under 250 characters.");
        }
        #endregion

        #region PRICE TESTS
        [Fact(DisplayName = "Can't Create Product With Negative Price")]
        public void CreateProduct_WithNegativePrice_DomainExceprion()
        {
            Action action = () => new Product(1, "Pruduct", "Product", "Image", -10.0m, true, 12);

            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Product Price. Price can't be negative.");
        }
        #endregion

        #region PREPARE TIME TESTS
        [Fact(DisplayName = "Can't Create Product With Negative Prepare Time")]
        public void CreateProduct_WithNegativePrepareTime_DomainException()
        {
            Action action = () => new Product(1, "Pruduct", "Product", "Image", 10.0m, true, -12);

            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid prepare time. Prepare time can't be negative.");
        }
        #endregion

        #region UPDATE TESTS
        [Fact(DisplayName = "Can't Update Product With Null Categories")]
        public void UpdateProduct_WithNullCategories_DomainException()
        {
            Action action = () =>
            {
                var product = new Moq.Mock<Product>(1, "Product", "Description", "Image", 10.0m, true, 10).Object;
                var ingredients = new List<ProductIngredient>();
                ingredients.Add(new Moq.Mock<ProductIngredient>(1, 1, 1, 1.0m).Object);

                product.Update(product.Name, product.Description, product.Image, product.Price, product.Available, product.PrepareTimeMinutes, null, ingredients);
            };

            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid ProductsCategories. ProductsCategories is required.");
        }

        [Fact(DisplayName = "Can't Update With Empty Categories")]
        public void UpdateProduct_WithEmptyCategories_DomainException()
        {
            Action action = () =>
            {
                var product = new Moq.Mock<Product>(1, "Product", "Description", "Image", 10.0m, true, 10).Object;
                var categories = new List<ProductCategory>();
                var ingredients = new List<ProductIngredient>();
                ingredients.Add(new Moq.Mock<ProductIngredient>(1, 1, 1, 1.0m).Object);

                product.Update(product.Name, product.Description, product.Image, product.Price, product.Available, product.PrepareTimeMinutes, categories, ingredients);
            };

            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid ProductCategories. ProductsCategories must have at least one element.");
        }

        [Fact(DisplayName = "Can't Update With Null Ingredients")]
        public void UpdateProduct_WithNullIngredients_DomainException()
        {
            Action action = () =>
            {
                var product = new Moq.Mock<Product>(1, "Product", "Description", "Image", 10.0m, true, 10).Object;
                var categories = new List<ProductCategory>();
                categories.Add(new Moq.Mock<ProductCategory>(1, 1, 1).Object);

                product.Update(product.Name, product.Description, product.Image, product.Price, product.Available, product.PrepareTimeMinutes, categories, null);
            };

            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid ProductsCategories. ProductsCategories is required.");
        }

        [Fact(DisplayName = "Can't Update With Empty Ingredients")]
        public void UpdateProduct_WithEmptyIngredients_DomainException()
        {
            Action action = () =>
            {
                var product = new Moq.Mock<Product>(1, "Product", "Description", "Image", 10.0m, true, 10).Object;
                var categories = new List<ProductCategory>();
                categories.Add(new Moq.Mock<ProductCategory>(1, 1, 1).Object);
                var ingredients = new List<ProductIngredient>();

                product.Update(product.Name, product.Description, product.Image, product.Price, product.Available, product.PrepareTimeMinutes, categories, ingredients);
            };

            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid ProductCategories. ProductsCategories must have at least one element.");
        }
        #endregion
    }
}
