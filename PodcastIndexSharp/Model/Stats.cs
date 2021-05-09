namespace PodcastIndexSharp.Model
{
    public class Stats
    {
        public int FeedCountTotal { get; set; }

        public int EpisodeCountTotal { get; set; }

        public int FeedsWithNewEpisodes3Days { get; set; }

        public int FeedsWithNewEpisodes10Days { get; set; }

        public int FeedsWithNewEpisodes30Days { get; set; }

        public int FeedsWithNewEpisodes90Days { get; set; }
    }
}