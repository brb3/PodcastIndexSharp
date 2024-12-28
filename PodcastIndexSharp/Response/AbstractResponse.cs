namespace PodcastIndexSharp.Response
{
    public abstract class AbstractResponse
    {
        public string Status { get; set; } = null!;

        public object Query { get; set; } = null!;

        public string Description { get; set; } = null!;
    }
}