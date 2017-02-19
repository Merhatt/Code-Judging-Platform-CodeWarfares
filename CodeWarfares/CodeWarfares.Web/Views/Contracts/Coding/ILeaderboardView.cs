using CodeWarfares.Web.Views.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace CodeWarfares.Web.Views.Contracts.Coding
{
    public interface ILeaderboardView : IView<LeaderboardModel>
    {
        event EventHandler MyInit;
    }
}
