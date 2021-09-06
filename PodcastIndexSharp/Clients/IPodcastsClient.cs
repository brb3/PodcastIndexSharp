namespace PodcastIndexSharp.Clients
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using PodcastIndexSharp.Model;

    public interface IPodcastsClient
    {
        /// <summary>
        /// Find details about a Podcast and its feed.<br />
        /// This call returns everything we know about the feed from the PodcastIndex ID.
        /// </summary>
        /// <param name="id">The PodcastIndex ID.</param>
        /// <returns></returns>
        Task<Podcast> ByFeedId(uint id);

        /// <summary>
        /// Find details about a Podcast and its feed.<br />
        /// This call returns everything we know about the feed from the feed URL.
        /// </summary>
        /// <param name="url">The Podcast feed URL.</param>
        /// <returns></returns>
        Task<Podcast> ByFeedUrl(Uri url);

        /// <summary>
        /// Find details about a Podcast and its feed.<br />
        /// This call returns everything we know about the feed from the iTunes ID.
        /// </summary>
        /// <param name="id">The iTunes ID.</param>
        /// <returns></returns>
        Task<Podcast> ByiTunesId(uint id);

        /// <summary>
        /// Find details about a Podcast and its feed.<br />
        /// This call returns everything we know about the feed from the feed's GUID.
        /// </summary>
        /// <param name="id">The feed's GUID.</param>
        /// <returns></returns>
        Task<Podcast> ByGUID(Guid guid);

        /// <summary>
        /// Find details about a Podcast and its feed.<br />
        /// This call returns the podcasts/feeds that in the index that are trending.
        /// </summary>
        /// <param name="max">Maximum number of results to return.</param>
        /// <param name="since">Return items since the specified time.</param>
        /// <param name="lang">
        /// Specifying a language code (like "en") will return only episodes having that specific language.<br />
        /// You can specify multiple languages by separating them with commas.<br />
        /// If you also want to return episodes that have no language given, use the token "unknown". (ex. en,es,ja,unknown).
        /// </param>
        /// <param name="category">
        /// Use this argument to specify that you ONLY want episodes with these categories in the results.<br />
        /// Separate multiple categories with commas.<br />
        /// You may specify either the Category ID and/or the Category Name.<br />
        /// Values are not case sensitive.<br />
        /// The `category` and `excludeCategory` filters can be used together to fine tune a very specific result set.
        /// </param>
        /// <param name="excludeCategory">
        /// Use this argument to specify categories of episodes to NOT show in the results.<br />
        /// Separate multiple categories with commas.<br />
        /// You may specify either the Category ID and/or the Category Name.<br />
        /// Values are not case sensitive.<br />
        /// The `category` and `excludeCategory` filters can be used together to fine tune a very specific result set.
        /// </param>
        /// <returns></returns>
        Task<List<Podcast>> Trending(int max = 10, string lang = null, string category = null, string excludeCategory = null, DateTime? since = null);

        /// <summary>
        /// This call returns all feeds that have been marked dead.
        /// </summary>
        /// <returns></returns>
        Task<List<Podcast>> Dead();
    }
}