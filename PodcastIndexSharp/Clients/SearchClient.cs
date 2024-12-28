namespace PodcastIndexSharp.Clients
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using PodcastIndexSharp.Enums;
    using PodcastIndexSharp.Model;
    using PodcastIndexSharp.Response;

    public class SearchClient : BaseClient, ISearchClient
    {
        public SearchClient(PodcastIndexConfig config) : base(config) { }

        public async Task<List<Podcast>> Podcasts(
            string query,
            SearchByTermValues? value = null,
            bool? clean = null,
            bool? fulltext = null)
        {
            var parameters = new ApiParameter[]
            {
                new ApiParameter("q", query),
                new ApiParameter("clean", clean),
                new ApiParameter("fulltext", fulltext),
                new ApiParameter("val", value ?? SearchByTermValues.any)
            };

            var feedResponse = await SendRequest<FeedsResponse>("search/byterm", parameters);
            return feedResponse.Podcasts;
        }

        public async Task<List<Episode>> EpisodesByPerson(string person, bool? fulltext = null, int? max = null)
        {
            var parameters = new ApiParameter[]
            {
                new ApiParameter("q", person),
                new ApiParameter("fulltext", fulltext),
                new ApiParameter("max", max)
            };

            var episodeResponse = await SendRequest<EpisodesResponse>("search/byperson", parameters);
            return episodeResponse.Episodes;
        }

        public async Task<List<Podcast>> PodcastsByTitle(
            string query,
            SearchByTermValues? value = null,
            bool? clean = null,
            bool? fulltext = null,
            bool? similar = null)
        {
            var parameters = new ApiParameter[]
            {
                new ApiParameter("q", query),
                new ApiParameter("clean", clean),
                new ApiParameter("fulltext", fulltext),
                new ApiParameter("similar", similar),
                new ApiParameter("val", value ?? SearchByTermValues.any)
            };

            var feedResponse = await SendRequest<FeedsResponse>("search/bytitle", parameters);
            return feedResponse.Podcasts;
        }

        public async Task<List<Podcast>> MusicPodcasts(
            string query,
            SearchByTermValues? value = null,
            bool? iTunesOnly = null,
            int? max = null,
            bool? clean = null,
            bool? fulltext = null)
        {
            var parameters = new ApiParameter[]
            {
                new ApiParameter("q", query),
                new ApiParameter("aponly", iTunesOnly),
                new ApiParameter("clean", clean),
                new ApiParameter("fulltext", fulltext),
                new ApiParameter("val", value),
                new ApiParameter("max", max)
            };

            var feedResponse = await SendRequest<FeedsResponse>("search/music/byterm", parameters);
            return feedResponse.Podcasts;
        }
    }
}