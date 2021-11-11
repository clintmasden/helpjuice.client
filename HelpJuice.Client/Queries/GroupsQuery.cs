using System.Collections.Generic;
using HelpJuice.Client.Queries.Models;

namespace HelpJuice.Client.Queries
{
    public class GroupsQuery
    {
        public Meta Meta { get; set; }
        public List<Group> Groups { get; set; }
    }
}