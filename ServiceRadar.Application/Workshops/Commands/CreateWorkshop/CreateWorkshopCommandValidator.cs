using FluentValidation;

using MediatR;

using ServiceRadar.Application.Workshops.Commands.CreateWorkshop;
using ServiceRadar.Application.Workshops.Queries.GetByName;

namespace ServiceRadar.Application.Validators.Dtos;
public class CreateWorkshopCommandValidator : AbstractValidator<CreateWorkshopCommand>
{
    public CreateWorkshopCommandValidator(IMediator mediator)
    {
        RuleFor(c => c.Name)
            .NotEmpty().WithMessage("Field is required")
            .MinimumLength(2).WithMessage("Minimum length: 2")
            .MaximumLength(20).WithMessage("Maximum length: 20")
            .Custom((value, context) =>
            {
                var existingWorkshopDto = mediator.Send(new GetByNameQuery(value)).Result;
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
