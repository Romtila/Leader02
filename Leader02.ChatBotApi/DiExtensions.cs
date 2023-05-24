using Leader.Domain.Interfaces;
using Leader02.Application.IServices;
using Leader02.Application.Services;
using Leader02.ChatBotApi.Dialogs;
using Leader02.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Leader02.ChatBotApi;

public static class DiExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IRequirementRepository, RequirementRepository>();
        services.AddScoped<ILegalActRepository, LegalActRepository>();
        services.AddScoped<ISubDepartmentRepository, SubDepartmentRepository>();

        return services;
    }

    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddSingleton<IRequirementService, RequirementService>();
        services.AddSingleton<ILegalActService, LegalActService>();
        services.AddSingleton<IDepartmentService, DepartmentService>();

        return services;
    }

    public static IServiceCollection AddDialogs(this IServiceCollection services)
    {
        services.AddSingleton<ConsultationDialog>();
        services.AddSingleton<FeedBackDialog>();
        services.AddSingleton<RepeatQuestionDialog>();
        services.AddSingleton<MainDialog>();

        return services;
    }
}