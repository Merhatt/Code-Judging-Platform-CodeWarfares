using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeWarfares.Web.EventArguments
{
    public class ProblemLeaderboardInitEventArgs : EventArgs
    {
        public ProblemLeaderboardInitEventArgs(int id)
        {
            this.Id = id;
        }

        public int Id { get; private set; }
    }
}