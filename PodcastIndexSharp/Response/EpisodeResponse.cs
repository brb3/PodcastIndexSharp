namespace PodcastIndexSharp.Response
{
    using PodcastIndexSharp.Model;

    public class EpisodeResponse : AbstractResponse
    {
        public Episode Episode { get; set; } = null!;
    }
}