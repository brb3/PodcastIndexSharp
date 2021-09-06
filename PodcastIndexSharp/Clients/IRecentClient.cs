namespace PodcastIndexSharp.Clients
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using PodcastIndexSharp.Model;

    public interface IRecentClient
    {
        /// <summary>
        /// This call returns the most recent max number of episodes globally across the whole index,
        /// in reverse chronological order.
        /// </summary>
        /// <param name="exclude">
        /// Any item containing this string will be discarded from the result set.<br />
        /// This may, in certain cases, reduce your set size below your max value.<br />
        /// Matches against the title and URL properties.
        /// </param>
        /// <param name="beforeId">
        /// If you pass a PodcastIndex Episode ID, you will get recent episodes before that ID,
        /// allowing you to walk back through the episode history sequentially.
        /// </param>
        /// <param name="fulltext">
        /// If present, return the full text value of any text fields (ex: description).<br />
        /// If not provided, field value is truncated to 100 words.
        /// </param>
        /// <param name="max">Maximum number of results to return. &gt;=1 and &lt;= 1000</param>
        /// <returns></returns>
        Task<List<Episode>> Episodes(string exclude = "", bool fulltext = false, int max = 10, int? beforeId = null);

        /// <summary>
        /// This call returns the most recent max feeds, in reverse chronological order.
        /// </summary>
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
        /// <param name="max">Maximum number of results to return. &gt;= 1 and &lt;= 1000</param>
        /// <returns></returns>
        Task<List<Podcast>> Podcasts(string lang = "", string category = "", string excludeCategory = "", int max = 10, DateTime? since = null);

        /// <summary>
        /// This call returns every new feed added to the index over the past 24 hours in reverse chronological order.
        /// </summary>
        /// <param name="since">Return items since the specified time.</param>
        /// <param name="max">Maximum number of results to return. &gt;= 1 and &lt;= 1000</param>
        /// <returns></returns>
        Task<List<Podcast>> NewPodcasts(int max = 10, DateTime? since = null);

        /// <summary>
        /// This call returns the most recent max soundbites that the index has discovered.
        /// </summary>
        /// <param name="max">Maximum number of soundbites to return. &gt;=1 and &lt;= 1000</param>
        /// <returns></returns>
        Task<List<Soundbite>> Soundbites(int max = 10);
    }
}