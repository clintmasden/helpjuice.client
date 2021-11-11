using System.Text.Json.Serialization;

namespace HelpJuice.Client.Commands.Models
{
    public class Category
    {
        /// <summary>
        ///     The Id of the parent category.
        /// </summary>
        [JsonPropertyName("parent_id")]
        public int ParentId { get; set; }

        /// <summary>
        ///     (public: 1, internal: 0, private: 2) limited the access to articles inside.
        /// </summary>
        [JsonPropertyName("accessibility")]
        public int Accessibility { get; set; }

        /// <summary>
        ///     Description of the category.
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        ///     Name of the category.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        ///     The slug for the category.
        /// </summary>
        [JsonPropertyName("codename")]
        public string Codename { get; set; }

        /// <summary>
        ///     Whether the category is archived or not.
        /// </summary>
        [JsonPropertyName("archived")]
        public bool IsArchived { get; set; }

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
    }
}