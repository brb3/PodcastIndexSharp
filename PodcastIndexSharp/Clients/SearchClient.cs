namespace PodcastIndexSharp.Clients
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Flurl.Http;
    using PodcastIndexSharp.Enums;
    using PodcastIndexSharp.Model;
    using PodcastIndexSharp.Response;

    public class SearchClient : BaseClient, ISearchClient
    {
        public SearchClient(PodcastIndexConfig config) : base(config) { }

        public async Task<List<Podcast>> Podcasts(string query, SearchByTermValues? value = null, bool clean = false, bool fulltext = false)
        {
            var endpoint = GetAuthorizedRequest("search/byterm")
                .SetQueryParam("q", query);

            if (value != null)
            {
                endpoint.SetQueryParam("val", value.ToString());
            }

            if (clean)
            {
                endpoint.SetQueryParam("clean", "");
            }

            if (fulltext)
            {
                endpoint.SetQueryParam("fulltext", "");
            }

            var feedResponse = await GetResponse<FeedsResponse>(endpoint);
            return feedResponse.Podcasts;
        }

        public async Task<List<Episode>> EpisodesByPerson(string person, bool fulltext = false)
        {
            var endpoint = GetAuthorizedRequest("search/byperson")
                .SetQueryParam("q", person);

            if (fulltext)
            {
                endpoint.SetQueryParam("fulltext", "");
            }

            var episodeResponse = await GetResponse<EpisodesResponse>(endpoint);

            return episodeResponse.Episodes;
        }

        public async Task<List<Podcast>> PodcastsByTitle(string query, SearchByTermValues? value = null, bool clean = false, bool fulltext = false, bool similar = false)
        {
            var endpoint = GetAuthorizedRequest("search/bytitle")
                .SetQueryParam("q", query);

            if (value != null)
            {
                endpoint.SetQueryParam("val", value.ToString());
            }

            if (clean)
            {
                endpoint.SetQueryParam("clean", "");
            }

            if (fulltext)
            {
                endpoint.SetQueryParam("fulltext", "");
            }

            if (similar)
            {
                endpoint.SetQueryParam("similar", "");
            }

            var feedResponse = await GetResponse<FeedsResponse>(endpoint);
            return feedResponse.Podcasts;
        }

        public async Task<List<Podcast>> MusicPodcasts(string query, SearchByTermValues? value = null, bool iTunesOnly = false, int max = 10, bool clean = false, bool fulltext = false)
        {
            var endpoint = GetAuthorizedRequest("search/music/byterm")
                .SetQueryParam("q", query)
                .SetQueryParam("max", max);

            if (value != null)
            {
                endpoint.SetQueryParam("val", value.ToString());
            }

            if (iTunesOnly)
            {
                endpoint.SetQueryParam("aponly", "true");
            }

            if (clean)
            {
                endpoint.SetQueryParam("clean", "");
            }

            if (fulltext)
            {
                endpoint.SetQueryParam("fulltext", "");
            }

            var feedResponse = await GetResponse<FeedsResponse>(endpoint);
            return feedResponse.Podcasts;
        }
    }
}