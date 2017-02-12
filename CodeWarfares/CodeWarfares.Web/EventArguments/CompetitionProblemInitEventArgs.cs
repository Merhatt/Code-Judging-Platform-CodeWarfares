using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeWarfares.Web.EventArguments
{
    public class CompetitionProblemInitEventArgs : EventArgs
    {
        public CompetitionProblemInitEventArgs(int problemId)
        {
            this.ProblemId = problemId;
        }

        public int ProblemId { get; private set; }
    }
}