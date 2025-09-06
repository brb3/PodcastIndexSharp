namespace PodcastIndexSharp.Clients
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using PodcastIndexSharp.Model;
    using PodcastIndexSharp.Response;

    public class EpisodesClient : BaseClient, IEpisodesClient
    {
        public EpisodesClient(PodcastIndexConfig config) : base(config) { }

        public async Task<List<Episode>> ByFeedId(
            uint id,
            int? max = null,
            bool? fulltext = null,
            DateTime? since = null)
        {
            return await Episodes(id.ToString(), max, fulltext, false, since, null);
        }

        public async Task<List<Episode>> ByFeedId(
            uint[] id,
            int? max = null,
            bool? fulltext = null,
            DateTime? since = null)
        {
            return await Episodes(string.Join(",", id), max, fulltext, false, since, null);
        }

        public async Task<List<Episode>> ByFeedUrl(
            Uri url,
            int? max = null,
            bool? fulltext = null,
            DateTime? since = null)
        {
            var parameters = new ApiParameter[]
            {
                new ApiParameter("url", url),
                new ApiParameter("max", max),
                new ApiParameter("since", since),
                new ApiParameter("fulltext", fulltext)
            };

            var episodesResponse = await SendRequest<EpisodesResponse>("episodes/byfeedurl", parameters);
            return episodesResponse.Episodes;
        }

        public async Task<List<Episode>> ByiTunesId(
            uint id,
            int? max = null,
            bool? fulltext = null,
            DateTime? since = null,
            Uri? enclosure = null)
        {
            return await Episodes(id.ToString(), max, fulltext, true, since, enclosure);
        }

        public async Task<Episode> ById(uint id, bool? fulltext = null)
        {
            var parameters = new ApiParameter[]
            {
                new ApiParameter("id", id),
                new ApiParameter("fulltext", fulltext)
            };

            var episodeResponse = await SendRequest<EpisodeResponse>("episodes/byid", parameters);
            return episodeResponse.Episode;
        }

        public async Task<List<Episode>> Random(
            string? lang = null,
            string? category = null,
            string? excludeCategory = null,
            bool? fulltext = null,
            int? max = null)
        {
            var parameters = new ApiParameter[]
            {
                new ApiParameter("lang", lang),
                new ApiParameter("max", max),
                new ApiParameter("cat", category),
                new ApiParameter("notcat", excludeCategory),
                new ApiParameter("fulltext", fulltext)
            };

            var episodesResponse = await SendRequest<EpisodesResponse>("episodes/random", parameters);
            return episodesResponse.RandomEpisodes;
        }

        public async Task<List<Episode>> ByPodcastGUID(
            Guid guid,
            int? max = null,
            bool? fulltext = null,
            DateTime? since = null)
        {
            var parameters = new ApiParameter[]
            {
                new ApiParameter("guid", guid),
                new ApiParameter("max", max),
                new ApiParameter("since", since),
                new ApiParameter("fulltext", fulltext)
            };

            var episodesResponse = await SendRequest<EpisodesResponse>("episodes/bypodcastguid", parameters);
            return episodesResponse.Episodes;
        }

        public async Task<List<Episode>> Live(int? max = null)
        {
            var parameters = new ApiParameter[]
            {
                new ApiParameter("max", max),
            };

            var episodesResponse = await SendRequest<EpisodesResponse>("episodes/live", parameters);
            return episodesResponse.Episodes;
        }

        private async Task<List<Episode>> Episodes(
            string id,
            int? max,
            bool? fulltext,
            bool? itunes,
            DateTime? since,
            Uri? enclosure)
        {
            var parameters = new ApiParameter[]
            {
                new ApiParameter("id", id),
                new ApiParameter("max", max),
                new ApiParameter("since", since),
                new ApiParameter("fulltext", fulltext),
                new ApiParameter("enclosure", enclosure)
            };

            itunes ??= false;

            var episodeResponse = await SendRequest<EpisodesResponse>(
                itunes.Value ? "episodes/byitunesid" : "episodes/byfeedid",
                parameters);
            return episodeResponse.Episodes;
        }

        public async Task<Episode> ByGUID(
            Guid guid,
            string? feedUrl = null,
            string? feedId = null,
            Guid? podcastGUID = null,
            bool? fulltext = null)
        {
            if (feedUrl == null && feedId == null && podcastGUID == null)
            {
                throw new ArgumentException(
                    "At least one of the following must be provided: feedUrl, feedId, podcastGUID"
                );
            }

            var parameters = new ApiParameter[]
            {
                new ApiParameter("guid", guid),
                new ApiParameter("fulltext", fulltext),
                new ApiParameter("feedUrl", feedUrl),
                new ApiParameter("feedId", feedId),
                new ApiParameter("podcastguid", podcastGUID)
            };

            var episodesResponse = await SendRequest<EpisodeResponse>("episodes/byguid", parameters);
            return episodesResponse.Episode;
        }
    }
}