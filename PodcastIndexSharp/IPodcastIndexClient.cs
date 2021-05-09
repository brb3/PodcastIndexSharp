namespace PodcastIndexSharp
{
    using System;
    using System.Threading.Tasks;
    using PodcastIndexSharp.Enums;
    using PodcastIndexSharp.Response;

    public interface IPodcastIndexClient
    {
        /// <summary>
        /// Search the index.<br />
        /// This call returns all of the feeds that match the search terms in the title, author or owner of the feed.
        /// This is ordered by the last-released episode, with the latest at the top of the results.
        /// </summary>
        /// <param name="term">Terms to search for.</param>
        /// <param name="val">
        /// Only returns feeds with a value block of the specified type.
        /// Use <see cref="PodcastIndexSharp.Enums.SearchByTermValues.any" /> to return feeds with any value block.
        /// </param>
        /// <param name="clean">
        /// If present, only non-explicit feeds will be returned.
        /// Meaning, feeds where the itunes:explicit flag is set to false.
        /// </param>
        /// <param name="fulltext">
        /// If present, return the full text value of any text fields (ex: description).
        /// If not provided, field value is truncated to 100 words.
        /// </param>
        /// <returns></returns>
        Task<FeedsResponse> Search(string term, SearchByTermValues? val = null, bool clean = false, bool fulltext = false);

        /// <summary>
        /// Search the index.<br />
        /// This call returns all of the episodes where the specified person is mentioned.
        /// </summary>
        /// <param name="person">Person to search for.</param>
        /// <param name="fulltext">
        /// If present, return the full text value of any text fields (ex: description).
        /// If not provided, field value is truncated to 100 words.
        /// </param>
        /// <returns></returns>
        Task<EpisodesResponse> SearchByPerson(string person, bool fulltext = false);

        /// <summary>
        /// Find details about a Podcast and its feed.<br />
        /// This call returns everything we know about the feed from the PodcastIndex ID.
        /// </summary>
        /// <param name="id">The PodcastIndex Feed ID or iTunes ID to search for.</param>
        /// <param name="itunes">If true, the id parameter is handled as an iTunes ID.</param>
        /// <returns></returns>
        Task<PodcastResponse> Podcast(int id, bool itunes);

        /// <summary>
        /// Find details about a Podcast and its feed.<br />
        /// This call returns everything we know about the feed from the feed URL.
        /// </summary>
        /// <param name="url">Podcast feed URL.</param>
        /// <returns></returns>
        Task<PodcastResponse> Podcast(Uri url);

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
        Task<TrendingResponse> TrendingPodcasts(int max, string lang = null, string category = null, string excludeCategory = null, DateTime? since = null);

        /// <summary>
        /// This call returns all feeds that have been marked dead.
        /// </summary>
        /// <returns></returns>
        Task<DeadResponse> DeadPodcasts();

        /// <summary>
        /// Find details about one or more episodes of a podcast.
        /// </summary>
        /// <param name="id">The PodcastIndex Feed ID or iTunes ID to search for.</param>
        /// <param name="max">Maximum number of results to return. Must be &gt;= 1 and &lt;= 1000</param>
        /// <param name="since">Return items since the specified time.</param>
        /// <param name="fulltext">
        /// If present, return the full text value of any text fields (ex: description).<br />
        /// If not provided, field value is truncated to 100 words.
        /// </param>
        /// <param name="itunes">If true, the id parameter is handled as an iTunes ID.</param>
        /// <returns></returns>
        Task<EpisodesResponse> Episodes(int id, int max, bool fulltext = false, bool itunes = false, DateTime? since = null);

        /// <summary>
        /// Find details about one or more episodes of the specified podcasts.
        /// </summary>
        /// <param name="id">The PodcastIndex Feed IDs to search for.</param>
        /// <param name="max">Maximum number of results to return. Must be &gt;= 1 and &lt;= 1000</param>
        /// <param name="since">Return items since the specified time.</param>
        /// <param name="fulltext">
        /// If present, return the full text value of any text fields (ex: description).<br />
        /// If not provided, field value is truncated to 100 words.
        /// </param>
        /// <returns></returns>
        Task<EpisodesResponse> Episodes(int[] id, int max, bool fulltext = false, bool itunes = false, DateTime? since = null);

        /// <summary>
        /// Find details about one or more episodes of a podcast.<br />
        /// This call returns all the episodes we know about for this feed from the feed URL.<br />
        /// Episodes are in reverse chronological order.
        /// </summary>
        /// <param name="url">Podcast feed URL.</param>
        /// <param name="max">Maximum number of results to return. Must be &gt;= 1 and &lt;= 1000</param>
        /// <param name="since">Return items since the specified time. </param>
        /// <param name="fulltext">
        /// If present, return the full text value of any text fields (ex: description).<br />
        /// If not provided, field value is truncated to 100 words.
        /// </param>
        /// <returns></returns>
        Task<EpisodesResponse> Episodes(string url, int max, bool fulltext = false, DateTime? since = null);

        /// <summary>
        /// Find details about one episode of a podcast.<br />
        /// </summary>
        /// <param name="id">The PodcastIndex episode ID to search for.</param>
        /// <param name="fulltext">
        /// If present, return the full text value of any text fields (ex: description).<br />
        /// If not provided, field value is truncated to 100 words.
        /// </param>
        /// <returns></returns>
        Task<EpisodeResponse> Episode(int id, bool fulltext = false);

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
        Task<EpisodesResponse> RandomEpisodes(string lang = "", string category = "", string excludeCategory = "", bool fulltext = false, int max = 1);

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
        Task<RecentEpisodesResponse> RecentEpisodes(string exclude = "", bool fulltext = false, int max = 10, int? beforeId = null);

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
        Task<FeedsResponse> RecentFeeds(string lang = "", string category = "", string excludeCategory = "", int max = 40, DateTime? since = null);
        /// <summary>
        /// This call returns every new feed added to the index over the past 24 hours in reverse chronological order.
        /// </summary>
        /// <param name="since">Return items since the specified time.</param>
        /// <param name="max">Maximum number of results to return. &gt;= 1 and &lt;= 1000</param>
        /// <returns></returns>
        Task<FeedsResponse> NewFeeds(int max = 40, DateTime? since = null);

        /// <summary>
        /// This call returns the most recent max soundbites that the index has discovered.
        /// </summary>
        /// <param name="max">Maximum number of soundbites to return. &gt;=1 and &lt;= 1000</param>
        /// <returns></returns>
        Task<SoundbitesResponse> RecentSoundbites(int max = 60);

        /// <summary>
        /// The podcast's "Value for Value" information<br />
        /// This call returns the information for supporting the podcast via one of the "Value for Value"
        /// methods from the PodcastIndex ID.
        /// </summary>
        /// <param name="id">The PodcastIndex Feed ID to search for.</param>
        /// <returns></returns>
        Task<ValueResponse> Value(int id);

        /// <summary>
        /// The podcast's "Value for Value" information<br />
        /// This call returns the information for supporting the podcast via one of the "Value for Value"
        /// methods from the feed URL.
        /// </summary>
        /// <param name="url">Podcast feed URL.</param>
        /// <returns></returns>
        Task<ValueResponse> Value(string url);

        /// <summary>
        /// Statistics for items in the Podcast Index<br />
        /// Return the most recent index statistics.
        /// </summary>
        /// <returns></returns>
        Task<StatsResponse> Stats();
    }
}