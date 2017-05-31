# Narochno.Steam [![Build status](https://ci.appveyor.com/api/projects/status/apb06g0lim02trxd/branch/master?svg=true)](https://ci.appveyor.com/project/Narochno/narochno-steam/branch/master)
A simple Steam client, providing a C# wrapper around the default Steam web API.

## Example Usage
```csharp
using (var steamClient = new SteamClient())
{
	var news = await steamClient.GetNewsForApp(new GetNewsForAppRequest(582890));
	Console.WriteLine("News for app {0}", news.AppNews.AppId);
	foreach (var item in news.AppNews.NewsItems)
	{
		Console.WriteLine("{0} by {1}", item.Title, item.Author);
	}
}
```
