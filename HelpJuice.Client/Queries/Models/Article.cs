using System;
using System.Text.Json.Serialization;

namespace HelpJuice.Client.Queries.Models
{
    public class Article
    {
        /// <summary>
        ///     The Id of the article.
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        ///     The number of views.
        /// </summary>
        [JsonPropertyName("views")]
        public int? Views { get; set; }

        /// <summary>
        ///     (public: 1, internal: 0, private: 2) limited access to the article.
        /// </summary>
        [JsonPropertyName("accessibility")]
        public int Accessibility { get; set; }

        /// <summary>
        ///     Description of the article.
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        ///     slug or URL for the article.
        /// </summary>
        [JsonPropertyName("codename")]
        public string Codename { get; set; }

        [JsonPropertyName("created_at")] public DateTime CreatedAt { get; set; }
        [JsonPropertyName("updated_at")] public DateTime UpdatedAt { get; set; }

        [JsonPropertyName("next_expiration_on")]
        public object NextExpirationOn { get; set; }

        /// <summary>
        ///     Whether the article is published or not.
        /// </summary>
        [JsonPropertyName("published")]
        public bool IsPublished { get; set; }

        /// <summary>
        ///     Article contents.
        /// </summary>
        [JsonPropertyName("answer")]
        public ArticleAnswer Answer { get; set; }

        /// <summary>
        ///     Article contributors.
        /// </summary>
        [JsonPropertyName("author")]
        public ArticleAuthor Author { get; set; }

        /// <summary>
        ///     Categories that the article will appear in.
        /// </summary>
        [JsonPropertyName("category")]
        public Category Category { get; set; }

        [JsonPropertyName("keywords")] public object[] Keywords { get; set; }

        /// <summary>
        ///     The URL of the article.
        /// </summary>
        [JsonPropertyName("url")]
        public string Url { get; set; }

        public override string ToString()
        {
            return $"{Id}: {Description}";
        }
    }
}