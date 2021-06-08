using FluentValidation;
using TimeSheets.Models.Dto.Requests;

namespace TimeSheets.Infrastructure.Validation
{
    public class UserRequestValidator : AbstractValidator<UserRequest>
    {
        public UserRequestValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty()
                .WithMessage(ValidationMessages.CannotBeEmpty);

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage(ValidationMessages.CannotBeEmpty);
        }
    }
}
