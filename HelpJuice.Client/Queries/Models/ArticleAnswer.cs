using System;
using System.Text.Json.Serialization;

namespace HelpJuice.Client.Queries.Models
{
    public class ArticleAnswer
    {
        /// <summary>
        ///     Body of the article.
        /// </summary>
        [JsonPropertyName("body")]
        public string Body { get; set; }

        /// <summary>
        ///     Plain text of the article.
        /// </summary>
        [JsonPropertyName("body_txt")]
        public string BodyTxt { get; set; }

        /// <summary>
        ///     Format of the body
        /// </summary>
        [JsonPropertyName("format")]
        public string Format { get; set; }

        [JsonPropertyName("updated_at")] public DateTime UpdatedAt { get; set; }

        public override string ToString()
        {
            return $"{Format}: {BodyTxt}";
        }
    }
}