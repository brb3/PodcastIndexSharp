namespace PodcastIndexSharp.Clients
{
    using System;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using Flurl;
    using Flurl.Http;

    public class BaseClient
    {
        protected PodcastIndexConfig Config { get; }

        public BaseClient(PodcastIndexConfig config)
        {
            Config = config;
        }

        /// <summary>
        /// Creates an IFlurlRequest with the authorization headers in place.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        protected IFlurlRequest GetAuthorizedRequest(string path)
        {
            var key = Config.AuthKey;
            var secret = Config.Secret;
            var timestamp = ToUnixTimeStamp(DateTime.Now);

            var hash = new SHA1Managed().ComputeHash(Encoding.UTF8.GetBytes(
                $"{key}{secret}{timestamp}"
            ));

            var authorization = string.Concat(hash.Select(b => b.ToString("x2")));

            return Config.BaseUrl
                .AppendPathSegment(path)
                .WithHeader("User-Agent", Config.UserAgent)
                .WithHeader("X-Auth-Date", timestamp)
                .WithHeader("X-Auth-Key", key)
                .WithHeader("Authorization", authorization);
        }

        /// <summary>
        /// Converts a DateTime to a UnixTimeStamp string
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        protected string ToUnixTimeStamp(DateTime? dateTime)
        {
            if (dateTime == null)
            {
                return "";
            }

            var dto = (DateTimeOffset)dateTime;

            return dto.ToUnixTimeSeconds().ToString();
        }
    }
}