namespace Lancheria.Domain.Validation
{
    public static class EntityValidation
    {
        public static void ValidateId(int id)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id. Id can't be negative.");
        }
    }
}
