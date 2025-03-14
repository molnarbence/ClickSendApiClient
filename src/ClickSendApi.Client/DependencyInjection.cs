using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ClickSendApi.Client;

public static class DependencyInjection
{
    public static IServiceCollection AddClickSendApiClient(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddOptions<ClickSendConfig>()
            .BindConfiguration(ClickSendConfig.SectionName)
            .ValidateOnStart();
        
        services.AddTransient<AuthHeaderHandler>();
        
        services.AddHttpClient<IClickSendApi>()
            .AddHttpMessageHandler<AuthHeaderHandler>();

        return services;
    }
}