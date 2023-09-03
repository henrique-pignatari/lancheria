using Lancheria.Domain.Entities;

namespace Lancheria.Domain.Validation
{
    public static class ProductIngredientValidation
    {
        public static void ValidateProductId(int productId)
        {
            DomainExceptionValidation.When(productId < 0, "Invalid ProductId. ProductId can't be negative.");
        }

        public static void ValidateIngredientId(int ingredientId)
        {
            DomainExceptionValidation.When(ingredientId < 0, "Invalid IngredientId. IngredientId can't be negative.");
        }

        public static void ValidateQuantity(decimal quantity)
        {
            DomainExceptionValidation.When(quantity < 0, "Invalid ProductIngredient Quantity. Quantity can't be negative.");
        }

        public static void ValidateList(IEnumerable<ProductIngredient> productsIngredients)
        {
            if (productsIngredients == null)
            {
                throw new DomainExceptionValidation("Invalid ProductsCategories. ProductsCategories is required.");
            }

            DomainExceptionValidation.When(productsIngredients.Count() < 1, "Invalid ProductCategories. ProductsCategories must have at least one element.");

            var invalidQuantityProduct = productsIngredients.First(productIngredient => productIngredient.Quantity < 0);

            DomainExceptionValidation.When(invalidQuantityProduct != null, "Invalid ProductIngredient Quantity. Quantity can't be negative.");

        }
    }
}
