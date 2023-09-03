using Lancheria.Domain.Enums;
using Lancheria.Domain.Validation;
#pragma warning disable CS8618

namespace Lancheria.Domain.Entities
{
    public class Ingredient : Entity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public IngredientMeasure Measure { get; set; }
        public IEnumerable<ProductIngredient> ProductsIngredients { get; set; }

        public Ingredient(int id, string name, decimal price, int stock, IngredientMeasure measure) : this(name, price, stock, measure)
        {
            EntityValidation.ValidateId(id);
            Id = id;
        }

        public Ingredient(string name, decimal price, int stock, IngredientMeasure measure) : base()
        {
            ValidateDomain(name, price, stock, measure);
        }

        private void ValidateDomain(string name, decimal price, int stock, IngredientMeasure measure)
        {
            IngredientValidation.ValidateName(name);
            IngredientValidation.ValidatePrice(price);
            IngredientValidation.ValidateStock(stock);
            IngredientValidation.ValidateMeasure(measure);

            Name = name;
            Price = price;
            Stock = stock;
            Measure = measure;
        }

        public void Update(string name, decimal price, int stock, IngredientMeasure measure)
        {
            ValidateDomain(name, price, stock, measure);
        }
    }
}
