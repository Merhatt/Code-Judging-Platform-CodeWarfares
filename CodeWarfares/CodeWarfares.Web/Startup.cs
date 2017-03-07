using Microsoft.Owin;
using Owin;
using System;
using System.Linq;

[assembly: OwinStartupAttribute(typeof(CodeWarfares.Web.Startup))]
namespace CodeWarfares.Web
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
