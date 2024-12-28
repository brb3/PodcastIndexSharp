namespace PodcastIndexSharp.Clients
{
    using System;
    using System.Threading.Tasks;
    using PodcastIndexSharp.Model;
    using PodcastIndexSharp.Response;

    public class HubClient : BaseClient, IHubClient
    {
        public HubClient(PodcastIndexConfig config) : base(config) { }

        public async Task<HubResponse> PubNotify(uint? id = null, Uri? url = null)
        {
            if (id == null && url == null)
            {
                throw new ArgumentException("Either the id or the url is required.");
            }

            var parameters = new ApiParameter[]
            {
                new ApiParameter("url", url),
                new ApiParameter("id", id)
            };

            var hubResponse = await SendRequest<HubResponse>("hub/pubnotify", parameters);
            return hubResponse;
        }
    }
}