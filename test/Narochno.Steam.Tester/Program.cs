using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Narochno.Steam.Entities;
using Narochno.Steam.Entities.Requests;

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
            var client = new ServiceCollection()
                .AddSteam(new SteamConfig())
                .BuildServiceProvider()
                .GetService<ISteamClient>();

            var reviews = await client.GetReviews(new GetReviewsRequest(582890) { Filter = ReviewFilter.Recent });

            var news = await client.GetNews(new GetNewsRequest(582890));
            Console.WriteLine("News for app {0}", news.AppNews.AppId);
            foreach (var item in news.AppNews.NewsItems)
            {
                Console.WriteLine("{0} by {1}", item.Title, item.Author);
            }

            Console.ReadKey();

            var apps = await client.GetApps();
            foreach (var app in apps.AppList.Apps)
            {
                Console.WriteLine(app.AppId + ": " + app.Name);
            }

            Console.ReadKey();
        }
    }
}
