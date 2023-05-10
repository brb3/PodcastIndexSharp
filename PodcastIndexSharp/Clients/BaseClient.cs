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
    using PodcastIndexSharp.Model;

    /// <summary>
    /// The Base API client that all PodcastIndex API calls use. This class should not be used directly.
    /// </summary>
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

        /// <summary>
        /// Abstraction for clients to allow them to define a set of parameters and be handled
        /// without needing custom checks in each client class.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="endpointFragment"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        protected async Task<T> SendRequest<T>(string endpointFragment, ApiParameter[] parameters) where T : AbstractResponse
        {
            var endpoint = GetAuthorizedRequest(endpointFragment);

            foreach (var parameter in parameters)
            {
                if (parameter.Value == null)
                {
                    continue;
                }

                switch (Type.GetTypeCode(parameter.Value.GetType()))
                {
                    case TypeCode.Boolean:
                        if ((bool)parameter.Value)
                        {
                            // Empty value toggles on. Omitting toggles off.
                            endpoint.SetQueryParam(parameter.Name, "");
                        }
                        break;
                    case TypeCode.DateTime:
                        endpoint.SetQueryParam(parameter.Name, ToUnixTimeStamp((DateTime)parameter.Value));
                        break;
                    case TypeCode.String:
                    case TypeCode.Int32:
                    case TypeCode.UInt32:
                        endpoint.SetQueryParam(parameter.Name, parameter.Value);
                        break;
                    default:
                        endpoint.SetQueryParam(parameter.Name, parameter.Value.ToString());
                        break;
                }
            }

            return await GetResponse<T>(endpoint);
        }
    }
}