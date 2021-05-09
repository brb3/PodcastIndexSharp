namespace PodcastIndexSharp.Model
{
    using System.Collections.Generic;

    public class Value
    {
        public ValueModel Model { get; set; }

        public List<ValueDestination> Suggested { get; set; }
    }
}