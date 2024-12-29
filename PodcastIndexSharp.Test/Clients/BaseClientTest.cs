namespace PodcastIndexSharp.Test.Clients;
using System;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using PodcastIndexSharp.Clients;
using PodcastIndexSharp.Exceptions;
using PodcastIndexSharp.Response;
using Xunit;

internal class ExposedBaseClient(PodcastIndexConfig config) : BaseClient(config)
{
    public new IFlurlRequest GetAuthorizedRequest(string path)
    {
        return base.GetAuthorizedRequest(path);
    }

    public new string ToUnixTimeStamp(DateTime? dateTime)
    {
        return base.ToUnixTimeStamp(dateTime);
    }

    public new async Task<T> GetResponse<T>(IFlurlRequest request) where T : AbstractResponse
    {
        return await base.GetResponse<T>(request);
    }
}

internal class TestResponse : AbstractResponse
{
}

public class BaseClientTest : ClientTest
{
    private readonly ExposedBaseClient baseClient;

    public BaseClientTest()
    {
        baseClient = new ExposedBaseClient(podcastIndexConfig);
    }

    [Fact]
    public void TestGetAuthorizedRequest()
    {
        var path = "testPath";

        // Should return a FlurlRequest
        var request = baseClient.GetAuthorizedRequest(path);
        Assert.IsType<FlurlRequest>(request);

        // With a URL set
        Assert.IsType<Url>(request.Url);
        Assert.Equal($"https://example.com/{path}", request.Url.ToString());

        // With headers in place
        Assert.Equal(4, request.Headers.Count);
        Assert.True(request.Headers.Contains("User-Agent", podcastIndexConfig.UserAgent));
        Assert.True(request.Headers.Contains("X-Auth-Key", podcastIndexConfig.AuthKey));
    }

    [Fact]
    public void TestToUnixTimeStamp()
    {
        // Should return an empty string when a null DateTime is passed
        Assert.Equal(string.Empty, baseClient.ToUnixTimeStamp(null));

        // Should return a string that looks like a Unix Timestamp
        var timestamp = baseClient.ToUnixTimeStamp(DateTime.Now);
        Assert.IsType<string>(timestamp);
        Assert.Equal(10, timestamp.Length);

        // And it should be parseable as an int
        int timestampInt;
        var itParses = int.TryParse(timestamp, out timestampInt);
        Assert.IsType<int>(timestampInt);
        Assert.True(itParses);
    }

    [Fact]
    public async Task TestGetResponse()
    {
        var baseUrl = "https://example.com/";
        var fragment = "test/endpoint";
        var request = baseClient.GetAuthorizedRequest(fragment);

        // Should succeed and give back the same type.
        httpTest.RespondWithJson(new { Status = true });
        var successResponse = await baseClient.GetResponse<TestResponse>(request);
        Assert.IsType<TestResponse>(successResponse);
        httpTest.ShouldHaveCalled(baseUrl + fragment);


        // Should throw with ResponseException
        httpTest.RespondWithJson(new { Status = false }, 200);
        await Assert.ThrowsAsync<ResponseException>(async () => await baseClient.GetResponse<TestResponse>(request));

        // Should throw with NetworkException
        httpTest.RespondWithJson(new { }, 500);
        await Assert.ThrowsAsync<NetworkException>(async () => await baseClient.GetResponse<TestResponse>(request));
    }
}