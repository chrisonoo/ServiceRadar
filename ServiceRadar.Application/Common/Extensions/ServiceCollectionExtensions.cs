﻿using FluentValidation;
using FluentValidation.AspNetCore;

using Microsoft.Extensions.DependencyInjection;

using ServiceRadar.Application.Workshops.Commands.CreateWorkshop;
using ServiceRadar.Application.Workshops.Mappings;

namespace ServiceRadar.Application.Common.Extensions;
public static class ServiceCollectionExtensions
{
    public static void AddApplication(this IServiceCollection services)
    {
        // Register MediatR service
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(CreateWorkshopCommand)));

        // Register all AutoMapper mapping profile in DI
        services.AddAutoMapper(typeof(WorkshopMappingProfile));

        // Register all validation class in DI
        services.AddValidatorsFromAssemblyContaining<CreateWorkshopCommandValidator>()
            .AddFluentValidationAutoValidation()
            .AddFluentValidationClientsideAdapters();
    }
}
