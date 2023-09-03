using Lancheria.Domain.Validation;
#pragma warning disable CS8618

namespace Lancheria.Domain.Entities
{
    public class Product : Entity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string? Image { get; private set; }
        public decimal Price { get; private set; }
        public bool Available { get; private set; }
        public int PrepareTimeMinutes { get; private set; }
        public IEnumerable<ProductCategory> ProductsCategories { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<ProductIngredient> ProductsIngredients { get; set; }
        public IEnumerable<ProductOrder> ProductsOrders { get; set; }

        public Product(int id, string name, string description, string? image, decimal price, bool available, int prepareTimeMinutes) :
            this(name, description, image, price, available, prepareTimeMinutes)
        {
            EntityValidation.ValidateId(id);
            Id = id;
        }

        public Product(string name, string description, string? image, decimal price, bool available, int prepareTimeMinutes) : base()
        {
            ValidateDomain(name, description, image, price, available, prepareTimeMinutes);
        }

        private void ValidateDomain(string name, string description, string? image, decimal price, bool available, int prepareTimeMinutes)
        {
            ProductValidation.ValidateName(name);
            ProductValidation.ValidateDescription(description);
            ProductValidation.ValidateImage(image);
            ProductValidation.ValidatePrice(price);
            ProductValidation.ValidatePrepareTimeMinutes(prepareTimeMinutes);

            Name = name;
            Description = description;
            Image = image;
            Price = price;
            Available = available;
            PrepareTimeMinutes = prepareTimeMinutes;
        }

        public void Update(string name, string description, string image, decimal price, bool available, int prepareTimeMinutes, IEnumerable<ProductCategory> categories, IEnumerable<ProductIngredient> ingredients)
        {
            ProductCategoryValidation.ValidateList(categories);

            ProductIngredientValidation.ValidateList(ingredients);

            ValidateDomain(name, description, image, price, available, prepareTimeMinutes);

            ProductsCategories = categories;
            ProductsIngredients = ingredients;
        }
    }
}
