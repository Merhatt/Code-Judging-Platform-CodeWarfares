using CodeWarfares.Web.Views.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace CodeWarfares.Web.Views.Contracts.Coding
{
    /// <summary>
    /// Leaderboard View
    /// </summary>
    public interface ILeaderboardView : IView<LeaderboardModel>
    {
        event EventHandler MyInit;
    }
}
