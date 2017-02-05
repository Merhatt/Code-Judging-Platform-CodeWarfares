using CodeWarfares.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeWarfares.Web.EventArguments
{
    public class CompetitionsCategoryEventArgs : EventArgs
    {
        public CompetitionsCategoryEventArgs(string difficulty)
        {
            this.Difficulty = difficulty;
        }

        public string Difficulty { get; set; }
    }
}