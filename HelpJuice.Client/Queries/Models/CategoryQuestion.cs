using System.Text.Json.Serialization;

namespace HelpJuice.Client.Queries.Models
{
    public class CategoryQuestion
    {
        /// <summary>
        ///     The Id of the category question.
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        ///     Name of the category question.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        ///     The number of views.
        /// </summary>
        [JsonPropertyName("views")]
        public int? Views { get; set; }


        /// <summary>
        ///     The URL of the category question.
        /// </summary>
        [JsonPropertyName("url")]
        public string Url { get; set; }

        public override string ToString()
        {
            return $"{Id}: {Name}";
        }
    }
}