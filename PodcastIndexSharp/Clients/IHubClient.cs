namespace PodcastIndexSharp.Clients
{
    using System;
    using System.Threading.Tasks;
    using PodcastIndexSharp.Response;

    public interface IHubClient
    {
        /// <summary>
        /// Notify the index that a feed has changed
        /// The `id` or the `url` is required.
        /// </summary>
        /// <param name="id">The PodcastIndex Feed ID</param>
        /// <param name="url">Podcast feed URL </param>
        /// <returns></returns>
        Task<HubResponse> PubNotify(uint? id = null, Uri? url = null);
    }
}