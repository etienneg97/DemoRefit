using DemoRefit.Client.Handlers;
using Refit;

namespace DemoRefit.Client.Refit
{
    public static class RefitBootstrapper
    {
        public static void AddRefitClients(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<LanguageHandler>();

            var baseUrl = configuration.GetValue<string>("ApiBaseUrl") ?? "https://localhost:7225/";

            services.AddRefitClientWithBaseUrl<IBookApiService>(baseUrl);
            services.AddRefitClientWithBaseUrl<IDateApiService>(baseUrl);
        }

        private static IHttpClientBuilder AddRefitClientWithBaseUrl<TClient>(this IServiceCollection services, string baseUrl)
            where TClient : class
        {
            return services.AddRefitClient<TClient>()
                           .ConfigureHttpClient(c => c.BaseAddress = new Uri(baseUrl))
                           .AddHttpMessageHandler<LanguageHandler>(); ;
        }
    }
}
