using System.Text.Json.Serialization;
using HelpJuice.Client.Commands.Models;

namespace HelpJuice.Client.Commands
{
    public class UpdateCategoryCommand
    {
        [JsonPropertyName("category")] public Category Category { get; set; }
    }
}