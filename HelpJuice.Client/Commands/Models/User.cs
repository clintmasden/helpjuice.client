using System.Text.Json.Serialization;

namespace HelpJuice.Client.Commands.Models
{
    public class User
    {
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
        ///     Unique email of the user.
        /// </summary>
        [JsonPropertyName("email")]
        public string Email { get; set; }

        /// <summary>
        ///     Role of the user(superadmin, admin, collaborator, draft_writer, viewer).
        /// </summary>
        [JsonPropertyName("role_id")]
        public string RoleId { get; set; }

        /// <summary>
        ///     Ids of the groups where the user should be joined.
        /// </summary>
        [JsonPropertyName("group_ids")]
        public int[] GroupIds { get; set; }
    }
}