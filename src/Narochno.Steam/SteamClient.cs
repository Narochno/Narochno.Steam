using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json.Converters;
using Polly.Retry;
using Polly;
using Narochno.Steam.Entities.Responses;
using Narochno.Steam.Entities.Requests;

namespace Narochno.Steam
{
    internal sealed class SteamClient : ISteamClient
    {
        private readonly SteamConfig config;
        private readonly JsonSerializerSettings serializerSettings = new JsonSerializerSettings
        {
            Converters = new JsonConverter[] { new StringEnumConverter() }
        };

        public SteamClient(SteamConfig config)
        {
            this.config = config;
        }

        public string GetBaseQuery()
        {
            return "?format=json" + (string.IsNullOrWhiteSpace(config.ApiKey) ? string.Empty : "&key=" + config.ApiKey);
        }

        public async Task<GetAppsResponse> GetApps(CancellationToken token)
        {
            HttpResponseMessage response = await GetRetryPolicy().ExecuteAsync(() => config.HttpClient.GetAsync(config.SteamUrl + "/ISteamApps/GetAppList/v0002/", token));

            response.EnsureSuccessStatusCode();

            return JsonConvert.DeserializeObject<GetAppsResponse>(await response.Content.ReadAsStringAsync(), serializerSettings);
        }

        public async Task<GetReviewsResponse> GetReviews(GetReviewsRequest request, CancellationToken token)
        {
            // https://partner.steamgames.com/doc/store/getreviews
            string url = $"http://store.steampowered.com/appreviews/{request.AppId}?json=1" +
                $"&filter={request.Filter.ToString().ToLower()}" +
                $"&language={request.Language}" +
                $"&review_type={request.ReviewType.ToString().ToLower()}" +
                $"&purchase_type={request.PurchaseType.ToString().ToLower()}" +
                (request.DayRange.HasValue ? $"&day_range={request.DayRange.Value}" : string.Empty) +
                (request.StartOffset.HasValue ? $"&start_offset={request.StartOffset.Value}" : string.Empty);

            HttpResponseMessage response = await GetRetryPolicy().ExecuteAsync(() => config.HttpClient.GetAsync(url, token));

            response.EnsureSuccessStatusCode();

            return JsonConvert.DeserializeObject<GetReviewsResponse>(await response.Content.ReadAsStringAsync(), serializerSettings);
        }

        public async Task<GetNewsResponse> GetNews(GetNewsRequest request, CancellationToken token)
        {
            string queryParameters = GetBaseQuery() + "&appid=" + request.AppId;
            if (request.EndDate.HasValue)
            {
                queryParameters += "&enddate=" + request.EndDate.Value.ToUnixTimeSeconds();
            }

            if (request.Count.HasValue)
            {
                queryParameters += "&count=" + request.Count.Value;
            }

            HttpResponseMessage response = await GetRetryPolicy().ExecuteAsync(() => config.HttpClient.GetAsync(config.SteamUrl + "/ISteamNews/GetNewsForApp/v0002/" + queryParameters, token));

            response.EnsureSuccessStatusCode();

            return JsonConvert.DeserializeObject<GetNewsResponse>(await response.Content.ReadAsStringAsync(), serializerSettings);
        }

        public RetryPolicy<HttpResponseMessage> GetRetryPolicy()
        {
            return Policy.HandleResult<HttpResponseMessage>(r => r.StatusCode >= HttpStatusCode.InternalServerError)
                         .WaitAndRetryAsync(config.RetryAttempts, retryAttempt => TimeSpan.FromSeconds(Math.Pow(config.RetryBackoffExponent, retryAttempt)));
        }
    }
}