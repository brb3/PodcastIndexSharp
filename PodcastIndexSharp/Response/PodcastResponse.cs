namespace PodcastIndexSharp.Response
{
    using PodcastIndexSharp.Model;

    public class PodcastResponse : AbstractResponse
    {
        public Feed Feed { get; set; }
    }
}