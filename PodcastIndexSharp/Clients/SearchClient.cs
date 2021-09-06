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

            var feedResponse = await endpoint.GetJsonAsync<FeedsResponse>();

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

            var episodeResponse = await endpoint.GetJsonAsync<EpisodesResponse>();

            return episodeResponse.Episodes;
        }
    }
}