using FluentAssertions;
using Lancheria.Domain.Entities;
using Lancheria.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace Lancheria.Domain.Tests
{
    public class ProductUnitTest
    {
        [Fact(DisplayName = "Create Product With Valid State")]
        public void CreateProduct_WithValidParameters_ValidObjectState()
        {
            Action action = () => new Product(1, "Pruduct", "Product", "Image", 10.0m, true, 12);

            action.Should()
                .NotThrow<Lancheria.Domain.Validation.DomainExceptionValidation>()
                .And
                .NotThrow<NullReferenceException>();
        }

        #region ID TESTS
        [Fact(DisplayName = "Can't Create Product With Negative Id")]
        public void CreateProduct_WithNegativeId_DomainException()
        {
            Action action = () => new Product(-1, "Pruduct", "Product", "Image", 10.0m, true, 12);

            action.Should()
                .Throw<Lancheria.Domain.Validation.DomainExceptionValidation>();

        }
        #endregion

        #region NAME TESTS
        [Fact(DisplayName = "Can't Create Product With Null Name")]
        public void CreateProduct_WithNullName_DomainException()
        {
            Action action = () => new Product(1, null, "Product", "Image", 10.0m, true, 12);

            action.Should()
                .Throw<Lancheria.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Product Name. Product Name is required.");
        }

        [Fact(DisplayName = "Can't Create Product With Empity Name")]
        public void CreateProduct_WithEmptyName_DomainException()
        {
            Action productEmpityName = () => new Product(1, "", "Product", "Image", 10.0m, true, 12);
            Action productWhiteSpaceName = () => new Product(1, "  ", "Product", "Image", 10.0m, true, 12);

            productEmpityName.Should()
                .Throw<Lancheria.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Product Name. Product Name is required.");

            productWhiteSpaceName.Should()
                .Throw<Lancheria.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Product Name. Product Name is required.");
        }

        [Fact(DisplayName = "Can't Create Product With Short Name")]
        public void CreateProduct_WithShortName_DomainException()
        {
            Action action = () => new Product(1, "Pr", "Product", "Image", 10.0m, true, 12);

            action.Should()
                .Throw<Lancheria.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Product Name. Product Name must have 3 or more characters.");
        }

        [Fact(DisplayName = "Can't Create Product With Long Name")]
        public void CreateProduct_WithLongName_DomainException()
        {
            Action action = () => new Product(1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.", "Product", "Image", 10.0m, true, 12);
            action.Should()
                .Throw<Lancheria.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Product Name. Product Name must be under 100 characters.");
        }
        #endregion

        #region DESCRIPTION TESTS
        [Fact(DisplayName = "Can't Create Product With Null Description")]
        public void CreateProduct_WithNullDescription_DomainExcetion()
        {
            Action action = () => new Product(1, "Pruduct", null, "Image", 10.0m, true, 12);

            action.Should()
                .Throw<Lancheria.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Product Description. Description is required.");
        }

        [Fact(DisplayName = "Can't Create Product With Empty Description")]
        public void CreateProduct_WithEmptyDescription_DomainException()
        {
            Action emptyDescription = () => new Product(1, "Pruduct", "", "Image", 10.0m, true, 12);
            Action whitespaceDescription = () => new Product(1, "Pruduct", "  ", "Image", 10.0m, true, 12);

            emptyDescription.Should()
                .Throw<Lancheria.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Product Description. Description is required.");

            whitespaceDescription.Should()
               .Throw<Lancheria.Domain.Validation.DomainExceptionValidation>()
               .WithMessage("Invalid Product Description. Description is required.");
        }

        [Fact(DisplayName = "Can't Create Product With Short Description")]
        public void CreateProduct_WithShortDescription_DomainException()
        {
            Action action = () => new Product(1, "Pruduct", "Pr", "Image", 10.0m, true, 12);

            action.Should()
               .Throw<Lancheria.Domain.Validation.DomainExceptionValidation>()
               .WithMessage("Invalid Product Description. Description must have 3 or more characters.");
        }

        [Fact(DisplayName = "Can't Create Product With Long Description")]
        public void CreateProduct_WithLongDescription_DomainException()
        {
            Action action = () => new Product(1, "Pruduct", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus eleifend enim eu justo tristique, eu blandit nisi consectetur. Nullam nec ultrices libero. Praesent interdum consectetur tortor, vel pellentesque justo dignissim in. Fusce laoreet facilisis efficitur.", "Image", 10.0m, true, 12);

            action.Should()
               .Throw<Lancheria.Domain.Validation.DomainExceptionValidation>()
               .WithMessage("Invalid Product Description. Description must be under 200 characters.");
        }
        #endregion

        #region IMAGE TESTS
        [Fact(DisplayName = "Create Product With Null Image Dont Throw Exception")]
        public void CreateProduct_WithNullImage_ValidObjectState()
        {
            Action action = () => new Product(1, "Pruduct", "Product", null, 10.0m, true, 12);

            action.Should()
                .NotThrow<Lancheria.Domain.Validation.DomainExceptionValidation>()
                .And
                .NotThrow<NullReferenceException>();
        }

        [Fact(DisplayName = "Can't Create Product With Empty Name")]
        public void CreateProduct_WithEmptyImage_DomainException()
        {
            Action emptyImage = () => new Product(1, "Pruduct", "Product", "", 10.0m, true, 12);
            Action whiteSpaceImage = () => new Product(1, "Pruduct", "Product", " ", 10.0m, true, 12);

            emptyImage.Should()
                .Throw<Lancheria.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Image Name. Image name cant be empty or whitespace.");

            whiteSpaceImage.Should()
                .Throw<Lancheria.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Image Name. Image name cant be empty or whitespace.");
        }

        [Fact(DisplayName = "Can't Create Product With Long Image Name")]
        public void CreateProduct_WithLongImage_DomainException()
        {
            Action action = () => new Product(1, "Pruduct", "Product", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus eleifend enim eu justo tristique, eu blandit nisi consectetur. Nullam nec ultrices libero. Praesent interdum consectetur tortor, vel pellentesque justo dignissim in. Fusce laoreet facilisis efficitur.", 10.0m, true, 12);

            action.Should()
                .Throw<Lancheria.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Image name. Image name too long, mus be under 250 characters.");
        }
        #endregion

        #region PRICE TESTS
        [Fact(DisplayName = "Can't Create Product With Negative Price")]
        public void CreateProduct_WithNegativePrice_DomainExceprion()
        {
            Action action = () => new Product(1, "Pruduct", "Product", "Image", -10.0m, true, 12);

            action.Should()
                .Throw<Lancheria.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Product Price. Price can't be negative.");
        }
        #endregion

        #region PREPARE TIME TESTS
        [Fact(DisplayName = "Can't Create Product With Negative Prepare Time")]
        public void CreateProduct_WithNegativePrepareTime_DomainException()
        {
            Action action = () => new Product(1, "Pruduct", "Product", "Image", 10.0m, true, -12);

            action.Should()
                .Throw<Lancheria.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid prepare time. Prepare time can't be negative.");
        }
        #endregion
    }
}
