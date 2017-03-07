using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeWarfares.Web.Views.Models
{
    public class ProblemLeaderboardUserModel
    {
        public string Username { get; set; }

        public int Rank { get; set; }

        public int Points { get; set; }
    }
}