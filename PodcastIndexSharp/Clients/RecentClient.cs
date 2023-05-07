namespace PodcastIndexSharp.Clients
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Flurl.Http;
    using PodcastIndexSharp.Model;
    using PodcastIndexSharp.Response;

    public class RecentClient : BaseClient, IRecentClient
    {
        public RecentClient(PodcastIndexConfig config) : base(config) { }

        public async Task<List<Episode>> Episodes(string exclude = "", bool fulltext = false, int max = 10, int? beforeId = null)
        {
            var endpoint = GetAuthorizedRequest("recent/episodes")
                .SetQueryParam("max", max);

            if (!string.IsNullOrEmpty(exclude))
            {
                endpoint.SetQueryParam("exclude", exclude);
            }

            if (beforeId != null)
            {
                endpoint.SetQueryParam("beforeId", beforeId);
            }

            if (fulltext)
            {
                endpoint.SetQueryParam("fulltext", "");
            }

            var recentEpisodesResponse = await GetResponse<RecentEpisodesResponse>(endpoint);

            return recentEpisodesResponse.Episodes;
        }

        public async Task<List<Podcast>> Podcasts(string lang = "", string category = "", string excludeCategory = "'", int max = 10, DateTime? since = null)
        {
            var endpoint = GetAuthorizedRequest("recent/feeds")
                .SetQueryParam("max", max);

            if (!string.IsNullOrEmpty(lang))
            {
                endpoint.SetQueryParam("lang", lang);
            }

            if (!string.IsNullOrEmpty(category))
            {
                endpoint.SetQueryParam("category", category);
            }

            if (!string.IsNullOrEmpty(excludeCategory))
            {
                endpoint.SetQueryParam("excludeCategory", excludeCategory);
            }

            if (since != null)
            {
                endpoint.SetQueryParam("since", ToUnixTimeStamp(since));
            }

            var feedsResponse = await GetResponse<FeedsResponse>(endpoint);

            return feedsResponse.Podcasts;
        }

        public async Task<List<Podcast>> NewPodcasts(int max = 10, DateTime? since = null)
        {
            var endpoint = GetAuthorizedRequest("recent/newfeeds")
                .SetQueryParam("max", max);

            if (since != null)
            {
                endpoint.SetQueryParam("since", ToUnixTimeStamp(since));
            }

            var feedsResponse = await GetResponse<FeedsResponse>(endpoint);

            return feedsResponse.Podcasts;
        }

        public async Task<List<Soundbite>> Soundbites(int max = 10)
        {
            var endpoint = GetAuthorizedRequest("recent/soundbites")
                .SetQueryParam("max", max);

            var soundbitesResponse = await GetResponse<SoundbitesResponse>(endpoint);

            return soundbitesResponse.Soundbites;
        }
    }
}