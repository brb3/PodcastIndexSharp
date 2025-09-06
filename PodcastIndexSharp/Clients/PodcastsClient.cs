namespace PodcastIndexSharp.Clients
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using PodcastIndexSharp.Enums;
    using PodcastIndexSharp.Model;
    using PodcastIndexSharp.Response;

    public class PodcastsClient : BaseClient, IPodcastsClient
    {
        public PodcastsClient(PodcastIndexConfig config) : base(config) { }

        public async Task<Podcast> ByFeedId(uint id)
        {
            var parameters = new ApiParameter[]
            {
                new ApiParameter("id", id)
            };

            var podcastResponse = await SendRequest<PodcastResponse>("podcasts/byfeedid", parameters);
            return podcastResponse.Podcast;
        }

        public async Task<Podcast> ByFeedUrl(System.Uri url)
        {
            var parameters = new ApiParameter[]
            {
                new ApiParameter("url", url)
            };

            var podcastResponse = await SendRequest<PodcastResponse>("podcasts/byfeedurl", parameters);
            return podcastResponse.Podcast;
        }

        public async Task<Podcast> ByiTunesId(uint id)
        {
            var parameters = new ApiParameter[]
            {
                new ApiParameter("id", id)
            };

            var podcastResponse = await SendRequest<PodcastResponse>("podcasts/byitunesid", parameters);
            return podcastResponse.Podcast;
        }

        public async Task<List<Podcast>> Trending(
            int? max = null,
            string? lang = null,
            string? category = null,
            string? excludeCategory = null,
            DateTime? since = null)
        {
            var parameters = new ApiParameter[]
            {
                new ApiParameter("max", max),
                new ApiParameter("since", since),
                new ApiParameter("lang", lang),
                new ApiParameter("cat", category),
                new ApiParameter("notcat", excludeCategory)
            };

            var trendingResponse = await SendRequest<TrendingResponse>("podcasts/trending", parameters);
            return trendingResponse.Podcasts;
        }

        public async Task<List<Podcast>> Dead()
        {
            var deadResponse = await SendRequest<DeadResponse>("podcasts/dead", new ApiParameter[] { });
            return deadResponse.Podcasts;
        }

        public async Task<Podcast> ByGUID(Guid guid)
        {
            var parameters = new ApiParameter[]
            {
                new ApiParameter("guid", guid)
            };

            var podcastResponse = await SendRequest<PodcastResponse>("podcasts/byguid", parameters);
            return podcastResponse.Podcast;
        }

        public async Task<List<Podcast>> ByTag(PodcastNamespaceTag tag, int? max = null, int? startAt = null)
        {
            var parameters = new ApiParameter[]
            {
                new ApiParameter(tag == PodcastNamespaceTag.Value
                    ? "podcast-value"
                    : "podcast-valueTimeSplit", true),
                new ApiParameter("max", max),
                new ApiParameter("startAt", startAt)
            };

            var feedsResponse = await SendRequest<FeedsResponse>("podcasts/bytag", parameters);
            return feedsResponse.Podcasts;
        }

        public async Task<List<Podcast>> ByMedium(PodcastMedium medium, int? max = null)
        {
            var parameters = new ApiParameter[]
            {
                new ApiParameter("medium", medium),
                new ApiParameter("max", max)
            };

            var feedsResponse = await SendRequest<FeedsResponse>("podcasts/bymedium", parameters);
            return feedsResponse.Podcasts;
        }
    }
}