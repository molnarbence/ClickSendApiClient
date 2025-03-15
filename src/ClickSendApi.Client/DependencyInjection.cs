using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;

namespace ClickSendApi.Client;

public static class DependencyInjection
{
    public static IServiceCollection AddClickSendApiClient(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddOptions<ClickSendConfig>()
            .BindConfiguration(ClickSendConfig.SectionName)
            .ValidateOnStart();
        
        services.AddTransient<AuthHeaderHandler>();
        
        services
            .AddRefitClient<IClickSendApi>()
            .ConfigureHttpClient(httpClient => httpClient.BaseAddress = new Uri("https://rest.clicksend.com/v3"))
            .AddHttpMessageHandler<AuthHeaderHandler>();

        return services;
    }
}