using FluentValidation;
using FluentValidation.AspNetCore;

using MediatR;

using Microsoft.Extensions.DependencyInjection;

using ServiceRadar.Application.Services;
using ServiceRadar.Application.Validators.Dtos;
using ServiceRadar.Application.Workshops.Commands.CreateWorkshop;
using ServiceRadar.Application.Workshops.Mappings;

namespace ServiceRadar.Application.Common.Extensions;
public static class ServiceCollectionExtensions
{
    public static void AddApplication(this IServiceCollection services)
    {
        // Register WorkshopService in DI that supports the methods available on the Workshop entity
        // TODO: move to MediatR
        services.AddScoped<IWorkshopService, WorkshopService>();

        // Register MediatR service
        services.AddMediatR(typeof(CreateWorkshopCommand));

        // Register all AutoMapper mapping profile in DI
        services.AddAutoMapper(typeof(WorkshopMappingProfile));

        // Register all validation class in DI
        services.AddValidatorsFromAssemblyContaining<CreateWorkshopCommandValidator>()
            .AddFluentValidationAutoValidation()
            .AddFluentValidationClientsideAdapters();
    }
}
