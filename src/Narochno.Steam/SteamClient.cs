using Narochno.Primitives.Json;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json.Converters;
using Polly.Retry;
using Polly;
using Narochno.Steam.Entities;

namespace Narochno.Steam
{
    public class SteamClient : ISteamClient
    {
        private readonly HttpClient httpClient = new HttpClient();
        private readonly SteamConfig steamConfig;
        private readonly JsonSerializerSettings serializerSettings = new JsonSerializerSettings
        {
            Converters = new JsonConverter[] { new OptionalJsonConverter(), new StringEnumConverter() }
        };

        public SteamClient()
        {
            steamConfig = new SteamConfig();
        }

        public SteamClient(SteamConfig steamConfig)
        {
            if (steamConfig == null)
            {
                throw new ArgumentNullException(nameof(steamConfig));
            }

            this.steamConfig = steamConfig;
        }

        public string GetBaseQuery()
        {
            return "?format=json" + (steamConfig.ApiKey.HasValue ? "&key=" + steamConfig.ApiKey.Value : string.Empty);
        }

        public async Task<GetAppListResponse> GetAppList(CancellationToken ctx)
        {
            HttpResponseMessage response = await GetRetryPolicy().ExecuteAsync(() => httpClient.GetAsync(steamConfig.SteamUrl + "/ISteamApps/GetAppList/v0002/"));

            response.EnsureSuccessStatusCode();

            return JsonConvert.DeserializeObject<GetAppListResponse>(await response.Content.ReadAsStringAsync(), serializerSettings);
        }

        public async Task<GetNewsForAppResponse> GetNewsForApp(GetNewsForAppRequest request, CancellationToken ctx)
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

            HttpResponseMessage response = await GetRetryPolicy().ExecuteAsync(() => httpClient.GetAsync(steamConfig.SteamUrl + "/ISteamNews/GetNewsForApp/v0002/" + queryParameters));

            response.EnsureSuccessStatusCode();

            return JsonConvert.DeserializeObject<GetNewsForAppResponse>(await response.Content.ReadAsStringAsync(), serializerSettings);
        }

        public RetryPolicy<HttpResponseMessage> GetRetryPolicy()
        {
            return Policy.HandleResult<HttpResponseMessage>(r => r.StatusCode >= HttpStatusCode.InternalServerError)
                         .WaitAndRetryAsync(steamConfig.RetryAttempts, retryAttempt => TimeSpan.FromSeconds(Math.Pow(steamConfig.RetryBackoffExponent, retryAttempt)));
        }

        public void Dispose() => httpClient.Dispose();
    }
}