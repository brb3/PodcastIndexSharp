namespace PodcastIndexSharp.Clients
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Flurl.Http;
    using PodcastIndexSharp.Model;
    using PodcastIndexSharp.Response;

    public class EpisodesClient : BaseClient, IEpisodesClient
    {
        public EpisodesClient(PodcastIndexConfig config) : base(config) { }

        public async Task<List<Episode>> ByFeedId(uint id, int max = 10, bool fulltext = false, DateTime? since = null)
        {
            return await Episodes(id.ToString(), max, fulltext, false, since);
        }

        public async Task<List<Episode>> ByFeedId(uint[] id, int max = 10, bool fulltext = false, DateTime? since = null)
        {
            return await Episodes(string.Join(",", id), max, fulltext, false, since);
        }

        public async Task<List<Episode>> ByFeedUrl(Uri url, int max = 10, bool fulltext = false, DateTime? since = null)
        {
            var endpoint = GetAuthorizedRequest("episodes/byfeedurl")
                .SetQueryParam("url", url)
                .SetQueryParam("max", max);

            if (since != null)
            {
                endpoint.SetQueryParam("since", ToUnixTimeStamp(since));
            }

            if (fulltext)
            {
                endpoint.SetQueryParam("fulltext", "");
            }

            var episodesResponse = await GetResponse<EpisodesResponse>(endpoint);

            return episodesResponse.Episodes;
        }

        public async Task<List<Episode>> ByiTunesId(uint id, int max = 10, bool fulltext = false, DateTime? since = null)
        {
            return await Episodes(id.ToString(), max, fulltext, true, since);
        }

        public async Task<Episode> ById(uint id, bool fulltext = false)
        {
            var endpoint = GetAuthorizedRequest("episodes/byid")
                .SetQueryParam("id", id);

            if (fulltext)
            {
                endpoint.SetQueryParam("fulltext", "");
            }

            var episodeResponse = await GetResponse<EpisodeResponse>(endpoint);

            return episodeResponse.Episode;
        }

        public async Task<List<Episode>> Random(string lang = "", string category = "", string excludeCategory = "", bool fulltext = false, int max = 1)
        {
            var endpoint = GetAuthorizedRequest("episodes/random")
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

            if (fulltext)
            {
                endpoint.SetQueryParam("fulltext", "");
            }

            var episodesResponse = await GetResponse<EpisodesResponse>(endpoint);

            return episodesResponse.Episodes;
        }

        private async Task<List<Episode>> Episodes(string id, int max, bool fulltext, bool itunes, DateTime? since)
        {
            var segment = itunes ? "episodes/byitunesid" : "episodes/byfeedid";
            var endpoint = GetAuthorizedRequest(segment)
                .SetQueryParam("id", id)
                .SetQueryParam("max", max);

            if (since != null)
            {
                endpoint.SetQueryParam("since", ToUnixTimeStamp(since));
            }

            if (fulltext)
            {
                endpoint.SetQueryParam("fulltext", "");
            }

            var episodeResponse = await GetResponse<EpisodesResponse>(endpoint);

            return episodeResponse.Episodes;
        }
    }
}