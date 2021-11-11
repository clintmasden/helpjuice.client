using System.Collections.Generic;
using HelpJuice.Client.Queries.Models;

namespace HelpJuice.Client.Responses
{
    public class UsersQuery
    {
        public Meta Meta { get; set; }
        public List<User> Users { get; set; }
    }
}