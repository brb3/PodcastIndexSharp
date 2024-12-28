namespace PodcastIndexSharp.Clients
{
    using System;
    using System.Threading.Tasks;
    using PodcastIndexSharp.Model;

    public interface IValueClient
    {
        /// <summary>
        /// The podcast's "Value for Value" information<br />
        /// This call returns the information for supporting the podcast via one of the "Value for Value"
        /// methods from the PodcastIndex ID.
        /// </summary>
        /// <param name="id">The PodcastIndex Feed ID to search for.</param>
        /// <returns></returns>
        Task<Value> ByFeedId(uint id);

        /// <summary>
        /// The podcast's "Value for Value" information<br />
        /// This call returns the information for supporting the podcast via one of the "Value for Value"
        /// methods from the feed URL.
        /// </summary>
        /// <param name="url">Podcast feed URL.</param>
        /// <returns></returns>
        Task<Value> ByFeedUrl(Uri url);

        /// <summary>
        /// The podcast's "Value for Value" information<br />
        /// This call returns the information for supporting the podcast via one of the "Value for Value"
        /// methods from podcast GUID.
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        Task<Value> ByFeedGUID(Guid guid);

        /// <summary>
        /// The podcast's "Value for Value" information<br />
        /// This call returns the information for supporting the podcast episode via one of the "Value for Value"
        /// methods from podcast GUID and the episode GUID.
        /// </summary>
        /// <param name="podcastGUID"></param>
        /// <param name="episodeGUID"></param>
        /// <returns></returns>
        Task<Value> ByEpisodeGUID(Guid podcastGUID, Guid episodeGUID);
    }
}