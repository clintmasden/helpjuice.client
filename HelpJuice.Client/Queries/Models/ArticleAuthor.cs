using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace HelpJuice.Client.Queries.Models
{
    public class ArticleAuthor
    {
        /// <summary>
        ///     The Id of the user.
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        ///     Unique email of the user.
        /// </summary>
        [JsonPropertyName("email")]
        public string Email { get; set; }

        /// <summary>
        ///     Full name of the user.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        ///     First name of the user.
        /// </summary>
        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }

        /// <summary>
        ///     Last name of the user.
        /// </summary>
        [JsonPropertyName("last_name")]
        public string LastName { get; set; }

        /// <summary>
        ///     Role of the user(superadmin, admin, collaborator, draft_writer, viewer).
        /// </summary>
        [JsonPropertyName("role_id")]
        public string RoleId { get; set; }

        [JsonPropertyName("created_at")] public DateTime CreatedAt { get; set; }
        [JsonPropertyName("updated_at")] public DateTime UpdatedAt { get; set; }

        /// <summary>
        ///     The groups where the user should be joined.
        /// </summary>
        [JsonPropertyName("groups")]
        public List<Group> Groups { get; set; }

        public override string ToString()
        {
            return $"{Id}: {Name}";
        }
    }
}