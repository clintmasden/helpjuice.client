using System.Text.Json.Serialization;

namespace HelpJuice.Client.Commands.Models
{
    public class Group
    {
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

        /// <summary>
        ///     Join users to this group.
        /// </summary>
        [JsonPropertyName("user_ids")]
        public int[] UserIds { get; set; }

        /// <summary>
        ///     A comma-separated string of email extension that will be auto-loaded to this group. SmartLoad has to be enabled.
        /// </summary>
        [JsonPropertyName("auto_groups")]
        public string AutoGroups { get; set; }
    }
}