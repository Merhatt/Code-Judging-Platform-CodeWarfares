using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CodeWarfares.Data.Models
{
    public class User : IdentityUser, Contracts.IUser
    {
        private ICollection<Submition> submition;
        private ICollection<Problem> problems;

        public User()
        {
            this.submition = new HashSet<Submition>();
            this.problems = new HashSet<Problem>();
        }

        public virtual ICollection<Submition> Submition { get { return this.submition; } set { this.submition = value; } }

        public virtual ICollection<Problem> Problems { get { return this.problems; } set { this.problems = value; } }

        public ClaimsIdentity GenerateUserIdentity(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = manager.CreateIdentity(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            return Task.FromResult(GenerateUserIdentity(manager));
        }
    }
}
