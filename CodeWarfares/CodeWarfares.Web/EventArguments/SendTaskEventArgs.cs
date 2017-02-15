using CodeWarfares.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeWarfares.Web.EventArguments
{
    public class SendTaskEventArgs : EventArgs
    {
        public SendTaskEventArgs(string code, string laungage, string username)
        {
            this.Code = code;
            this.Laungage = laungage;
            this.Username = username;
        }

        public string Code { get; private set; }

        public string Laungage { get; private set; }

        public string Username { get; private set; }
    }
}