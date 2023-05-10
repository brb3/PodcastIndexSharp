namespace PodcastIndexSharp.Clients
{
    using System.Threading.Tasks;
    using PodcastIndexSharp.Model;
    using PodcastIndexSharp.Response;

    public class HubClient : BaseClient, IHubClient
    {
        public HubClient(PodcastIndexConfig config) : base(config) { }

        public async Task<HubResponse> PubNotify(uint? id, string url)
        {
            var parameters = new ApiParameter[]{
                new ApiParameter("id", id),
                new ApiParameter("url", url)
            };

            var hubResponse = await SendRequest<HubResponse>("hub/pubnotify", parameters);
            return hubResponse;
        }
    }
}