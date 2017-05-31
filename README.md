# Narochno.Steam [![Build status](https://ci.appveyor.com/api/projects/status/c8f7v86cvwija07w/branch/master?svg=true)](https://ci.appveyor.com/project/Narochno/narochno-steam/branch/master)
A simple Steam client, providing a C# wrapper around the default Steam web API.

## Example Usage
```csharp
using (var steamClient = new SteamClient())
{
	var news = await steamClient.GetNewsForApp(new GetNewsForAppRequest(582890));
}
```
