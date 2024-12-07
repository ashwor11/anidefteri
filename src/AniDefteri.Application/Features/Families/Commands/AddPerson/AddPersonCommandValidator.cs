using FluentValidation;

namespace AniDefteri.Application.Features.Families.Commands;


public class AddPersonCommandValidator : AbstractValidator<AddPersonCommand>
{
    public AddPersonCommandValidator()
    {
        RuleFor(x => x.AddPersonDto.Name).NotEmpty().WithMessage("{Name} is required.")
            .NotNull().WithMessage("{Name} is required");
        RuleFor(x => x.AddPersonDto.FamilyId).NotEmpty().WithMessage("{FamilyId} is required.")
            .NotNull().WithMessage("{FamilyId} is required");
    }
}