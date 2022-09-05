using System;
using Flurl.Http;
using PodcastIndexSharp.Clients;
using Xunit;

namespace PodcastIndexSharp.Test.Clients;

internal class ExposedBaseClient : BaseClient
{
    public ExposedBaseClient(PodcastIndexConfig config) : base(config)
    {
    }

    public new IFlurlRequest GetAuthorizedRequest(string path)
    {
        return base.GetAuthorizedRequest(path);
    }

    public new string ToUnixTimeStamp(DateTime? dateTime)
    {
        return base.ToUnixTimeStamp(dateTime);
    }
}

public class BaseClientTest
{
    private PodcastIndexConfig podcastIndexConfig;
    private ExposedBaseClient baseClient;

    public BaseClientTest()
    {
        podcastIndexConfig = new PodcastIndexConfig()
        {
            BaseUrl = "https://example.com/",
            UserAgent = "Test",
            AuthKey = "1234567890",
            Secret = "abcdefg"
        };

        baseClient = new ExposedBaseClient(podcastIndexConfig);
    }

    [Fact]
    public void ToUnixTimeStampTests()
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
}