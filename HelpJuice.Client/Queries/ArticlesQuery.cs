using System.Collections.Generic;
using HelpJuice.Client.Queries.Models;

namespace HelpJuice.Client.Queries
{
    public class ArticlesQuery
    {
        public Meta Meta { get; set; }
        public List<Article> Articles { get; set; }
    }
}