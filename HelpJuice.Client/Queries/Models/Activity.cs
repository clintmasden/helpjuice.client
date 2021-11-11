using System;
using System.Text.Json.Serialization;

namespace HelpJuice.Client.Queries.Models
{
    public class Activity
    {
        /// <summary>
        ///     The Id of the activity.
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        ///     The trackable Id.
        /// </summary>
        [JsonPropertyName("trackable_id")]
        public int? TrackableId { get; set; }

        /// <summary>
        ///     The trackable type.
        /// </summary>
        [JsonPropertyName("trackable_type")]
        public string TrackableType { get; set; }

        /// <summary>
        ///     The User Id of the activity.
        /// </summary>
        [JsonPropertyName("owner_id")]
        public int OwnerId { get; set; }

        /// <summary>
        ///     What action occurred.
        /// </summary>
        [JsonPropertyName("action")]
        public string Action { get; set; }

        [JsonPropertyName("created_at")] public DateTime CreatedAt { get; set; }

        public override string ToString()
        {
            return $"{Id}: {Action}";
        }
    }
}