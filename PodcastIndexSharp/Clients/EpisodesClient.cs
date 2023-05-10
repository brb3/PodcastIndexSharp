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
            var parameters = new ApiParameter[]{
                new ApiParameter("url", url),
                new ApiParameter("max", max),
                new ApiParameter("since", since),
                new ApiParameter("fulltext", fulltext)
            };

            var episodesResponse = await SendRequest<EpisodesResponse>("episodes/byfeedurl", parameters);
            return episodesResponse.Episodes;
        }

        public async Task<List<Episode>> ByiTunesId(uint id, int max = 10, bool fulltext = false, DateTime? since = null)
        {
            return await Episodes(id.ToString(), max, fulltext, true, since);
        }

        public async Task<Episode> ById(uint id, bool fulltext = false)
        {
            var parameters = new ApiParameter[]{
                new ApiParameter("id", id),
                new ApiParameter("fulltext", fulltext)
            };

            var episodeResponse = await SendRequest<EpisodeResponse>("episodes/byid", parameters);
            return episodeResponse.Episode;
        }

        public async Task<List<Episode>> Random(string lang = "", string category = "", string excludeCategory = "", bool fulltext = false, int max = 1)
        {
            var parameters = new ApiParameter[]{
                new ApiParameter("lang", lang),
                new ApiParameter("max", max),
                new ApiParameter("category", category),
                new ApiParameter("excludeCategory", excludeCategory),
                new ApiParameter("fulltext", fulltext)
            };

            var episodesResponse = await SendRequest<EpisodesResponse>("episodes/random", parameters);
            return episodesResponse.Episodes;
        }

        public async Task<List<Episode>> ByPodcastGUID(Guid guid, int max = 10, bool fulltext = false, DateTime? since = null)
        {
            var parameters = new ApiParameter[]{
                new ApiParameter("guid", guid),
                new ApiParameter("max", max),
                new ApiParameter("since", since),
                new ApiParameter("fulltext", fulltext)
            };

            var episodesResponse = await SendRequest<EpisodesResponse>("episodes/bypodcastguid", parameters);
            return episodesResponse.Episodes;
        }

        public async Task<List<Episode>> Live(int max = 10)
        {
            var parameters = new ApiParameter[]{
                new ApiParameter("max", max),
            };

            var episodesResponse = await SendRequest<EpisodesResponse>("episodes/live", parameters);
            return episodesResponse.Episodes;
        }

        private async Task<List<Episode>> Episodes(string id, int max, bool fulltext, bool itunes, DateTime? since)
        {
            var parameters = new ApiParameter[]{
                new ApiParameter("id", id),
                new ApiParameter("max", max),
                new ApiParameter("since", since),
                new ApiParameter("fulltext", fulltext)
            };

            var episodeResponse = await SendRequest<EpisodesResponse>(
                itunes ? "episodes/byitunesid" : "episodes/byfeedid",
                parameters);
            return episodeResponse.Episodes;
        }
    }
}