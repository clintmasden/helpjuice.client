using System.Collections.Generic;
using HelpJuice.Client.Queries.Models;

namespace HelpJuice.Client.Queries
{
    public class CategoriesQuery
    {
        public Meta Meta { get; set; }
        public List<Category> Categories { get; set; }
    }
}