using Lancheria.Domain.Validation;
#pragma warning disable CS8618

namespace Lancheria.Domain.Entities
{
    public class Category : Entity
    {
        public string Name { get; set; }
        public IEnumerable<ProductCategory> ProductsCategories { get; set; }

        public Category(int id, string name) : this(name)
        {
            EntityValidation.ValidateId(id);
            Id = id;
        }

        public Category(string name) : base()
        {
            ValidateDomain(name);

            Name = name;
        }

        private void ValidateDomain(string name)
        {
            CategoryValidation.ValidateName(name);
        }

        public void Update(string name, IEnumerable<ProductCategory> products)
        {

            ProductCategoryValidation.ValidateList(products);

            ValidateDomain(name);
            ProductsCategories = products;
        }
    }
}
