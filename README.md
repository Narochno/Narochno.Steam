# Narochno.Steam [![Build status](https://ci.appveyor.com/api/projects/status/apb06g0lim02trxd/branch/master?svg=true)](https://ci.appveyor.com/project/Narochno/narochno-steam/branch/master) [![NuGet](https://img.shields.io/nuget/v/Narochno.Steam.svg)](https://www.nuget.org/packages/Narochno.Steam/)
A simple Steam client, providing a C# wrapper around the default Steam web API.

## Example Usage
```csharp
var client = new ServiceCollection()
	.AddSteam(new SteamConfig())
	.BuildServiceProvider()
	.GetService<ISteamClient>();

var response = await client.GetReviews(new GetReviewsRequest(582890));

var news = await client.GetNews(new GetNewsRequest(582890));
Console.WriteLine("News for app {0}", news.AppNews.AppId);

foreach (var item in news.AppNews.NewsItems)
{
	Console.WriteLine("{0} by {1}", item.Title, item.Author);
}
```
