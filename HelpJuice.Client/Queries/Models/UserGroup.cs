using System.Text.Json.Serialization;

namespace HelpJuice.Client.Queries.Models
{
    public class UserGroup
    {
        /// <summary>
        ///     The Id of the group.
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        ///     The name of the group.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        public override string ToString()
        {
            return $"{Id}: {Name}";
        }
    }
}