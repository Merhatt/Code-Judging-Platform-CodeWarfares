using CodeWarfares.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeWarfares.Web.Views.Models
{
    public class LeaderboardModel
    {
        public IEnumerable<User> Leaderboard { get; set; }
    }
}