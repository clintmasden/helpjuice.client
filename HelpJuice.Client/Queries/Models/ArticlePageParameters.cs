using System;

namespace HelpJuice.Client.Queries.Models
{
    /// <summary>
    ///     Endpoints that return collections of resources must limit the number of records returned in a given response. A
    ///     typical endpoint will return 25 records by default, the query parameter limit can be used to alter the number of
    ///     records returned.
    /// </summary>
    public class ArticlePageParameters : PageParameters
    {
        /// <summary>
        ///     type: Date, eg. 20-09-2021
        /// </summary>
        public DateTime? CreatedSince { get; set; }

        /// <summary>
        ///     type: Integer, accepts ( 0 - Public, 1 - Internal, 2 - Private )
        /// </summary>
        public int? Accessibility { get; set; }

        /// <summary>
        ///     type: Bool, accepts: ( True, False)
        /// </summary>
        public bool? IsPublished { get; set; }

        /// <summary>
        ///     type: String, accepts: language shortcode eg. en_us
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        ///     The query string used for the responses.
        /// </summary>
        public new string HttpQueryParameters
        {
            get
            {
                var query = $"?limit={Limit}&page={Page}";
                query = CreatedSince.HasValue ? $"{query}&created_since={CreatedSince.Value.ToString("dd-MM-yyyy")}" : query;
                query = Accessibility.HasValue ? $"{query}&accessibility={Accessibility.Value}" : query;
                query = IsPublished.HasValue ? $"{query}&is_published={IsPublished.Value}" : query;
                query = !string.IsNullOrWhiteSpace(Language) ? $"{query}&language={Language}" : query;

                return query;
            }
        }
    }
}