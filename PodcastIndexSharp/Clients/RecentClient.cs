namespace PodcastIndexSharp.Clients
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using PodcastIndexSharp.Model;
    using PodcastIndexSharp.Response;

    public class RecentClient : BaseClient, IRecentClient
    {
        public RecentClient(PodcastIndexConfig config) : base(config) { }

        public async Task<List<Episode>> Episodes(string exclude = "", bool fulltext = false, int max = 10, int? beforeId = null)
        {
            var parameters = new ApiParameter[]{
                new ApiParameter("max", max),
                new ApiParameter("excludeString", exclude),
                new ApiParameter("before", beforeId),
                new ApiParameter("fulltext", fulltext),
            };

            var recentEpisodesResponse = await SendRequest<RecentEpisodesResponse>("recent/episodes", parameters);
            return recentEpisodesResponse.Episodes;
        }

        public async Task<List<Podcast>> Podcasts(string lang = "", string category = "", string excludeCategory = "'", int max = 10, DateTime? since = null)
        {
            var parameters = new ApiParameter[]{
                new ApiParameter("max", max),
                new ApiParameter("lang", lang),
                new ApiParameter("category", category),
                new ApiParameter("excludeCategory", excludeCategory),
                new ApiParameter("since", since),
            };

            var feedsResponse = await SendRequest<FeedsResponse>("recent/feeds", parameters);
            return feedsResponse.Podcasts;
        }

        public async Task<List<Podcast>> NewPodcasts(int max = 10, DateTime? since = null)
        {
            var parameters = new ApiParameter[]{
                new ApiParameter("max", max),
                new ApiParameter("since", since),
            };

            var feedsResponse = await SendRequest<FeedsResponse>("recent/newfeeds", parameters);
            return feedsResponse.Podcasts;
        }

        public async Task<List<Soundbite>> Soundbites(int max = 10)
        {
            var parameters = new ApiParameter[]{
                new ApiParameter("max", max),
            };

            var soundbitesResponse = await SendRequest<SoundbitesResponse>("recent/soundbites", parameters);
            return soundbitesResponse.Soundbites;
        }
    }
}