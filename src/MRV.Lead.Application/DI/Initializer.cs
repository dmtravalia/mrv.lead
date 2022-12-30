using Microsoft.Extensions.DependencyInjection;
using MediatR;
using MRV.Lead.Application.Core;
using MRV.Lead.Application.Contact.Command;
using MRV.Lead.Application.Contact.Handler;
using System;
using MRV.Lead.Application.Lead.Handler;
using MRV.Lead.Application.Lead.Command;
using MRV.Lead.Infra.Gateways.Interfaces;
using MRV.Lead.Infra.Gateways;
using MRV.Lead.Application.QueryServices;
using MRV.Lead.Application.QueryServices.Interface;
using MRV.Lead.Infra.Interfaces.Core;
using MRV.Lead.Infra.Repositories.Core;

namespace MRV.Lead.Application.DI;

public static class Initializer
{
    public static IServiceCollection ConfigureInitializer(this IServiceCollection services)
    {
        services.AddCommands();
        services.AddQueriesServices();
        services.AddRepositories();

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddTransient<IEmail, Email>();

        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        return services;
    }

    public static IServiceCollection AddCommands(this IServiceCollection services)
    {
        services.AddTransient(typeof(IRequestHandler<ContactCreateCommand, Response>), typeof(ContactHandler));
        services.AddTransient(typeof(IRequestHandler<ContactUpdateCommand, Response>), typeof(ContactHandler));
        services.AddTransient(typeof(IRequestHandler<LeadCreateCommand, Response>), typeof(LeadHandler));
        services.AddTransient(typeof(IRequestHandler<LeadAcceptCommand, Response>), typeof(LeadHandler));
        services.AddTransient(typeof(IRequestHandler<LeadDeclineCommand, Response>), typeof(LeadHandler));

        return services;
    }
    public static IServiceCollection AddQueriesServices(this IServiceCollection services)
    {
        services.AddTransient<ILeadQueryService, LeadQueryService>();

        return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped(typeof(IRepositoryBase<,>), typeof(RepositoryBase<,>));
        services.AddScoped(typeof(IRepositoryQuery<>), typeof(RepositoryQuery<>));

        return services;
    }
}