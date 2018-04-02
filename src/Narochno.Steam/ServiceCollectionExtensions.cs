using Microsoft.Extensions.DependencyInjection;

namespace Narochno.Steam
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Add the Steam client to the service collection as a singleton.
        /// </summary>
        /// <param name="services">The service collection.</param>
        /// <returns>The passed service collection.</returns>
        public static IServiceCollection AddSteam(this IServiceCollection services)
        {
            return services.AddSingleton<ISteamClient, SteamClient>().AddSingleton(new SteamConfig());
        }

        /// <summary>
        /// Add the Steam client to the service collection as a singleton.
        /// </summary>
        /// <param name="services">The service collection.</param>
        /// <param name="config">The Steam configuration.</param>
        /// <returns>The passed service collection.</returns>
        public static IServiceCollection AddSteam(this IServiceCollection services, SteamConfig config)
        {
            return services.AddSingleton(config).AddSingleton<ISteamClient, SteamClient>();
        }
    }
}
