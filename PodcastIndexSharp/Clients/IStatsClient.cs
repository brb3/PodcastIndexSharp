namespace PodcastIndexSharp.Clients
{
    using System.Threading.Tasks;
    using PodcastIndexSharp.Model;

    public interface IStatsClient
    {
        /// <summary>
        /// Statistics for items in the Podcast Index<br />
        /// Return the most recent index statistics.
        /// </summary>
        /// <returns></returns>
        Task<Stats> Current();
    }
}