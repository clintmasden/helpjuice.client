using System.Text.Json.Serialization;
using HelpJuice.Client.Commands.Models;

namespace HelpJuice.Client.Commands
{
    public class UpdateAccountSettingsCommand
    {
        [JsonPropertyName("settings")] public AccountSettings AccountSettings { get; set; }
    }
}