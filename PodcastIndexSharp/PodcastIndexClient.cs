namespace PodcastIndexSharp
{
    using System;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Threading.Tasks;
    using Flurl;
    using Flurl.Http;
    using PodcastIndexSharp.Enums;
    using PodcastIndexSharp.Response;

    public class PodcastIndexClient : IPodcastIndexClient
    {
        protected PodcastIndexConfig Config { get; }

        public PodcastIndexClient(PodcastIndexConfig config)
        {
            Config = config;
        }

        public async Task<FeedsResponse> Search(string term, SearchByTermValues? val = null, bool clean = false, bool fulltext = false)
        {
            var endpoint = GetAuthorizedRequest("search/byterm")
                .SetQueryParam("q", term);

            if (val != null)
            {
                endpoint.SetQueryParam("val", val.ToString());
            }

            if (clean)
            {
                endpoint.SetQueryParam("clean", "");
            }

            if (fulltext)
            {
                endpoint.SetQueryParam("fulltext", "");
            }

            return await endpoint.GetJsonAsync<FeedsResponse>();
        }

        public async Task<EpisodesResponse> SearchByPerson(string person, bool fulltext = false)
        {
            var endpoint = GetAuthorizedRequest("search/byperson")
                .SetQueryParam("q", person);

            if (fulltext)
            {
                endpoint.SetQueryParam("fulltext", "");
            }

            return await endpoint.GetJsonAsync<EpisodesResponse>();
        }

        public async Task<PodcastResponse> Podcast(int id, bool itunes)
        {
            var segment = itunes ? "podcasts/byitunesid" : "podcasts/byfeedid";
            var endpoint = GetAuthorizedRequest(segment)
                .SetQueryParam("id", id);

            return await endpoint.GetJsonAsync<PodcastResponse>();
        }

        public async Task<PodcastResponse> Podcast(Uri url)
        {
            var endpoint = GetAuthorizedRequest("podcasts/byfeedurl")
                    .SetQueryParam("url", url);

            return await endpoint.GetJsonAsync<PodcastResponse>();
        }

        public async Task<TrendingResponse> TrendingPodcasts(int max, string lang = null, string category = null, string excludeCategory = null, DateTime? since = null)
        {
            var endpoint = GetAuthorizedRequest("podcasts/trending")
                .SetQueryParam("max", max);

            if (since != null)
            {
                endpoint.SetQueryParam("since", ToUnixTimeStamp(since));
            }

            if (!string.IsNullOrEmpty(lang))
            {
                endpoint.SetQueryParam("lang", lang);
            }

            if (!string.IsNullOrEmpty(category))
            {
                endpoint.SetQueryParam("category", category);
            }

            if (!string.IsNullOrEmpty(excludeCategory))
            {
                endpoint.SetQueryParam("excludeCategory", excludeCategory);
            }

            return await endpoint.GetJsonAsync<TrendingResponse>();
        }

        public async Task<DeadResponse> DeadPodcasts()
        {
            var endpoint = GetAuthorizedRequest("podcasts/dead");

            return await endpoint.GetJsonAsync<DeadResponse>();
        }

        public async Task<EpisodesResponse> Episodes(int id, int max, bool fulltext = false, bool itunes = false, DateTime? since = null)
        {
            return await Episodes(id.ToString(), max, fulltext, itunes, since);
        }

        public async Task<EpisodesResponse> Episodes(int[] id, int max, bool fulltext = false, bool itunes = false, DateTime? since = null)
        {
            return await Episodes(string.Join(",", id), max, fulltext, itunes, since);
        }

        public async Task<EpisodesResponse> Episodes(string url, int max, bool fulltext = false, DateTime? since = null)
        {
            var endpoint = GetAuthorizedRequest("episodes/byfeedurl")
                .SetQueryParam("url", url)
                .SetQueryParam("max", max);

            if (since != null)
            {
                endpoint.SetQueryParam("since", ToUnixTimeStamp(since));
            }

            if (fulltext)
            {
                endpoint.SetQueryParam("fulltext", "");
            }

            return await endpoint.GetJsonAsync<EpisodesResponse>();
        }

        public async Task<EpisodeResponse> Episode(int id, bool fulltext = false)
        {
            var endpoint = GetAuthorizedRequest("episodes/byid")
                .SetQueryParam("id", id);

            if (fulltext)
            {
                endpoint.SetQueryParam("fulltext", "");
            }

            return await endpoint.GetJsonAsync<EpisodeResponse>();
        }

        public async Task<EpisodesResponse> RandomEpisodes(string lang = "", string category = "", string excludeCategory = "", bool fulltext = false, int max = 1)
        {
            var endpoint = GetAuthorizedRequest("episodes/random")
                .SetQueryParam("max", max);

            if (!string.IsNullOrEmpty(lang))
            {
                endpoint.SetQueryParam("lang", lang);
            }

            if (!string.IsNullOrEmpty(category))
            {
                endpoint.SetQueryParam("category", category);
            }

            if (!string.IsNullOrEmpty(excludeCategory))
            {
                endpoint.SetQueryParam("excludeCategory", excludeCategory);
            }

            if (fulltext)
            {
                endpoint.SetQueryParam("fulltext", "");
            }

            return await endpoint.GetJsonAsync<EpisodesResponse>();
        }

        public async Task<RecentEpisodesResponse> RecentEpisodes(string exclude = "", bool fulltext = false, int max = 10, int? beforeId = null)
        {
            var endpoint = GetAuthorizedRequest("recent/episodes")
                .SetQueryParam("max", max);

            if (!string.IsNullOrEmpty(exclude))
            {
                endpoint.SetQueryParam("exclude", exclude);
            }

            if (beforeId != null)
            {
                endpoint.SetQueryParam("beforeId", beforeId);
            }

            if (fulltext)
            {
                endpoint.SetQueryParam("fulltext", "");
            }

            return await endpoint.GetJsonAsync<RecentEpisodesResponse>();
        }

        public async Task<FeedsResponse> RecentFeeds(string lang = "", string category = "", string excludeCategory = "'", int max = 40, DateTime? since = null)
        {
            var endpoint = GetAuthorizedRequest("recent/feeds")
                .SetQueryParam("max", max);

            if (!string.IsNullOrEmpty(lang))
            {
                endpoint.SetQueryParam("lang", lang);
            }

            if (!string.IsNullOrEmpty(category))
            {
                endpoint.SetQueryParam("category", category);
            }

            if (!string.IsNullOrEmpty(excludeCategory))
            {
                endpoint.SetQueryParam("excludeCategory", excludeCategory);
            }

            if (since != null)
            {
                endpoint.SetQueryParam("since", ToUnixTimeStamp(since));
            }

            return await endpoint.GetJsonAsync<FeedsResponse>();
        }

        public async Task<FeedsResponse> NewFeeds(int max = 40, DateTime? since = null)
        {
            var endpoint = GetAuthorizedRequest("recent/newfeeds")
                .SetQueryParam("max", max);

            if (since != null)
            {
                endpoint.SetQueryParam("since", ToUnixTimeStamp(since));
            }

            return await endpoint.GetJsonAsync<FeedsResponse>();
        }

        public async Task<SoundbitesResponse> RecentSoundbites(int max = 60)
        {
            var endpoint = GetAuthorizedRequest("recent/soundbites")
                .SetQueryParam("max", max);

            return await endpoint.GetJsonAsync<SoundbitesResponse>();
        }

        public async Task<ValueResponse> Value(int id)
        {
            var endpoint = GetAuthorizedRequest("value/byfeedid")
                .SetQueryParam("id", id);

            return await endpoint.GetJsonAsync<ValueResponse>();
        }

        public async Task<ValueResponse> Value(string url)
        {
            var endpoint = GetAuthorizedRequest("value/byfeedurl")
                .SetQueryParam("url", url);

            return await endpoint.GetJsonAsync<ValueResponse>();
        }

        public async Task<StatsResponse> Stats()
        {
            var endpoint = GetAuthorizedRequest("stats/current");

            return await endpoint.GetJsonAsync<StatsResponse>();
        }

        private async Task<EpisodesResponse> Episodes(string id, int max, bool fulltext, bool itunes, DateTime? since)
        {
            var segment = itunes ? "episodes/byitunesid" : "episodes/byfeedid";
            var endpoint = GetAuthorizedRequest(segment)
                .SetQueryParam("id", id)
                .SetQueryParam("max", max);

            if (since != null)
            {
                endpoint.SetQueryParam("since", ToUnixTimeStamp(since));
            }

            if (fulltext)
            {
                endpoint.SetQueryParam("fulltext", "");
            }

            return await endpoint.GetJsonAsync<EpisodesResponse>();
        }

        /// <summary>
        /// Creates an IFlurlRequest with the authorization headers in place.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private IFlurlRequest GetAuthorizedRequest(string path)
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
        private string ToUnixTimeStamp(DateTime? dateTime)
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
