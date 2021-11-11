using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace HelpJuice.Client.Queries.Models
{
    public class Category
    {
        /// <summary>
        ///     The Id of the category.
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

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
        ///     Published articles / questions.
        /// </summary>
        [JsonPropertyName("published_questions")]
        public List<CategoryQuestion> PublishedQuestions { get; set; }

        /// <summary>
        ///     List of subcategories.
        /// </summary>
        [JsonPropertyName("sub_categories")]
        public List<Category> SubCategories { get; set; }

        /// <summary>
        ///     Draft articles / questions.
        /// </summary>
        [JsonPropertyName("draft_questions")]
        public List<CategoryQuestion> DraftQuestions { get; set; }

        /// <summary>
        ///     The URL of the category.
        /// </summary>
        [JsonPropertyName("url")]
        public string Url { get; set; }

        /// <summary>
        ///     The parent category.
        /// </summary>
        [JsonPropertyName("parent")]
        public Category Parent { get; set; }

        public override string ToString()
        {
            return $"{Id}: {Name}, {Description}";
        }
    }
}