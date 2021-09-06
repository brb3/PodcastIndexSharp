namespace PodcastIndexSharp.Clients
{
    using System;
    using System.Threading.Tasks;
    using Flurl.Http;
    using PodcastIndexSharp.Model;
    using PodcastIndexSharp.Response;

    public class ValueClient : BaseClient, IValueClient
    {
        public ValueClient(PodcastIndexConfig config) : base(config) { }

        public async Task<Value> ByFeedId(uint id)
        {
            var endpoint = GetAuthorizedRequest("value/byfeedid")
                .SetQueryParam("id", id);

            var valueResponse = await endpoint.GetJsonAsync<ValueResponse>();

            return valueResponse.Value;
        }

        public async Task<Value> ByFeedUrl(Uri url)
        {
            var endpoint = GetAuthorizedRequest("value/byfeedurl")
                .SetQueryParam("url", url);

            var valueResponse = await endpoint.GetJsonAsync<ValueResponse>();

            return valueResponse.Value;
        }
    }
}