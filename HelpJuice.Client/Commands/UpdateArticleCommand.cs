using System.Text.Json.Serialization;
using HelpJuice.Client.Commands.Models;

namespace HelpJuice.Client.Commands
{
    public class UpdateArticleCommand
    {
        [JsonPropertyName("article")] public Article Article { get; set; }
    }
}