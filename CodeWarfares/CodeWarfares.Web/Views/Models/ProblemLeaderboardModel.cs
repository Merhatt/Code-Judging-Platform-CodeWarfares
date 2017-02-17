using CodeWarfares.Data.Models;
using System.Collections.Generic;

namespace CodeWarfares.Web.Views.Models
{
    public class ProblemLeaderboardModel
    {
        public IEnumerable<Submition> Leaderboard { get; set; }

        public Problem ProblemNow { get; set; }
    }
}