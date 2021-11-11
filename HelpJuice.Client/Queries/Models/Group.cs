using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace HelpJuice.Client.Queries.Models
{
    public class Group
    {
        /// <summary>
        ///     The Id of the group.
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        ///     Name of the group.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        ///     Enable smart loading users in this group.
        /// </summary>
        [JsonPropertyName("smart_load")]
        public bool SmartLoad { get; set; }

        [JsonPropertyName("created_at")] public DateTime CreatedAt { get; set; }

        /// <summary>
        ///     A email extension that will be auto-loaded to this group. SmartLoad has to be enabled.
        /// </summary>
        [JsonPropertyName("auto_groups")]
        public List<GroupAutoGroup> AutoGroups { get; set; }

        /// <summary>
        ///     The users of this group.
        /// </summary>
        [JsonPropertyName("users")]
        public List<User> Users { get; set; }

        public override string ToString()
        {
            return $"{Id}: {Name}";
        }
    }
}