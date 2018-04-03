using Newtonsoft.Json;
using System;

namespace Narochno.Steam.Entities
{
    public class ReviewAuthor
    {
        [JsonProperty("steamid")]
        public ulong SteamId { get; set; }
        [JsonProperty("num_games_owned")]
        public uint NumGamesOwned { get; set; }
        [JsonProperty("num_reviews")]
        public uint NumReviews { get; set; }
        [JsonProperty("playtime_forever")]
        internal uint PlaytimeForeverInternal { get; set; }
        public TimeSpan PlayTimeForever => TimeSpan.FromMinutes(PlaytimeForeverInternal);
        [JsonProperty("playtime_last_two_weeks")]
        internal uint PlayTimeLastTwoWeeksInternal { get; set; }
        public TimeSpan PlayTimeLastTwoWeeks => TimeSpan.FromMinutes(PlayTimeLastTwoWeeksInternal);
        [JsonProperty("last_played")]
        internal uint LastPlayedInternal { get; set; }
        public DateTimeOffset LastPlayed => DateTimeOffset.FromUnixTimeSeconds(LastPlayedInternal);
    }
}
