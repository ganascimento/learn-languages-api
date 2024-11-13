namespace Learn.Language.Api.Infra.Configurations;

public static class CorsConfig
{
    public static IServiceCollection ConfigCors(this IServiceCollection services)
    {
        services.AddCors(config =>
        {
            config.AddPolicy("CorsPolicy", option =>
            {
                option
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .SetIsOriginAllowed(_ => true)
                    .AllowCredentials();
            });
        });

        return services;
    }
}