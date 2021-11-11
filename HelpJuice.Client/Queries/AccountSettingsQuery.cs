using System.Text.Json.Serialization;
using HelpJuice.Client.Queries.Models;

namespace HelpJuice.Client.Queries
{
    public class AccountSettingsQuery
    {
        [JsonPropertyName("account")] public AccountSettings AccountSettings { get; set; }
    }
}