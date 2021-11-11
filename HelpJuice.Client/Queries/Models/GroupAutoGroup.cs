using System.Text.Json.Serialization;

namespace HelpJuice.Client.Queries.Models
{
    public class GroupAutoGroup
    {
        [JsonPropertyName("expression")] public string Expression { get; set; }
    }
}