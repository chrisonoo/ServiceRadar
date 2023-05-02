using FluentValidation;

using ServiceRadar.Application.Dtos;
using ServiceRadar.Application.Services;

namespace ServiceRadar.Application.Validators.Dtos;
public class WorkshopDtoValidator : AbstractValidator<WorkshopDto>
{
    public WorkshopDtoValidator(IWorkshopService workshopService)
    {
        RuleFor(c => c.Name)
            .NotEmpty().WithMessage("Field is required")
            .MinimumLength(2).WithMessage("Minimum length: 2")
            .MaximumLength(20).WithMessage("Maximum length: 20")
            .Custom((value, context) =>
            {
                var existingWorkshopDto = workshopService.GetByName(value).Result;
                if(existingWorkshopDto != null)
                {
                    context.AddFailure($"{value} is not unique name for workshop");
                }
            });

        RuleFor(c => c.Description)
            .NotEmpty().WithMessage("Field is required");

        RuleFor(c => c.PhoneNumber)
            .Length(8, 15).WithMessage("Length: min. 8, max. 15");
    }
}
