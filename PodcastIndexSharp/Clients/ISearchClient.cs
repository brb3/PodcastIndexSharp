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
        /// <param name="term">Terms to search for.</param>
        /// <param name="values">
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
        Task<List<Podcast>> Podcasts(string query, SearchByTermValues? values = null, bool clean = false, bool fulltext = false);

        /// <summary>
        /// This call returns all of the episodes where the specified person is mentioned.
        /// </summary>
        /// <param name="person">Person to search for.</param>
        /// <param name="fulltext">
        /// If present, return the full text value of any text fields (ex: description).
        /// If not provided, field value is truncated to 100 words.
        /// </param>
        /// <returns></returns>
        Task<List<Episode>> EpisodesByPerson(string person, bool fulltext = false);
    }
}