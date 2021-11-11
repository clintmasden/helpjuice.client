using System.Text.Json.Serialization;
using HelpJuice.Client.Commands.Models;

namespace HelpJuice.Client.Commands
{
    public class CreateUserCommand
    {
        [JsonPropertyName("user")] public User User { get; set; }
    }
}