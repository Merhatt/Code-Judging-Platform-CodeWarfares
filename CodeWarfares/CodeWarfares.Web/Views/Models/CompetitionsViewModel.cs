using CodeWarfares.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeWarfares.Web.Views.Models
{
    public class CompetitionsViewModel
    {
        public IEnumerable<Problem> EasyProblems { get; set; }

        public IEnumerable<Problem> MediumProblems { get; set; }

        public IEnumerable<Problem> HardProblems { get; set; }

        public IEnumerable<Problem> VeryHardProblems { get; set; }
    }
}