namespace PodcastIndexSharp.Test.Clients;

using Flurl.Http.Testing;

public class ClientTest
{
    protected PodcastIndexConfig podcastIndexConfig = new()
    {
        BaseUrl = "https://example.com/",
        UserAgent = "Test",
        AuthKey = "1234567890",
        Secret = "abcdefg"
    };

    protected HttpTest httpTest = new();
}