namespace PodcastIndexSharp.Extensions
{
    using Microsoft.Extensions.DependencyInjection;

    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddPodcastIndexSharp(this IServiceCollection services, PodcastIndexConfig config)
        {
            services.AddSingleton<PodcastIndexConfig>(config);
            services.AddSingleton<IPodcastIndexClient, PodcastIndexClient>();

            return services;
        }
    }
}