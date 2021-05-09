namespace Example
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using PodcastIndexSharp;

    class Program
    {
        static void Main(string[] args)
        {
            // Getting configuration from appsettings.json.
            // PodcastIndexSharp will read from the "PodcastIndex" object
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile("appsettings.local.json", false, true)
                .Build();

            using var host = CreateHostBuilder(args, config).Build();
            using var serviceScope = host.Services.CreateScope();
            var provider = serviceScope.ServiceProvider;

            // Get our client. Normally you would do this with Dependency Injection in your constructor.
            var client = provider.GetService(typeof(IPodcastIndexClient)) as IPodcastIndexClient;

            RunExamples(client).GetAwaiter().GetResult();
        }

        static IHostBuilder CreateHostBuilder(string[] args, IConfiguration config) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((_, services) =>
                    // Calling the AddPodcastIndexSharp extension method and passing in our application's configuration
                    services.AddPodcastIndexSharp(config)
                );

        static async Task RunExamples(IPodcastIndexClient client)
        {
            // Search for a podcast by term
            var searchTerm = "Production Ready";
            var searchResponse = await client.Search(searchTerm);
            Console.WriteLine($"Found {searchResponse.Count} podcasts when searching for \"{searchTerm}\"");

            // Serach for a podcast episode by person
            var person = "Adam Curry";
            var episodeSearchResponse = await client.SearchByPerson(person);
            Console.WriteLine($"Found {episodeSearchResponse.Count} episodes when searching by person \"{person}\"");

            // Look up a podcast by iTunes ID and print some information about it.
            var podcast = await client.Podcast(1441923632, true);
            Console.WriteLine($"Podcast \"{podcast.Feed.Title}\" was last updated {podcast.Feed.LastUpdateTime}");

            // Look up a podcast by it's PodcastIndex feed ID.
            podcast = await client.Podcast(75075, false);
            Console.WriteLine($"Podcast \"{podcast.Feed.Title}\" is created by {podcast.Feed.Author}");

            // Look up a podcast by it's URL
            var url = new System.Uri("http://feeds.feedburner.com/TheAdamCarollaPodcast");
            podcast = await client.Podcast(url);
            Console.WriteLine($"Podcast id {podcast.Feed.Id} found when searching with URL {url}");

            // Find trending podcasts
            var trendingPodcasts = await client.TrendingPodcasts(1);
            Console.WriteLine($"The top trending podcast is {trendingPodcasts.Feeds[0].Title}");

            // Find dead podcasts
            var deadPodcasts = await client.DeadPodcasts();
            Console.WriteLine($"Found a total of {deadPodcasts.Count} dead podcasts.");

            // Find Episodes by ID
            var episodeId = 16795089;
            var episodeSearch = await client.Episode(episodeId);
            Console.WriteLine($"Episode ID {episodeId} is number \"{episodeSearch.Episode.EpisodeNumber}\" in Podcast title \"{episodeSearch.Episode.FeedTitle}\"");

            // Get a Random Episode
            var randomEpisodes = await client.RandomEpisodes("", "", "", false, 1);
            Console.WriteLine($"Random Episode in Feed \"{randomEpisodes.Episodes[0].FeedTitle}\" found.");

            // Get some recent episodes
            var recentEpisodes = await client.RecentEpisodes("", false, 1);
            Console.WriteLine($"The most recent episode is in Feed \"{recentEpisodes.Episodes[0].FeedTitle}\"");

            // Recent Feeds
            var recentFeeds = await client.RecentFeeds();
            Console.WriteLine($"The most recent feed is \"{recentFeeds.Feeds[0].Title}\"");

            // New feeds
            var newFeeds = await client.NewFeeds();
            Console.WriteLine($"The newest feed has ID \"{newFeeds.Feeds[0].Id}\"");

            // Getting recent Soundbites
            var recentSoundbites = await client.RecentSoundbites(1);
            var mostRecentSoundbite = recentSoundbites.Soundbites[0];
            Console.WriteLine($"The most recent soundbite is from Feed \"{mostRecentSoundbite.FeedTitle}\" and has a duration of {mostRecentSoundbite.Duration} seconds");

            // Value information
            var feedIdForValue = 41504;
            var valueResponse = await client.Value(feedIdForValue);
            Console.WriteLine($"Feed with ID {feedIdForValue} uses value method {valueResponse.Value.Model.Method}");

            // Get stats about the PodcastIndex
            var stats = await client.Stats();
            Console.WriteLine($"Total feed count: {stats.Stats.FeedCountTotal}");
        }
    }
}
