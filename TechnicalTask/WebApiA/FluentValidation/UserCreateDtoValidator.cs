using FluentValidation;
using WebApiA.Dtos;

namespace WebApiA.FluentValidation;

public class UserCreateDtoValidator : AbstractValidator<UserCreateDto>
{
    public UserCreateDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(50);

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Invalid email format.")
            .Matches(@"^[\w\.-]+@[\w\.-]+\.\w{2,}$")
                .WithMessage("Email must match pattern user@domain.tld");
    }
}
