# PodcastIndexSharp

.NET Standard client library for interacting with the PodcastIndex.org API.

Currently just supports reading from the API.

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

Now just include the `IPodcastIndexClient` in your constructors and make calls.

For a list of examples, see the `PodcastIndexSharp.Example` project.
