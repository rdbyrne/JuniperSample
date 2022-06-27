using JuniperSample.Services;
using JuniperSample.TaxCalculators;
using JuniperSample.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace JuniperSample
{
    public static class DependencyInjectionContainer
	{
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.AddSingleton<ITaxService, TaxService>();
            services.AddSingleton<ITaxCalculator, TaxJarCalculator>();
            services.AddTransient<OrderViewModel>();
            services.AddTransient<LocationViewModel>();

            return services;
        }
    }
}

