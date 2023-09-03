using Lancheria.Domain.Validation;
#pragma warning disable CS8618

namespace Lancheria.Domain.Entities
{
    public class ProductCategory : Entity
    {
        public int ProductId { get; private set; }
        public Product Product { get; set; }
        public int CategoryId { get; private set; }
        public Category Category { get; set; }

        public ProductCategory(int id, int productId, int categoryId) : this(productId, categoryId)
        {
            EntityValidation.ValidateId(id);
            Id = id;
        }

        public ProductCategory(int productId, int categoryId) : base()
        {
            ValidateDomain(productId, categoryId);
        }

        private void ValidateDomain(int productId, int categoryId)
        {
            ProductCategoryValidation.ValidateProductId(productId);
            ProductCategoryValidation.ValidateCategoryId(categoryId);

            ProductId = productId;
            CategoryId = categoryId;
        }
    }
}
