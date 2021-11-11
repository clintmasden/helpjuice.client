using System.Text.Json.Serialization;
using HelpJuice.Client.Commands.Models;

namespace HelpJuice.Client.Commands
{
    public class UpdateUserCommand
    {
        [JsonPropertyName("user")] public User User { get; set; }
    }
}