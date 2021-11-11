using System.Collections.Generic;
using HelpJuice.Client.Queries.Models;

namespace HelpJuice.Client.Queries
{
    public class ActivitiesQuery
    {
        public Meta Meta { get; set; }
        public List<Activity> Activities { get; set; }
    }
}