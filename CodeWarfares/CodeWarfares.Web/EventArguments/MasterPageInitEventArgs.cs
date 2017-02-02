using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeWarfares.Web.EventArguments
{
    public class MasterPageInitEventArgs : EventArgs
    {
        public MasterPageInitEventArgs(string cookie)
        {
            this.Cookie = cookie;
        }

        public string Cookie { get; private set; }
    }
}