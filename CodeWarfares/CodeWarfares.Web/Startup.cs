using CodeWarfares.Data.Services.CodeTesting;
using CodeWarfares.Data.Services.Enums;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CodeWarfares.Web.Startup))]
namespace CodeWarfares.Web
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
            CodeTestingServices testing = new CodeTestingServices();

            testing.TestCode("using System; using System.Collections.Generic; using System.Linq; 			 public class Program {   public static void Main()   {     Console.WriteLine(\"Hello C#\");   } }", ContestLaungagesTypes.CSharp, new string[] {"1"});
        }
    }
}
