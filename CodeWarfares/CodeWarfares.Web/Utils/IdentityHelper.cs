using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeWarfares.Utils
{
    public static class IdentityHelper
    {
        // Used for XSRF when linking external logins
        public const string XsrfKey = "XsrfId";

        public const string ProviderNameKey = "providerName";
        
        public const string CodeKey = "code";
     
        public const string UserIdKey = "userId";
    }
}