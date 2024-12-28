namespace PodcastIndexSharp.Model
{
    public class ValueDestination
    {
        public string Name { get; set; } = null!;

        public string Address { get; set; } = null!;

        public string Type { get; set; } = null!;

        public int Split { get; set; }

        public bool Fee { get; set; }
    }
}