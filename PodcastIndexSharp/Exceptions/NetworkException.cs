namespace PodcastIndexSharp.Exceptions
{
    using System;

    /// <summary>
    /// Exception thrown when the PodcastIndex API cannot be reached.
    /// Will contain an inner exception from Flurl.
    /// </summary>
    public class NetworkException : Exception
    {
        public NetworkException(Exception ex) : base("Failed to complete API request to PodcastIndex.", ex) { }
    }
}