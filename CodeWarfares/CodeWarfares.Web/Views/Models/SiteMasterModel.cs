using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeWarfares.Web.Views.Models
{
    public class SiteMasterModel
    {
        public string ViewStateUserKey { get; set; }

        public string TokenKey { get; set; }

        public string UserNameKey { get; set; }

        public bool SetCookies { get; set; }
    }
}