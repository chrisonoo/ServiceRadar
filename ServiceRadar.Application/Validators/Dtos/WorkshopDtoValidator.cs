using FluentValidation;

using ServiceRadar.Application.Dtos;
using ServiceRadar.Domain.Interfaces;

namespace ServiceRadar.Application.Validators.Dtos;
public class WorkshopDtoValidator : AbstractValidator<WorkshopDto>
{
    public WorkshopDtoValidator(IServiceRadarRepository serviceRadarRepository)
    {
        RuleFor(c => c.Name)
            .NotEmpty().WithMessage("Field is required")
            .MinimumLength(2).WithMessage("Minimum length: 2")
            .MaximumLength(20).WithMessage("Maximum length: 20")
            .Custom((value, context) =>
            {
                var existingWorkshop = serviceRadarRepository.GetByName(value).Result;
                if(existingWorkshop != null)
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
