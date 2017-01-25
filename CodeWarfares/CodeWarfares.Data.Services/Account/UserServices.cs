using CodeWarfares.Data.Services.Contracts.Account;
using CodeWarfares.Data.Services.Enums;

namespace CodeWarfares.Data.Services.Account
{
    public class UserServices : IUserServices
    {
        private readonly IApplicationSignInManager signInManager;

        public UserServices(IApplicationSignInManager signInManager)
        {
            this.signInManager = signInManager;
        }

        public LoginType PasswordSignIn(string username, string password, bool remember, bool shouldLockout = false)
        {
            var result = this.signInManager.SignIn(username, password, remember, shouldLockout);

            if (result)
            {
                return LoginType.Success;
            }
            else
            {
                return LoginType.Failure;
            }
        }
    }
}
