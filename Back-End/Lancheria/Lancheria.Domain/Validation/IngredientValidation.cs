using Lancheria.Domain.Enums;

namespace Lancheria.Domain.Validation
{
    public static class IngredientValidation
    {
        public static void ValidateName(string name)
        {
            DomainExceptionValidation.When(String.IsNullOrWhiteSpace(name), "Invalid Product Name. Product Name is required.");
            DomainExceptionValidation.When(name.Length < 3, "Invalid Product Name. Product Name must have 3 or more characters.");
            DomainExceptionValidation.When(name.Length > 100, "Invalid Product Name. Product Name must be under 100 characters.");
        }
        public static void ValidatePrice(decimal price)
        {
            DomainExceptionValidation.When(price < 0, "Invalid Product Price. Price can't be negative.");
        }
        public static void ValidateStock(int stock)
        {
            DomainExceptionValidation.When(stock < 0, "Invalid Stock quantity. Stock can't be negative.");
        }
        public static void ValidateMeasure(IngredientMeasure measure)
        {
            var isDefined = Enum.IsDefined(typeof(IngredientMeasure), measure);
            DomainExceptionValidation.When(!isDefined, "Invalid Measure. Measure is not part of defined measure types.");
        }
    }
}
