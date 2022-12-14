namespace PodcastIndexSharp.Clients
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Flurl.Http;
    using PodcastIndexSharp.Model;
    using PodcastIndexSharp.Response;

    public class PodcastsClient : BaseClient, IPodcastsClient
    {
        public PodcastsClient(PodcastIndexConfig config) : base(config) { }

        public async Task<Podcast> ByFeedId(uint id)
        {
            var endpoint = GetAuthorizedRequest("podcasts/byfeedid")
                .SetQueryParam("id", id);

            var podcastResponse = await endpoint.GetJsonAsync<PodcastResponse>();

            return podcastResponse.Podcast;
        }

        public async Task<Podcast> ByFeedUrl(System.Uri url)
        {
            var endpoint = GetAuthorizedRequest("podcasts/byfeedurl")
                    .SetQueryParam("url", url);

            var podcastResponse = await endpoint.GetJsonAsync<PodcastResponse>();

            return podcastResponse.Podcast;
        }

        public async Task<Podcast> ByiTunesId(uint id)
        {
            var endpoint = GetAuthorizedRequest("podcasts/byitunesid")
                .SetQueryParam("id", id);

            var podcastResponse = await endpoint.GetJsonAsync<PodcastResponse>();

            return podcastResponse.Podcast;
        }

        public async Task<List<Podcast>> Trending(int max = 10, string lang = null, string category = null, string excludeCategory = null, DateTime? since = null)
        {
            var endpoint = GetAuthorizedRequest("podcasts/trending")
                .SetQueryParam("max", max);

            if (since != null)
            {
                endpoint.SetQueryParam("since", ToUnixTimeStamp(since));
            }

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

            var trendingResponse = await endpoint.GetJsonAsync<TrendingResponse>();

            return trendingResponse.Podcasts;
        }

        public async Task<List<Podcast>> Dead()
        {
            var endpoint = GetAuthorizedRequest("podcasts/dead");

            var deadResponse = await endpoint.GetJsonAsync<DeadResponse>();

            return deadResponse.Podcasts;
        }

        public async Task<Podcast> ByGUID(Guid guid)
        {
            var endpoint = GetAuthorizedRequest("podcasts/byguid")
                .SetQueryParam("guid", guid);

            var podcastResponse = await endpoint.GetJsonAsync<PodcastResponse>();

            return podcastResponse.Podcast;
        }
    }
}