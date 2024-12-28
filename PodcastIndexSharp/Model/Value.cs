namespace PodcastIndexSharp.Model
{
    using System.Collections.Generic;

    public class Value
    {
        public ValueModel Model { get; set; } = null!;

        public List<ValueDestination> Suggested { get; set; } = null!;
    }
}