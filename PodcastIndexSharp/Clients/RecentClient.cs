namespace PodcastIndexSharp.Clients
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using PodcastIndexSharp.Model;
    using PodcastIndexSharp.Response;

    public class RecentClient : BaseClient, IRecentClient
    {
        public RecentClient(PodcastIndexConfig config) : base(config) { }

        public async Task<List<Episode>> Episodes(
            string? exclude = null,
            bool? fulltext = null,
            int? max = null,
            int? beforeId = null)
        {
            var parameters = new ApiParameter[]
            {
                new ApiParameter("max", max),
                new ApiParameter("excludeString", exclude),
                new ApiParameter("fulltext", fulltext),
                new ApiParameter("beforeId", beforeId),
            };

            var recentEpisodesResponse = await SendRequest<RecentEpisodesResponse>(
                "recent/episodes", parameters
            );
            return recentEpisodesResponse.Episodes;
        }

        public async Task<List<Podcast>> Podcasts(
            string? lang = null,
            string? category = null,
            string? excludeCategory = null,
            int? max = null,
            DateTime? since = null)
        {
            var parameters = new ApiParameter[]
            {
                new ApiParameter("max", max),
                new ApiParameter("lang", lang),
                new ApiParameter("cat", category),
                new ApiParameter("notcat", excludeCategory),
                new ApiParameter("since", since),
            };

            var feedsResponse = await SendRequest<FeedsResponse>("recent/feeds", parameters);
            return feedsResponse.Podcasts;
        }

        public async Task<List<Podcast>> NewPodcasts(int? max = null, DateTime? since = null, bool? descending = null)
        {
            var parameters = new ApiParameter[]
            {
                new ApiParameter("max", max),
                new ApiParameter("since", since),
                new ApiParameter("desc", descending)
            };

            var feedsResponse = await SendRequest<FeedsResponse>("recent/newfeeds", parameters);
            return feedsResponse.Podcasts;
        }

        public async Task<List<Soundbite>> Soundbites(int? max = null)
        {
            var parameters = new ApiParameter[]
            {
                new ApiParameter("max", max),
            };

            var soundbitesResponse = await SendRequest<SoundbitesResponse>("recent/soundbites", parameters);
            return soundbitesResponse.Soundbites;
        }

        public async Task<List<Podcast>> NewValueFeeds(int? max = null, DateTime? since = null)
        {
            var parameters = new ApiParameter[]
            {
                new ApiParameter("max", max),
                new ApiParameter("since", since),
            };

            var feedsResponse = await SendRequest<FeedsResponse>("recent/newvaluefeeds", parameters);
            return feedsResponse.Podcasts;
        }
    }
}