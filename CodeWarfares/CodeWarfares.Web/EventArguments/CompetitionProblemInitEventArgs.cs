using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeWarfares.Web.EventArguments
{
    public class CompetitionProblemInitEventArgs : EventArgs
    {
        public CompetitionProblemInitEventArgs(int problemId, string username)
        {
            this.ProblemId = problemId;
            this.Username = username;
        }

        public int ProblemId { get; private set; }
        public string Username { get; private set; }
    }
}