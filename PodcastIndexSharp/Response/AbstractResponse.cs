namespace PodcastIndexSharp
{
    public abstract class AbstractResponse
    {
        public string Status { get; set; }

        public object Query { get; set; }

        public string Description { get; set; }
    }
}