using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeWarfares.Web.Views.Models
{
    public class ProblemUploadModel
    {
        public bool ShouldUploadFile { get; set; }

        public string ErrorText { get; set; }

        public bool IsErrorActive { get; set; }

        public string FileUploadPath { get; set; }

        public IEnumerable<string> Difficulties { get; set; }
    }
}