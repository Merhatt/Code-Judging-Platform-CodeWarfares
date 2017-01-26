using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWarfares.Data.Models.Contracts
{
    public interface IUser
    {
        string UserName { get; set; }

        string Email { get; set; }
    }
}
