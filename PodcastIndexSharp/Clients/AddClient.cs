namespace PodcastIndexSharp.Clients
{
    using System.Threading.Tasks;
    using PodcastIndexSharp.Model;
    using PodcastIndexSharp.Response;

    public class AddClient : BaseClient, IAddClient
    {
        public AddClient(PodcastIndexConfig config) : base(config) { }

        public async Task<AddResponse> ByFeedUrl(string url, string chash, uint? iTunesId = null)
        {
            var parameters = new ApiParameter[]
            {
                new ApiParameter("url", url),
                new ApiParameter("chash", chash),
                new ApiParameter("itunesid", iTunesId),
            };

            var addResponse = await SendRequest<AddResponse>("add/byfeedurl", parameters);
            return addResponse;
        }

        public async Task<AddResponse> ByiTunesId(uint iTunesId)
        {
            var parameters = new ApiParameter[]
            {
                new ApiParameter("id", iTunesId)
            };

            var addResponse = await SendRequest<AddResponse>("add/byitunesid", parameters);
            return addResponse;
        }
    }
}