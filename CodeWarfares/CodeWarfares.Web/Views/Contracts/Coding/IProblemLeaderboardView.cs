using CodeWarfares.Web.EventArguments;
using CodeWarfares.Web.Views.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebFormsMvp;

namespace CodeWarfares.Web.Views.Contracts.Coding
{
    /// <summary>
    /// Problem Leaderboard View
    /// </summary>
    public interface IProblemLeaderboardView : IView<ProblemLeaderboardModel>
    {
        event EventHandler<ProblemLeaderboardInitEventArgs> MyInit;
    }
}