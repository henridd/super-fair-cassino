using System.Text.Json.Serialization;

namespace SuperFairCassinoAPI
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Game
    {
        Roulette,
        Blackjack,
        Poker
    }
}
