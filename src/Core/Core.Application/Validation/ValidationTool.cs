using FluentValidation;
using FluentValidation.Results;

namespace Core.Application.Validation
{
    internal class ValidationTool
    {
        public static void Validate(IValidator validator, object entity)
        {
            ValidationContext<object> context = new(entity);
            ValidationResult validationResult = validator.Validate(context);
            if (!validationResult.IsValid) throw new ValidationException(validationResult.Errors);
        }
    }
}
