namespace PodcastIndexSharp
{
    using PodcastIndexSharp.Clients;

    public interface IPodcastIndex
    {
        /// <summary>
        /// Search for the index.
        /// </summary>
        /// <returns></returns>
        ISearchClient Search();

        /// <summary>
        /// Find details about a Podcast and its feed.
        /// </summary>
        /// <returns></returns>
        IPodcastsClient Podcasts();

        /// <summary>
        /// Find details about one or more episodes of a podcast or podcast.
        /// </summary>
        /// <returns></returns>
        IEpisodesClient Episodes();

        /// <summary>
        /// Find recent additions to the index.
        /// </summary>
        /// <returns></returns>
        IRecentClient Recent();

        /// <summary>
        /// The podcast's "Value for Value" information.
        /// </summary>
        /// <returns></returns>
        IValueClient Value();

        /// <summary>
        /// Statistics for items in the Podcast Index.
        /// </summary>
        /// <returns></returns>
        IStatsClient Stats();

        /// <summary>
        /// Categories used by the Podcast Index
        /// </summary>
        /// <returns></returns>
        ICategoriesClient Categories();

        /// <summary>
        /// Notify the index that a feed has changed
        /// </summary>
        /// <returns></returns>
        IHubClient Hub();

        /// <summary>
        /// Add new podcast feeds to the index.
        ///
        /// NOTE: To add to the index, the API Key must have write or publisher permissions.
        /// </summary>
        /// <returns></returns>
        IAddClient Add();
    }
}