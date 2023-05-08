namespace PodcastIndexSharp.Clients
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using PodcastIndexSharp.Enums;
    using PodcastIndexSharp.Model;

    public interface ISearchClient
    {
        /// <summary>
        /// This call returns all of the podcasts that match the search terms in the title, author or owner of the feed.
        /// This is ordered by the last-released episode, with the latest at the top of the results.
        /// </summary>
        /// <param name="query">Terms to search for.</param>
        /// <param name="values">
        /// Only returns feeds with a value block of the specified type.
        /// Use <see cref="PodcastIndexSharp.Enums.SearchByTermValues.any" /> to return feeds with any value block.
        /// </param>
        /// <param name="clean">
        /// If true, only non-explicit feeds will be returned.
        /// Meaning, feeds where the itunes:explicit flag is set to false.
        /// </param>
        /// <param name="fulltext">
        /// If true, return the full text value of any text fields (ex: description).
        /// If not provided, field value is truncated to 100 words.
        /// </param>
        /// <returns></returns>
        Task<List<Podcast>> Podcasts(string query, SearchByTermValues? values = null, bool clean = false, bool fulltext = false);

        /// <summary>
        /// This call returns all of the feeds where the title of the feed matches the search term (ignores case).
        /// </summary>
        /// <param name="query">Term to search for</param>
        /// <param name="value">Only returns feeds with a value block of the specified type. Use any to return feeds with any value block.</param>
        /// <param name="clean">If true, only non-explicit feeds will be returned. Meaning, feeds where the itunes:explicit flag is set to false.</param>
        /// <param name="fulltext">
        /// If true, return the full text value of any text fields (ex: description). If false, field value is truncated to 100 words.
        /// </param>
        /// <param name="similar">If true, include similar matches in search response</param>
        /// <returns></returns>
        Task<List<Podcast>> PodcastsByTitle(string query, SearchByTermValues? value = null, bool clean = false, bool fulltext = false, bool similar = false);

        /// <summary>
        /// This call returns all of the feeds that match the search terms in the title, author or owner of the where the medium is music.
        /// </summary>
        /// <param name="query">Terms to search for</param>
        /// <param name="value">
        /// Only returns feeds with a value block of the specified type. Use any to return feeds with any value block.
        /// </param>
        /// <param name="iTunesOnly">Only returns feeds with an itunesId.</param>
        /// <param name="max">Maximum number of results to return.</param>
        /// <param name="clean">
        /// If true, only non-explicit feeds will be returned. Meaning, feeds where the itunes:explicit flag is set to false.
        /// </param>
        /// <param name="fulltext">
        /// If true, return the full text value of any text fields (ex: description). If false, field value is truncated to 100 words.
        /// </param>
        /// <returns></returns>
        Task<List<Podcast>> MusicPodcasts(string query, SearchByTermValues? value = null, bool iTunesOnly = false, int max = 10, bool clean = false, bool fulltext = false);

        /// <summary>
        /// This call returns all of the episodes where the specified person is mentioned.
        /// </summary>
        /// <param name="person">Person to search for.</param>
        /// <param name="fulltext">
        /// If true, return the full text value of any text fields (ex: description).
        /// If false, field value is truncated to 100 words.
        /// </param>
        /// <returns></returns>
        Task<List<Episode>> EpisodesByPerson(string person, bool fulltext = false);
    }
}