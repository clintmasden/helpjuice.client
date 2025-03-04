using System.Text.Json.Serialization;

namespace HelpJuice.Client.Commands.Models
{
    public class Article
    {
        /// <summary>
        ///     Name of the article.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

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

        /// <summary>
        ///     (public: 1, internal: 0, private: 2) limited access to the article.
        /// </summary>
        [JsonPropertyName("visibility_id")]
        public int VisibilityId { get; set; }

        /// <summary>
        ///     Body of the article.
        /// </summary>
        [JsonPropertyName("body")]
        public string Body { get; set; }

        /// <summary>
        ///     Whether the article is published or not.
        /// </summary>
        [JsonPropertyName("published")]
        public bool IsPublished { get; set; }

        /// <summary>
        ///     Categories that the article will appear in.
        /// </summary>
        [JsonPropertyName("category_ids")]
        public int[] CategoryIds { get; set; }

        /// <summary>
        ///     If accessibility is set to private, these users will have access to it.
        /// </summary>
        [JsonPropertyName("user_ids")]
        public int[] UserIds { get; set; }

        /// <summary>
        ///     If accessibility is set to private, these group members will have access to it.
        /// </summary>
        [JsonPropertyName("group_ids")]
        public int[] GroupIds { get; set; }

        /// <summary>
        ///     Article contributors.
        /// </summary>
        [JsonPropertyName("contributor_user_ids")]
        public int[] ContributorUserIds { get; set; }


        /// <summary>
        /// Created By User Id
        /// </summary>
        [JsonPropertyName("created_by_id")]
        public int CreatedByUserId { get; set; }
    }
}