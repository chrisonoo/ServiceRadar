using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FluentValidation;

namespace ServiceRadar.Application.Workshops.Commands.EditWorkshop;
public class EditWorkshopCommandValidator : AbstractValidator<EditWorkshopCommand>
{
    public EditWorkshopCommandValidator()
    {
        RuleFor(c => c.Description)
            .NotEmpty().WithMessage("Field is required");

        RuleFor(c => c.PhoneNumber)
            .Length(8, 15).WithMessage("Length: min. 8, max. 15");
    }
}
