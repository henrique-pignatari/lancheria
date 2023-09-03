namespace Lancheria.Domain.Validation
{
    public static class ProductValidation
    {
        public static void ValidateName(string name)
        {
            DomainExceptionValidation.When(String.IsNullOrWhiteSpace(name), "Invalid Product Name. Product Name is required.");
            DomainExceptionValidation.When(name.Length < 3, "Invalid Product Name. Product Name must have 3 or more characters.");
            DomainExceptionValidation.When(name.Length > 100, "Invalid Product Name. Product Name must be under 100 characters.");
        }
        public static void ValidateDescription(string description)
        {
            DomainExceptionValidation.When(String.IsNullOrWhiteSpace(description), "Invalid Product Description. Description is required.");
            DomainExceptionValidation.When(description.Length < 3, "Invalid Product Description. Description must have 3 or more characters.");
            DomainExceptionValidation.When(description.Length > 200, "Invalid Product Description. Description must be under 200 characters.");
        }
        public static void ValidateImage(string? image)
        {
            DomainExceptionValidation.When(image?.Length > 250, "Invalid Image name. Image name too long, mus be under 250 characters.");
            
            if(image != null)
            {
                DomainExceptionValidation.When(String.IsNullOrWhiteSpace(image), "Invalid Image Name. Image name cant be empty or whitespace.");
            }
        }
        public static void ValidatePrice(decimal price)
        {
            DomainExceptionValidation.When(price < 0, "Invalid Product Price. Price can't be negative.");
        }
        public static void ValidatePrepareTimeMinutes(int prepareTimeMinutes)
        {
            DomainExceptionValidation.When(prepareTimeMinutes < 0, "Invalid prepare time. Prepare time can't be negative.");
        }
    }
}
