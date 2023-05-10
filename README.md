# PodcastIndexSharp

.NET Standard client library for interacting with the PodcastIndex.org API.

Supports reading from and writing to the Index.

## Getting Started

Install this library from nuget:

```
dotnet add package PodcastIndexSharp
```

In your `Startup.cs`, configure the library in your `ConfigureServices()` method:

```c#
services.AddPodcastIndexSharp(Configuration)
```

Update your `appsettings.json` and add the following object:

```json
    "PodcastIndex": {
        "UserAgent": "YourProgramName/0.1.0",
        "AuthKey": "Your Key",
        "Secret": "And Secret"
    }
```

Now just include the `IPodcastIndex` in your constructors and make calls.

## Examples

In these examples `podcastIndex` is an instance of `IPodcastIndex` set by Dependency Injection.
To get the top 10 trending podcasts:

```c#
var trendingPodcasts = podcastIndex.Podcasts().Trending(10);
```

Or for a specific Podcast by its feed ID:

```c#
var batmanUniversityPodcast = podcastIndex.Podcasts().ByFeedId(75075);
Console.WriteLine(batmanUniversityPodcast.Author) // Tony Sindelar
```

For a further list of examples, see the `PodcastIndexSharp.Example` project.
