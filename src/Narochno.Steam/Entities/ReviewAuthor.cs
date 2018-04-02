using Newtonsoft.Json;
using System;

namespace Narochno.Steam.Entities
{
    public class ReviewAuthor
    {
        [JsonProperty("steamid")]
        public string SteamId { get; set; }
        [JsonProperty("num_games_owned")]
        public uint NumGamesOwned { get; set; }
        [JsonProperty("num_reviews")]
        public uint NumReviews { get; set; }
        [JsonProperty("playtime_forever")]
        internal uint PlaytimeForeverInternal { get; set; }
        public TimeSpan PlayTimeForever => TimeSpan.FromMinutes(PlaytimeForeverInternal);
        [JsonProperty("playtime_last_two_weeks")]
        internal uint PlaytimeLastTwoWeeksInternal { get; set; }
        public TimeSpan PlaytimeLastTwoWeeks => TimeSpan.FromMinutes(PlaytimeLastTwoWeeksInternal);
        [JsonProperty("last_played")]
        internal uint LastPlayedInternal { get; set; }
        public DateTimeOffset LastPlayed => DateTimeOffset.FromUnixTimeSeconds(LastPlayedInternal);
    }
}
