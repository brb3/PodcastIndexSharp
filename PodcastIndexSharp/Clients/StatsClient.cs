namespace PodcastIndexSharp.Clients
{
    using System.Threading.Tasks;
    using PodcastIndexSharp.Model;
    using PodcastIndexSharp.Response;

    public class StatsClient : BaseClient, IStatsClient
    {
        public StatsClient(PodcastIndexConfig config) : base(config) { }

        public async Task<Stats> Current()
        {
            var statsResponse = await SendRequest<StatsResponse>("stats/current", new ApiParameter[] { });
            return statsResponse.Stats;
        }
    }
}