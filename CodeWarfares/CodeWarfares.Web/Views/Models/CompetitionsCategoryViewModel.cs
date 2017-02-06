using CodeWarfares.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeWarfares.Web.Views.Models
{
    public class CompetitionsCategoryViewModel
    {
        public IEnumerable<Problem> Problems { get; set; }

        public string CategoryTitle { get; set; }
    }
}