using Narochno.Primitives;

namespace Narochno.Steam
{
    public class SteamConfig
    {
        /// <summary>
        /// The Steam API URL
        /// </summary>
        public string SteamUrl { get; set; } = "https://api.steampowered.com";

        /// <summary>
        /// The API key for the supplied user
        /// </summary>
        public Optional<string> ApiKey { get; set; }

        /// <summary>
        /// The number of times requests will be retried 
        /// </summary>
        public int RetryAttempts { get; set; } = 2;

        /// <summary>
        /// The number of retries will be an exponent of this number
        /// </summary>
        public int RetryBackoffExponent { get; set; } = 2;
    }
}
