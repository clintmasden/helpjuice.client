using System.Text.Json.Serialization;

namespace HelpJuice.Client.Queries.Models
{
    public class Search
    {
        [JsonPropertyName("id")] public int Id { get; set; }
        [JsonPropertyName("name")] public string Name { get; set; }
        [JsonPropertyName("slug")] public string Slug { get; set; }
        [JsonPropertyName("tag_names")] public object[] TagNames { get; set; }
        [JsonPropertyName("answer_sample")] public string AnswerSample { get; set; }

        [JsonPropertyName("long_answer_sample")]
        public string LongAnswerSample { get; set; }

        [JsonPropertyName("last_published_user_name")]
        public string LastPublishedUserName { get; set; }

        [JsonPropertyName("is_published")] public bool IsPublished { get; set; }

        [JsonPropertyName("last_published_date")]
        public string LastPublishedDate { get; set; }

        [JsonPropertyName("is_internal")] public bool IsInternal { get; set; }
        [JsonPropertyName("categories")] public SearchCategory Categories { get; set; }
        [JsonPropertyName("url")] public string Url { get; set; }

        public override string ToString()
        {
            return $"{Id}: {Slug}, {Name}";
        }

        public class SearchCategory
        {
            public SearchCategoryCurrent Current { get; set; }

            public class SearchCategoryCurrent
            {
                [JsonPropertyName("id")] public int Id { get; set; }
                [JsonPropertyName("name")] public string Name { get; set; }
                [JsonPropertyName("url")] public string Url { get; set; }
            }
        }
    }
}