using System.Text.Json.Serialization;
using HelpJuice.Client.Commands.Models;

namespace HelpJuice.Client.Commands
{
    public class UpdateGroupCommand
    {
        [JsonPropertyName("group")] public Group Group { get; set; }
    }
}