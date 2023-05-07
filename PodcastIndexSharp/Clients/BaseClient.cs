namespace PodcastIndexSharp.Clients
{
    using System;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Threading.Tasks;
    using Flurl;
    using Flurl.Http;
    using PodcastIndexSharp.Exceptions;

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
                return string.Empty;
            }

            var dto = (DateTimeOffset)dateTime;

            return dto.ToUnixTimeSeconds().ToString();
        }

        /// <summary>
        /// A wrapper around Flurl's GetJsonAsync to act as a convenience around Status checks and network failures.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="ResponseException">Thrown when the API has a "false" status message.</exception>
        /// <exception cref="NetworkException">Thrown when there is a network level failure communicating with the API.</exception>
        protected async Task<T> GetResponse<T>(IFlurlRequest request) where T : AbstractResponse
        {
            try
            {
                var response = await request.GetJsonAsync<T>();

                if (response.Status == "false")
                {
                    throw new ResponseException($"Call to {request.Url} failed.");
                }

                return response;
            }
            catch (FlurlHttpException e)
            {
                throw new NetworkException(e);
            }
        }
    }
}