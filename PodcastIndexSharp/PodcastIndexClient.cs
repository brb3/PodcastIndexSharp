namespace PodcastIndexSharp
{
    using System;
    using PodcastIndexSharp.Enums;

    public class PodcastIndexClient : IPodcastIndexClient
    {
        public Response Add(string url, int itunesId)
        {
            throw new NotImplementedException();
        }

        public Response Add(int id)
        {
            throw new NotImplementedException();
        }

        public Response DeadPodcasts()
        {
            throw new NotImplementedException();
        }

        public Response Episode(int id, bool fulltext)
        {
            throw new NotImplementedException();
        }

        public Response Episodes(int id, int max, DateTime since, bool fulltext, bool itunes)
        {
            throw new NotImplementedException();
        }

        public Response Episodes(int[] id, int max, DateTime since, bool fulltext)
        {
            throw new NotImplementedException();
        }

        public Response Episodes(string url, int max, DateTime since, bool fulltext)
        {
            throw new NotImplementedException();
        }

        public Response NewFeeds(DateTime since, int max = 40)
        {
            throw new NotImplementedException();
        }

        public Response Podcast(int id, bool itunes)
        {
            throw new NotImplementedException();
        }

        public Response Podcast(string url)
        {
            throw new NotImplementedException();
        }

        public Response RandomEpisodes(string lang, string category, string excludeCategory, bool fulltext, int max = 1)
        {
            throw new NotImplementedException();
        }

        public Response RecentEpisodes(string exclude, int beforeId, bool fulltext, int max = 10)
        {
            throw new NotImplementedException();
        }

        public Response RecentFeeds(DateTime since, string lang, string category, string excludeCategory, int max = 40)
        {
            throw new NotImplementedException();
        }

        public Response RecentSoundbites(int max = 60)
        {
            throw new NotImplementedException();
        }

        public Response Search(string term, SearchByTermValues val, bool clean, bool fulltext)
        {
            throw new NotImplementedException();
        }

        public Response Search(string person, bool fulltext)
        {
            throw new NotImplementedException();
        }

        public Response Stats()
        {
            throw new NotImplementedException();
        }

        public Response TrendingPodcasts(int max, DateTime since, string lang, string category, string excludeCategory)
        {
            throw new NotImplementedException();
        }

        public Response Value(int id)
        {
            throw new NotImplementedException();
        }

        public Response Value(string url)
        {
            throw new NotImplementedException();
        }
    }
}
