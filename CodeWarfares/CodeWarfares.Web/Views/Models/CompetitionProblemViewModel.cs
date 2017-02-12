using CodeWarfares.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeWarfares.Web.Views.Models
{
    public class CompetitionProblemViewModel
    {
        public IEnumerable<string> ProgrammingLaungages { get; set; }

        public string ProblemTitle { get; set; }

        public string ProblemPath { get; set; }

        public Problem Problem { get; set; }
    }
}