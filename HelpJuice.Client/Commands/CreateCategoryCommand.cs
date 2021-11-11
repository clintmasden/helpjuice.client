using System.Text.Json.Serialization;
using HelpJuice.Client.Commands.Models;

namespace HelpJuice.Client.Commands
{
    public class CreateCategoryCommand
    {
        [JsonPropertyName("category")] public Category Category { get; set; }
    }
}