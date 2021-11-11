using System.Collections.Generic;
using HelpJuice.Client.Queries.Models;

namespace HelpJuice.Client.Responses
{
    public class SearchesQuery
    {
        public Meta Meta { get; set; }
        public List<Search> Searches { get; set; }
    }
}