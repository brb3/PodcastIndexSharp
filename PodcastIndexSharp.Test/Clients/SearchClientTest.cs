namespace PodcastIndexSharp.Test.Clients;

using System.Threading.Tasks;
using PodcastIndexSharp.Clients;
using PodcastIndexSharp.Exceptions;
using Xunit;

public class SearchClientTest : ClientTest
{
    private readonly SearchClient searchClient;

    public SearchClientTest()
    {
        searchClient = new SearchClient(podcastIndexConfig);
    }

    /// <summary>
    /// Testing that the podcast search builds proper query strings
    /// </summary>
    [Theory]
    [InlineData("testQuery", null, false, false, "q=testQuery")]
    [InlineData("testQuery", Enums.SearchByTermValues.any, false, false, "q=testQuery&val=any")]
    [InlineData("testQuery", null, true, false, "q=testQuery&clean=")]
    [InlineData("testQuery", null, false, true, "q=testQuery&fulltext=")]
    [InlineData("testQuery", Enums.SearchByTermValues.hive, true, true, "q=testQuery&clean=&fulltext=&val=hive")]
    public async Task TestPodcastsSearch(string query, Enums.SearchByTermValues? value, bool clean, bool fulltext, string param)
    {
        var baseUrl = "https://example.com/search/byterm?";
        httpTest.RespondWithJson(new { Status = true });

        await searchClient.Podcasts(query, value, clean, fulltext);
        httpTest.ShouldHaveCalled(baseUrl + param);
    }

    /// <summary>
    /// Testing that the podcast episode search builds proper query strings
    /// </summary>
    [Theory]
    [InlineData("Frank", false, "q=Frank")]
    [InlineData("Frank", true, "q=Frank&fulltext=")]
    public async Task TestPodcastEpisodeByPerson(string person, bool fulltext, string param)
    {
        var baseUrl = "https://example.com/search/byperson?";
        httpTest.RespondWithJson(new { Status = true });

        await searchClient.EpisodesByPerson(person, fulltext);
        httpTest.ShouldHaveCalled(baseUrl + param);
    }

    /// <summary>
    /// Testing that a failure status is reported, and network failure is thrown.
    /// </summary>
    [Fact]
    public async Task TestPodcastsSearchFail()
    {
        // API Responds with failure
        httpTest.RespondWithJson(new { }, 500);
        await Assert.ThrowsAsync<NetworkException>(async () => await searchClient.Podcasts("test"));

        // API Responds but with "false" status.
        httpTest.RespondWithJson(new { Status = false }, 200);
        await Assert.ThrowsAsync<ResponseException>(async () => await searchClient.Podcasts("test"));
    }
}