using System.Security.Claims;
using System.Threading.Tasks;
using CodeWarfares.Data.Models;
using Microsoft.AspNet.Identity.Owin;

namespace CodeWarfares.Web.AppStart.Contracts
{
    public interface IApplicationSignInManager
    {
        bool SignIn(string userName, string password, bool isPersistent, bool shouldLockout);
    }
}