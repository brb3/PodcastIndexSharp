namespace PodcastIndexSharp.Test.Clients;

using System.Threading.Tasks;
using PodcastIndexSharp.Clients;
using PodcastIndexSharp.Exceptions;
using Xunit;

public class CategoriesClientTest : ClientTest
{
    private CategoriesClient categoriesClient;

    public CategoriesClientTest()
    {
        categoriesClient = new CategoriesClient(podcastIndexConfig);
    }

    [Fact]
    public async Task TestCategoriesList()
    {
        // Successful call
        httpTest.RespondWithJson(new { Status = true }, 200);
        await categoriesClient.List();
        httpTest.ShouldHaveCalled(podcastIndexConfig.BaseUrl + "categories/list");

        // Network level failure
        httpTest.RespondWithJson(new { }, 500);
        await Assert.ThrowsAsync<NetworkException>(async () => await categoriesClient.List());

        // API Responds but with "false" status.
        httpTest.RespondWithJson(new { Status = false }, 200);
        await Assert.ThrowsAsync<ResponseException>(async () => await categoriesClient.List());
    }
}