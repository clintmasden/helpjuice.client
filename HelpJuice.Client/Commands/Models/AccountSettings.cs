using System.Text.Json.Serialization;

namespace HelpJuice.Client.Commands.Models
{
    public class AccountSettings
    {
        /// <summary>
        ///     Name of your account.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// </summary>
        [JsonPropertyName("subdomain")]
        public string Subdomain { get; set; }

        /// <summary>
        ///     The number of articles that will be shown in your knowledge base.
        /// </summary>
        [JsonPropertyName("top_questions_count")]
        public int TopQuestionsCount { get; set; }

        /// <summary>
        ///     Use your knowledge base internally only.
        /// </summary>
        [JsonPropertyName("internal_kb")]
        public bool InternalKb { get; set; }

        /// <summary>
        ///     Password expiration for new users, number of days.
        /// </summary>
        [JsonPropertyName("expire_password_after_days")]
        public object ExpirePasswordAfterDays { get; set; }

        /// <summary>
        ///     Support Email address.
        /// </summary>
        [JsonPropertyName("contact_us_email")]
        public string ContactUsEmail { get; set; }

        /// <summary>
        ///     Contact us emails, subject line.
        /// </summary>
        [JsonPropertyName("contact_us_subject")]
        public string ContactUsSubject { get; set; }

        /// <summary>
        ///     Send all contact us emails asset in contact_us_email field.
        /// </summary>
        [JsonPropertyName("contact_us_single_sender")]
        public bool ContactUsSingleSender { get; set; }

        /// <summary>
        ///     Only signed-in users can send Article requests.
        /// </summary>
        [JsonPropertyName("only_internal_article_requests")]
        public bool OnlyInternalArticleRequests { get; set; }
    }
}