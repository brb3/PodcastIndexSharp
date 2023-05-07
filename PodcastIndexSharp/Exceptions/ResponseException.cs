namespace PodcastIndexSharp.Exceptions {
    using System;

    /// <summary>
    /// Exception thrown when the PodcastIndex API responds with a Failure status.
    /// </summary>
    public class ResponseException : Exception
    {
        public ResponseException(string message) : base(message) { }
    }
}