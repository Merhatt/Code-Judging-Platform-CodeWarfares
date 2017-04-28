using CodeWarfares.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeWarfares.Web.Views.Models
{
    public class ProblemEditModel
    {
        public Problem ProblemNow { get; set; }
        public bool NotFoundPage { get; set; }
        public IList<string> Difficulties { get; set; }
        public int SelectedDificultyIndex { get; set; }
        public bool ShouldUploadFile { get; internal set; }
        public bool IsErrorActive { get; internal set; }
        public string FileUploadPath { get; internal set; }
        public string ErrorText { get; internal set; }
    }
}