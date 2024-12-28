namespace PodcastIndexSharp.Clients
{
    using System;
    using System.Threading.Tasks;
    using PodcastIndexSharp.Model;
    using PodcastIndexSharp.Response;

    public class ValueClient : BaseClient, IValueClient
    {
        public ValueClient(PodcastIndexConfig config) : base(config) { }

        public async Task<Value> ByFeedId(uint id)
        {
            var parameters = new ApiParameter[] { new ApiParameter("id", id) };

            var valueResponse = await SendRequest<ValueResponse>("value/byfeedid", parameters);
            return valueResponse.Value;
        }

        public async Task<Value> ByFeedUrl(Uri url)
        {
            var parameters = new ApiParameter[] { new ApiParameter("url", url) };

            var valueResponse = await SendRequest<ValueResponse>("value/byfeedurl", parameters);
            return valueResponse.Value;
        }

        public async Task<Value> ByFeedGUID(Guid guid)
        {
            var parameters = new ApiParameter[] { new ApiParameter("guid", guid) };

            var valueResponse = await SendRequest<ValueResponse>("value/bypodcastguid", parameters);
            return valueResponse.Value;
        }

        public async Task<Value> ByEpisodeGUID(Guid podcastGUID, Guid episodeGUID)
        {
            var parameters = new ApiParameter[]
            {
                new ApiParameter("podcastguid", podcastGUID),
                new ApiParameter("episodeguid", episodeGUID)
            };

            var valueResponse = await SendRequest<ValueResponse>("value/byepisodeguid", parameters);
            return valueResponse.Value;
        }

    }
}