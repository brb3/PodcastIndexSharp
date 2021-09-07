namespace PodcastIndexSharp
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using PodcastIndexSharp.Clients;

    public static class IServiceCollectionExtension
    {
        /// <summary>
        /// Configures and adds singletons for the PodcastIndexSharp library.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="config">
        /// Configuration is read from the PodcastIndex section. See the documentation for more information.
        /// </param>
        /// <returns></returns>
        public static IServiceCollection AddPodcastIndexSharp(this IServiceCollection services, IConfiguration config)
        {
            var podcastIndexConfig = new PodcastIndexConfig();
            config.GetSection(PodcastIndexConfig.Section).Bind(podcastIndexConfig);

            services.AddSingleton<PodcastIndexConfig>(podcastIndexConfig);
            services.AddSingleton<ICategoriesClient, CategoriesClient>();
            services.AddSingleton<IEpisodesClient, EpisodesClient>();
            services.AddSingleton<IPodcastsClient, PodcastsClient>();
            services.AddSingleton<IRecentClient, RecentClient>();
            services.AddSingleton<ISearchClient, SearchClient>();
            services.AddSingleton<IStatsClient, StatsClient>();
            services.AddSingleton<IValueClient, ValueClient>();
            services.AddSingleton<IPodcastIndex, PodcastIndex>();

            return services;
        }
    }
}