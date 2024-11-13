using Learn.Language.Api.Infra.Context;
using Learn.Language.Api.Infra.Repositories;
using Learn.Language.Api.Infra.Repositories.Interfaces;
using Learn.Language.Api.Services;
using Learn.Language.Api.Services.Interfaces;

namespace Learn.Language.Api.Infra.Configurations;

public static class DependencyInjectionConfig
{
    public static IServiceCollection ConfigureDependencyInjection(this IServiceCollection services)
    {
        services.AddTransient<IWordRepository, WordRepository>();
        services.AddTransient<IWordService, WordService>();

        services.AddScoped<MongoDbContext>();

        return services;
    }
}