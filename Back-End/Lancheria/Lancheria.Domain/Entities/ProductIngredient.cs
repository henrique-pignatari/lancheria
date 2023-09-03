using Lancheria.Domain.Validation;
#pragma warning disable CS8618

namespace Lancheria.Domain.Entities
{
    public class ProductIngredient : Entity
    {
        public int ProductId { get; private set; }
        public Product Product { get; set; }
        public int IngredientId { get; private set; }
        public Ingredient Ingredient { get; set; }
        public decimal Quantity { get; private set; }

        public ProductIngredient(int id, int productId, int ingredientId, decimal quantity) : this(productId, ingredientId, quantity)
        {
            EntityValidation.ValidateId(id);
            Id = id;
        }

        public ProductIngredient(int productId, int ingredientId, decimal quantity) : base()
        {
            ValidateDomain(productId, ingredientId, quantity);
        }

        private void ValidateDomain(int productId, int ingredientId, decimal quantity)
        {
            ProductIngredientValidation.ValidateProductId(productId);
            ProductIngredientValidation.ValidateIngredientId(ingredientId);
            ProductIngredientValidation.ValidateQuantity(quantity);

            ProductId = Id;
            IngredientId = ingredientId;
            Quantity = quantity;
        }

        public void Update(decimal quantity)
        {
            ValidateDomain(ProductId, IngredientId, quantity);
        }
    }
}
