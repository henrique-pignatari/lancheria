using Lancheria.Domain.Entities;

namespace Lancheria.Domain.Validation
{
    public static class ProductCategoryValidation
    {
        public static void ValidateCategoryId(int categoryId)
        {
            DomainExceptionValidation.When(categoryId < 0, "Invalid CategoryId. CategoryId can't be negative.");
        }

        public static void ValidateProductId(int productId)
        {
            DomainExceptionValidation.When(productId < 0, "Invalid ProductId. ProductId can't be negative.");
        }

        public static void ValidateList(IEnumerable<ProductCategory> productsCategories)
        {
            if (productsCategories == null)
            {
                throw new DomainExceptionValidation("Invalid ProductsCategories. ProductsCategories is required.");
            }

            DomainExceptionValidation.When(productsCategories.Count() < 1, "Invalid ProductCategories. ProductsCategories must have at least one element.");
        }
    }
}
