using FluentValidation;
using TimeSheets.Models.Dto.Requests;

namespace TimeSheets.Infrastructure.Validation
{
    public class SheetRequestValidator: AbstractValidator<SheetRequest>
    {
        public SheetRequestValidator()
        {
            RuleFor(x => x.Amount)
                .InclusiveBetween(1, 8)
                .WithMessage(ValidationMessages.SheetAmountError);

            RuleFor(x => x.ContractId)
                .NotEmpty();

            RuleFor(x => x.EmployeeId)
                .NotEmpty();

            RuleFor(x => x.ServiceId)
                .NotEmpty();
        }
    }
}
