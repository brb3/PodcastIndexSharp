namespace PodcastIndexSharp.Clients
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Flurl.Http;
    using PodcastIndexSharp.Model;
    using PodcastIndexSharp.Response;

    /// <summary>
    /// Client to find details about one or more episodes of a podcast
    /// </summary>
    public class EpisodesClient : BaseClient, IEpisodesClient
    {
        public EpisodesClient(PodcastIndexConfig config) : base(config) { }

        /// <summary>
        /// Returns episodes for a feed ID
        /// </summary>
        public async Task<List<Episode>> ByFeedId(uint id, int max = 10, bool fulltext = false, DateTime? since = null)
        {
            return await Episodes(id.ToString(), max, fulltext, false, since);
        }

        /// <summary>
        /// Returns episodes for a list of feed IDs
        /// </summary>
        public async Task<List<Episode>> ByFeedId(uint[] id, int max = 10, bool fulltext = false, DateTime? since = null)
        {
            return await Episodes(string.Join(",", id), max, fulltext, false, since);
        }

        /// <summary>
        /// Returns episodes for a feed by the feed URL
        /// </summary>
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

        /// <summary>
        /// Returns episodes for a feed by the iTunes ID
        /// </summary>
        public async Task<List<Episode>> ByiTunesId(uint id, int max = 10, bool fulltext = false, DateTime? since = null)
        {
            return await Episodes(id.ToString(), max, fulltext, true, since);
        }

        /// <summary>
        /// Returns the metadata for a single episode by its ID
        /// </summary>
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

        /// <summary>
        /// Returns a Random batch of episodes
        /// </summary>
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

        /// <summary>
        /// Returns episodes known for a podcast by the <see href="https://github.com/Podcastindex-org/podcast-namespace/blob/main/docs/1.0.md#guid">Podcast GUID</see>.
        /// </summary>
        /// <seealso href="">Podcast GUID Documentation</seealso>
        public async Task<List<Episode>> ByPodcastGUID(Guid guid, int max = 10, bool fulltext = false, DateTime? since = null)
        {
            var endpoint = GetAuthorizedRequest("episodes/bypodcastguid")
                .SetQueryParam("guid", guid)
                .SetQueryParam("max", max);

            if (fulltext)
            {
                endpoint.SetQueryParam("fulltext", "");
            }

            if (since != null)
            {
                endpoint.SetQueryParam("since", ToUnixTimeStamp(since));
            }


            var episodesResponse = await GetResponse<EpisodesResponse>(endpoint);

            return episodesResponse.Episodes;
        }

        /// <summary>
        /// Get all episodes that have been found in the "podcast:liveitem" from the feeds
        /// </summary>
        public async Task<List<Episode>> Live(int max = 10)
        {
            var endpoint = GetAuthorizedRequest("episodes/live")
                .SetQueryParam("max", max);

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