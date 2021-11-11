using System.Text.Json.Serialization;
using HelpJuice.Client.Commands.Models;

namespace HelpJuice.Client.Commands
{
    public class CreateArticleCommand
    {
        [JsonPropertyName("article")] public Article Article { get; set; }
    }
}