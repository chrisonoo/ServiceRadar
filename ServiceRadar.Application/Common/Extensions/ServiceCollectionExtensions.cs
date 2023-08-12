using AutoMapper;

using FluentValidation;
using FluentValidation.AspNetCore;

using Microsoft.Extensions.DependencyInjection;

using ServiceRadar.Application.Common.ApplicationUser;
using ServiceRadar.Application.Workshops.Commands.CreateWorkshop;
using ServiceRadar.Application.Workshops.Mappings;
using ServiceRadar.Application.WorkshopServices.Mappings;

namespace ServiceRadar.Application.Common.Extensions;
public static class ServiceCollectionExtensions
{
    public static void AddApplication(this IServiceCollection services)
    {
        //Register the service to obtain information about the logged in user
        services.AddScoped<IUserContext, UserContext>();

        // Register MediatR service
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(CreateWorkshopCommand)));

        // Register all AutoMapper mapping profile in DI
        services.AddScoped(provider => new MapperConfiguration(cfg =>
        {
            var scope = provider.CreateScope();
            var userContext = scope.ServiceProvider.GetRequiredService<IUserContext>();

            cfg.AddProfile(new WorkshopMappingProfile(userContext));
            cfg.AddProfile(new WorkshopServiceMappingProfile());
        }).CreateMapper()
        );

        // Register all validation class in DI
        services.AddValidatorsFromAssemblyContaining<CreateWorkshopCommandValidator>()
            .AddFluentValidationAutoValidation()
            .AddFluentValidationClientsideAdapters();
    }
}
