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

        public async Task<List<Podcast>> Podcasts(string query, SearchByTermValues? value = null, bool clean = false, bool fulltext = false)
        {
            var parameters = new ApiParameter[] {
                new ApiParameter("q", query),
                new ApiParameter("val", value),
                new ApiParameter("clean", clean),
                new ApiParameter("fulltext", fulltext)
            };

            var feedResponse = await SendRequest<FeedsResponse>("search/byterm", parameters);
            return feedResponse.Podcasts;
        }

        public async Task<List<Episode>> EpisodesByPerson(string person, bool fulltext = false)
        {
            var parameters = new ApiParameter[] {
                new ApiParameter("q", person),
                new ApiParameter("fulltext", fulltext)
            };

            var episodeResponse = await SendRequest<EpisodesResponse>("search/byperson", parameters);
            return episodeResponse.Episodes;
        }

        public async Task<List<Podcast>> PodcastsByTitle(string query, SearchByTermValues? value = null, bool clean = false, bool fulltext = false, bool similar = false)
        {
            var parameters = new ApiParameter[] {
                new ApiParameter("q", query),
                new ApiParameter("val", value),
                new ApiParameter("clean", clean),
                new ApiParameter("fulltext", fulltext),
                new ApiParameter("similar", similar)
            };

            var feedResponse = await SendRequest<FeedsResponse>("search/bytitle", parameters);
            return feedResponse.Podcasts;
        }

        public async Task<List<Podcast>> MusicPodcasts(string query, SearchByTermValues? value = null, bool iTunesOnly = false, int max = 10, bool clean = false, bool fulltext = false)
        {
            var parameters = new ApiParameter[] {
                new ApiParameter("q", query),
                new ApiParameter("val", value),
                new ApiParameter("aponly", iTunesOnly),
                new ApiParameter("clean", clean),
                new ApiParameter("fulltext", fulltext),
            };

            var feedResponse = await SendRequest<FeedsResponse>("search/music/byterm", parameters);
            return feedResponse.Podcasts;
        }
    }
}