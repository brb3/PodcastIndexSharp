namespace PodcastIndexSharp.Clients
{
    using System.Threading.Tasks;
    using Flurl.Http;
    using PodcastIndexSharp.Model;
    using PodcastIndexSharp.Response;

    public class StatsClient : BaseClient, IStatsClient
    {
        public StatsClient(PodcastIndexConfig config) : base(config) { }

        public async Task<Stats> Current()
        {
            var endpoint = GetAuthorizedRequest("stats/current");

            var statsResponse = await GetResponse<StatsResponse>(endpoint);

            return statsResponse.Stats;
        }
    }
}