using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeWarfares.Web.Views.Models
{
    public class OpenAuthProvidersModel
    {
        public string RedirectUrl { get; set; }

        public int StatusUrl { get; set; }

        public bool Completed { get; set; }
    }
}