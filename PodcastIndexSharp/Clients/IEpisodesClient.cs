namespace PodcastIndexSharp.Clients
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using PodcastIndexSharp.Model;

    public interface IEpisodesClient
    {
        /// <summary>
        /// Find details about one or more episodes of a podcast.
        /// </summary>
        /// <param name="id">The PodcastIndex Feed ID to search for.</param>
        /// <param name="max">Maximum number of results to return. Must be &gt;= 1 and &lt;= 1000</param>
        /// <param name="fulltext">
        /// If present, return the full text value of any text fields (ex: description).<br />
        /// If not provided, field value is truncated to 100 words.
        /// </param>
        /// <param name="since">Return items since the specified time.</param>
        /// <returns></returns>
        Task<List<Episode>> ByFeedId(uint id, int max = 10, bool fulltext = false, DateTime? since = null);

        /// <summary>
        /// Find details about one or more episodes of a podcast.
        /// </summary>
        /// <param name="id">A list of PodcastIndex Feed IDs to search for.</param>
        /// <param name="max">Maximum number of results to return. Must be &gt;= 1 and &lt;= 1000</param>
        /// <param name="fulltext">
        /// If present, return the full text value of any text fields (ex: description).<br />
        /// If not provided, field value is truncated to 100 words.
        /// </param>
        /// <param name="since">Return items since the specified time.</param>
        /// <returns></returns>
        Task<List<Episode>> ByFeedId(uint[] id, int max = 10, bool fulltext = false, DateTime? since = null);

        /// <summary>
        /// Find details about one or more episodes of a podcast.<br />
        /// This call returns all the episodes we know about for this feed from the feed URL.<br />
        /// Episodes are in reverse chronological order.
        /// </summary>
        /// <param name="url">Podcast feed URL.</param>
        /// <param name="max">Maximum number of results to return. Must be &gt;= 1 and &lt;= 1000</param>
        /// <param name="fulltext">
        /// If present, return the full text value of any text fields (ex: description).<br />
        /// If not provided, field value is truncated to 100 words.
        /// </param>
        /// <param name="since">Return items since the specified time. </param>
        /// <returns></returns>
        Task<List<Episode>> ByFeedUrl(Uri url, int max = 10, bool fulltext = false, DateTime? since = null);

        /// <summary>
        /// Find details about one or more episodes of a podcast.
        /// </summary>
        /// <param name="id">The iTunes ID to search for.</param>
        /// <param name="max">Maximum number of results to return. Must be &gt;= 1 and &lt;= 1000</param>
        /// <param name="fulltext">
        /// If present, return the full text value of any text fields (ex: description).<br />
        /// If not provided, field value is truncated to 100 words.
        /// </param>
        /// <param name="since">Return items since the specified time.</param>
        /// <returns></returns>
        Task<List<Episode>> ByiTunesId(uint id, int max = 10, bool fulltext = false, DateTime? since = null);

        /// <summary>
        /// Find details about one episode of a podcast.<br />
        /// </summary>
        /// <param name="id">The PodcastIndex episode ID to search for.</param>
        /// <param name="fulltext">
        /// If present, return the full text value of any text fields (ex: description).<br />
        /// If not provided, field value is truncated to 100 words.
        /// </param>
        /// <returns></returns>
        Task<Episode> ById(uint id, bool fulltext = false);

        /// <summary>
        /// This call returns a random batch of episodes, in no specific order.
        /// </summary>
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
        /// <param name="fulltext">
        /// If present, return the full text value of any text fields (ex: description).<br />
        /// If not provided, field value is truncated to 100 words.
        /// </param>
        /// <param name="max">Maximum number of results to return. &gt;=1 and &lt;= 1000</param>
        /// <returns></returns>
        Task<List<Episode>> Random(string lang = "", string category = "", string excludeCategory = "", bool fulltext = false, int max = 1);

    }
}