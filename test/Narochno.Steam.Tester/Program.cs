using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Narochno.Steam.Entities;

namespace Narochno.Steam.Tester
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                DoWork().Wait();
            }
            catch (AggregateException e)
            {
                throw e.Flatten();
            }
        }

        public static async Task DoWork()
        {
            var provider = new ServiceCollection()
                .AddSteam(new SteamConfig())
                .BuildServiceProvider();

            using (var steamClient = provider.GetService<ISteamClient>())
            {
                var news = await steamClient.GetNewsForApp(new GetNewsForAppRequest(582890));
                Console.WriteLine("News for app {0}", news.AppNews.AppId);
                foreach (var item in news.AppNews.NewsItems)
                {
                    Console.WriteLine("{0} by {1}", item.Title, item.Author);
                }

                Console.ReadKey();

                var apps = await steamClient.GetAppList();
                foreach (var app in apps.AppList.Apps)
                {
                    Console.WriteLine(app.AppId + ": " + app.Name);
                }
            }

            Console.ReadKey();
        }
    }
}
