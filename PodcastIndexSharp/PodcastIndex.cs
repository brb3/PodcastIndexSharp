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

        public PodcastIndex(PodcastIndexConfig config) : base(config) { }

        public ISearchClient Search()
        {
            if (SearchClient == null)
            {
                SearchClient = new SearchClient(Config);
            }

            return SearchClient;
        }

        public IPodcastsClient Podcasts()
        {
            if (PodcastsClient == null)
            {
                PodcastsClient = new PodcastsClient(Config);
            }

            return PodcastsClient;
        }

        public IEpisodesClient Episodes()
        {
            if (EpisodesClient == null)
            {
                EpisodesClient = new EpisodesClient(Config);
            }

            return EpisodesClient;
        }

        public IRecentClient Recent()
        {
            if (RecentClient == null)
            {
                RecentClient = new RecentClient(Config);
            }

            return RecentClient;
        }

        public IValueClient Value()
        {
            if (ValueClient == null)
            {
                ValueClient = new ValueClient(Config);
            }

            return ValueClient;
        }

        public IStatsClient Stats()
        {
            if (StatsClient == null)
            {
                StatsClient = new StatsClient(Config);
            }

            return StatsClient;
        }

        public ICategoriesClient Categories()
        {
            if (CategoriesClient == null)
            {
                CategoriesClient = new CategoriesClient(Config);
            }

            return CategoriesClient;
        }
    }
}