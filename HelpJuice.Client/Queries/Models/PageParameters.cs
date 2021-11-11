namespace HelpJuice.Client.Queries.Models
{
    /// <summary>
    ///     Endpoints that return collections of resources must limit the number of records returned in a given response. A
    ///     typical endpoint will return 25 records by default, the query parameter limit can be used to alter the number of
    ///     records returned.
    /// </summary>
    public class PageParameters
    {
        public PageParameters()
        {
            Page = 1;
            Limit = 25;
        }


        /// <summary>
        ///     Current page with data.
        /// </summary>
        public int Page { get; set; }


        /// <summary>
        ///     The number of results to display in each page ( default = 25, max = 1000 ).
        /// </summary>
        public int Limit { get; set; }


        /// <summary>
        ///     The query string used for the responses.
        /// </summary>
        public string HttpQueryParameters => $"?limit={Limit}&page={Page}";
    }
}