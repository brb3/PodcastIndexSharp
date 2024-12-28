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
        Task<List<Episode>> ByFeedId(uint id, int? max = null, bool? fulltext = null, DateTime? since = null);

        /// <summary>
        /// Find details about one or more episodes of a podcast.
        /// </summary>
        /// <param name="id">A list of PodcastIndex Feed IDs to search for.</param>
        /// <param name="fulltext">
        /// If present, return the full text value of any text fields (ex: description).<br />
        /// If not provided, field value is truncated to 100 words.
        /// </param>
        /// <param name="since">Return items since the specified time.</param>
        /// <param name="max">Maximum number of results to return. Must be &gt;= 1 and &lt;= 1000</param>
        /// <returns></returns>
        Task<List<Episode>> ByFeedId(uint[] id, int? max = null, bool? fulltext = null, DateTime? since = null);

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
        Task<List<Episode>> ByFeedUrl(Uri url, int? max = null, bool? fulltext = null, DateTime? since = null);

        /// <summary>
        /// Returns episodes known for a podcast by the <see href="https://github.com/Podcastindex-org/podcast-namespace/blob/main/docs/1.0.md#guid">Podcast GUID</see>.
        /// </summary>
        /// <param name="guid">
        /// The GUID from the `podcast:guid` tag in the feed.
        /// </param>
        /// <param name="max">
        /// Maximum number of results to return. &gt;=1 and &lt;= 1000
        /// </param>
        /// <param name="fulltext">
        /// If present, return the full text value of any text fields (ex: description).<br />
        /// If not provided, field value is truncated to 100 words.
        /// </param>
        /// <param name="since">
        /// Return items since the specified time.
        /// </param>
        /// <returns></returns>
        Task<List<Episode>> ByPodcastGUID(Guid guid, int? max = null, bool? fulltext = null, DateTime? since = null);

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
        /// <param name="enclosure">The URL for the episode enclosure to get the information for.</param>
        /// <returns></returns>
        Task<List<Episode>> ByiTunesId(
            uint id,
            int? max = null,
            bool? fulltext = null,
            DateTime? since = null,
            Uri? enclosure = null);

        /// <summary>
        /// Find details about one episode of a podcast.<br />
        /// </summary>
        /// <param name="id">The PodcastIndex episode ID to search for.</param>
        /// <param name="fulltext">
        /// If present, return the full text value of any text fields (ex: description).<br />
        /// If not provided, field value is truncated to 100 words.
        /// </param>
        /// <returns></returns>
        Task<Episode> ById(uint id, bool? fulltext = false);

        /// <summary>
        /// Get all the metadata for a single episode by passing its guid and the feed id or URL.<br />
        /// The feedId, feedUrl, or podcastGUID must be provided.
        /// </summary>
        /// <param name="guid">The guid value for the episode to retrieve.</param>
        /// <param name="feedUrl">The feed URL</param>
        /// <param name="feedId">The PodcastIndex Feed ID</param>
        /// <param name="podcastGUID">
        /// The GUID from the podcast:guid tag in the feed.
        /// This value is a unique, global identifier for the podcast.
        /// </param>
        /// <param name="fulltext">
        /// If true, return the full text value of any text fields (ex: description).
        /// If false, field value is truncated to 100 words.
        /// </param>
        /// <returns></returns>
        Task<Episode> ByGUID(
            Guid guid,
            string? feedUrl = null,
            string? feedId = null,
            Guid? podcastGUID = null,
            bool? fulltext = null);

        /// <summary>
        /// Get all episodes that have been found in the "podcast:liveitem" from the feeds
        /// </summary>
        /// <param name="max">
        /// Maximum number of results to return. &gt;=1 and &lt;= 1000
        /// </param>
        /// <returns></returns>
        Task<List<Episode>> Live(int? max = null);

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
        Task<List<Episode>> Random(
            string? lang = null,
            string? category = null,
            string? excludeCategory = null,
            bool? fulltext = null,
            int? max = null);
    }
}