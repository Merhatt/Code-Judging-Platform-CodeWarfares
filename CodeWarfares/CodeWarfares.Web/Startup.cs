using CodeWarfares.Data.Models;
using CodeWarfares.Data.Models.Factories;
using CodeWarfares.Data.Repositories;
using CodeWarfares.Data.Services.Account;
using CodeWarfares.Data.Services.CodeTesting;
using CodeWarfares.Data.Services.Enums;
using CodeWarfares.Utils.Https;
using CodeWarfares.Utils.Json;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CodeWarfares.Web.Startup))]
namespace CodeWarfares.Web
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
