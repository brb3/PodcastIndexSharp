namespace PodcastIndexSharp.Response
{
    public class AddResponse : AbstractResponse
    {
        /// <summary>
        /// The internal PodcastIndex.org Feed ID
        /// </summary>
        public int FeedId { get; set; }

        /// <summary>
        /// Indicates if feed already exists in the index
        /// </summary>
        public bool Existed { get; set; }
    }
}