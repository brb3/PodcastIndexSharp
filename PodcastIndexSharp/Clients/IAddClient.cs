namespace PodcastIndexSharp.Clients
{
    using System.Threading.Tasks;
    using PodcastIndexSharp.Response;

    public interface IAddClient
    {
        /// <summary>
        /// This call adds a podcast to the index using its feed url.
        /// If a feed already exists, you will get its existing Feed ID returned in the response object.
        /// </summary>
        /// <param name="url"></param>
        /// <param name="iTunesId"></param>
        /// <param name="chash">MD5 hash of the title, link, feedLanguage, generator, author, ownerName, ownerEmail. Allows for easier duplicate checking.</param>
        /// <returns></returns>
        Task<AddResponse> ByFeedUrl(string url, uint iTunesId, string chash);

        /// <summary>
        /// This call adds a podcast to the index using its iTunes ID.
        /// If a feed already exists, it will be noted in the response object.
        /// </summary>
        /// <param name="iTunesId"></param>
        /// <returns></returns>
        Task<AddResponse> ByiTunesId(uint iTunesId);
    }
}