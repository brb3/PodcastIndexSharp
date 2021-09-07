namespace PodcastIndexSharp
{
    using PodcastIndexSharp.Clients;

    public class PodcastIndex : BaseClient, IPodcastIndex
    {
        private ISearchClient SearchClient { get; set; }

        private IPodcastsClient PodcastsClient { get; set; }

        private IEpisodesClient EpisodesClient { get; set; }

        private IRecentClient RecentClient { get; set; }

        private IValueClient ValueClient { get; set; }

        private IStatsClient StatsClient { get; set; }

        private ICategoriesClient CategoriesClient { get; set; }

        public PodcastIndex(PodcastIndexConfig config,
            ISearchClient searchClient,
            IPodcastsClient podcastsClient,
            IEpisodesClient episodesClient,
            IRecentClient recentClient,
            IValueClient valueClient,
            IStatsClient statsClient,
            ICategoriesClient categoriesClient) : base(config)
        {
            SearchClient = searchClient;
            PodcastsClient = podcastsClient;
            EpisodesClient = episodesClient;
            RecentClient = recentClient;
            ValueClient = valueClient;
            StatsClient = statsClient;
            CategoriesClient = categoriesClient;
        }

        public ISearchClient Search() => SearchClient;

        public IPodcastsClient Podcasts() => PodcastsClient;

        public IEpisodesClient Episodes() => EpisodesClient;

        public IRecentClient Recent() => RecentClient;

        public IValueClient Value() => ValueClient;

        public IStatsClient Stats() => StatsClient;

        public ICategoriesClient Categories() => CategoriesClient;
    }
}