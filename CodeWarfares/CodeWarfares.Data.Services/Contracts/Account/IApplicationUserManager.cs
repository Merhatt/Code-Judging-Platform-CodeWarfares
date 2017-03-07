using CodeWarfares.Data.Models.Contracts;
using CodeWarfares.Data.Services.Account;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWarfares.Data.Services.Contracts.Account
{
    public interface IApplicationUserManager
    {
        /// <summary>
        /// Creates user
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        bool CreateUser(IUser user, string password);
    }
}
