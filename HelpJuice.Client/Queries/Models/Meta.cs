using System.Text.Json.Serialization;

namespace HelpJuice.Client.Queries.Models
{
    /// <summary>
    ///     Collection usage information.
    /// </summary>
    public class Meta
    {
        /// <summary>
        ///     Current page
        /// </summary>
        [JsonPropertyName("current")]
        public int Current { get; set; }

        /// <summary>
        ///     Collection page limit.
        /// </summary>
        [JsonPropertyName("limit")]
        public int Limit { get; set; }

        /// <summary>
        ///     Total pages.
        /// </summary>
        [JsonPropertyName("total_pages")]
        public int TotalPages { get; set; }

        /// <summary>
        ///     Collection count.
        /// </summary>
        [JsonPropertyName("total_count")]
        public int TotalCount { get; set; }
    }
}