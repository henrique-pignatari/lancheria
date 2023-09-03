namespace Lancheria.Domain.Validation
{
    public static class CategoryValidation
    {
        public static void ValidateName(string name)
        {
            DomainExceptionValidation.When(String.IsNullOrWhiteSpace(name), "Invalid Category Name. Name is required.");
            DomainExceptionValidation.When(name.Length < 3, "Invalid Category Name. Name must have 3 or more characters.");
            DomainExceptionValidation.When(name.Length > 100, "Invalid Category Name. Name must be under 100 characters.");
        }
    }
}
