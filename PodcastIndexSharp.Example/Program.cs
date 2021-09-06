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
            var podcastIndex = provider.GetService(typeof(IPodcastIndex)) as IPodcastIndex;

            RunExamples(podcastIndex).GetAwaiter().GetResult();
        }

        static IHostBuilder CreateHostBuilder(string[] args, IConfiguration config) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((_, services) =>
                    // Calling the AddPodcastIndexSharp extension method and passing in our application's configuration
                    services.AddPodcastIndexSharp(config)
                );

        static async Task RunExamples(IPodcastIndex podcastIndex)
        {
            // Search for a podcast by term
            var searchTerm = "Production Ready";
            var searchResponse = await podcastIndex.Search().Podcasts(searchTerm);
            Console.WriteLine($"Podcasts by Search Term: Found {searchResponse.Count} podcasts when searching for \"{searchTerm}\"");

            // Serach for a podcast episode by person
            var person = "Adam Curry";
            var episodeSearchResponse = await podcastIndex.Search().EpisodesByPerson(person);
            Console.WriteLine($"Episodes by Person: Found {episodeSearchResponse.Count} episodes when searching by person \"{person}\"");

            // Look up a podcast by iTunes ID and print some information about it.
            var podcast = await podcastIndex.Podcasts().ByiTunesId(1441923632);
            Console.WriteLine($"Podcast by iTunes ID: Podcast \"{podcast.Title}\" was last updated {podcast.LastUpdateTime}");

            // Look up a podcast by it's PodcastIndex feed ID.
            podcast = await podcastIndex.Podcasts().ByFeedId(75075);
            Console.WriteLine($"Podcast by Feed ID: Podcast \"{podcast.Title}\" is created by {podcast.Author}");

            // Find by GUID
            podcast = await podcastIndex.Podcasts().ByGUID(Guid.Parse("9b024349-ccf0-5f69-a609-6b82873eab3c"));
            Console.WriteLine($"Podcast by GUID: Podcast \"{podcast.Title}\" is in language \"{podcast.Language}\"");

            // Look up a podcast by it's URL
            var url = new System.Uri("http://feeds.feedburner.com/TheAdamCarollaPodcast");
            podcast = await podcastIndex.Podcasts().ByFeedUrl(url);
            Console.WriteLine($"Podcast by URL: Podcast id {podcast.Id} found when searching with URL {url}");

            // Find trending podcasts
            var trendingPodcasts = await podcastIndex.Podcasts().Trending(1);
            Console.WriteLine($"Trending Podcasts: The top trending podcast is {trendingPodcasts[0].Title} with a score of {trendingPodcasts[0].TrendScore}");

            // Find dead podcasts
            var deadPodcasts = await podcastIndex.Podcasts().Dead();
            Console.WriteLine($"Dead Podcasts: Found a total of {deadPodcasts.Count} dead podcasts.");

            // Find Episodes by ID
            uint episodeId = 16795089;
            var episode = await podcastIndex.Episodes().ById(episodeId);
            Console.WriteLine($"Episode by ID: Episode ID {episodeId} is number \"{episode.EpisodeNumber}\" in Podcast title \"{episode.FeedTitle}\"");

            // Get a Random Episode
            var randomEpisodes = await podcastIndex.Episodes().Random("", "", "", false, 1);
            Console.WriteLine($"Random Episode: Episode with number \"{randomEpisodes[0].Title}\" in Feed \"{randomEpisodes[0].FeedTitle}\" found.");

            // Get some recent episodes
            var recentEpisodes = await podcastIndex.Recent().Episodes("", false, 1);
            Console.WriteLine($"Recent Episodes: The most recent episode is in Feed \"{recentEpisodes[0].FeedTitle}\"");

            // Recent Feeds
            var recentFeeds = await podcastIndex.Recent().Podcasts();
            Console.WriteLine($"Recent Podcasts: The most recent feed is \"{recentFeeds[0].Title}\"");

            // New feeds
            var newFeeds = await podcastIndex.Recent().NewPodcasts();
            Console.WriteLine($"New Podcasts: The newest feed has ID \"{newFeeds[0].Id}\"");

            // Getting recent Soundbites
            var recentSoundbites = await podcastIndex.Recent().Soundbites(1);
            var mostRecentSoundbite = recentSoundbites[0];
            Console.WriteLine($"Recent Soundbites: The most recent soundbite is from Feed \"{mostRecentSoundbite.FeedTitle}\" and has a duration of {mostRecentSoundbite.Duration} seconds");

            // Value information
            uint feedIdForValue = 41504;
            var valueResponse = await podcastIndex.Value().ByFeedId(feedIdForValue);
            Console.WriteLine($"Value by Feed ID: Feed with ID {feedIdForValue} uses value method {valueResponse.Model.Method}");

            // Get stats about the PodcastIndex
            var stats = await podcastIndex.Stats().Current();
            Console.WriteLine($"Current Stats: Total feed count: {stats.FeedCountTotal}");

            // Get all categories from the index.
            var categories = await podcastIndex.Categories().List();
            Console.WriteLine($"Categories List: Found {categories.Count} categories.");
        }
    }
}