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
        /// Find details about one or more episodes of a podcats or podcats.
        /// </summary>
        /// <returns></returns>
        IEpisodesClient Episodes();

        /// <summary>
        /// Find recent additions to the index.
        /// </summary>
        /// <returns></returns>
        IRecentClient Recent();

        /// <summary>
        /// The podcat's "Value for Value" information.
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
    }
}