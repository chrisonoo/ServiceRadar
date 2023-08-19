using FluentValidation;

namespace ServiceRadar.Application.WorkshopServices.Commands;
public class CreateWorkshopServiceCommandValidator : AbstractValidator<CreateWorkshopServiceCommand>
{
    public CreateWorkshopServiceCommandValidator()
    {
        RuleFor(s => s.Cost).NotEmpty().NotNull();
        RuleFor(s => s.ServiceDescription).NotEmpty().NotNull();
        RuleFor(s => s.WorkshopEncodedName).NotEmpty().NotNull();
    }
}
