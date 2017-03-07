using CodeWarfares.Data.Services.Contracts.Account;
using CodeWarfares.Web.Presenters.Contracts.Codings;
using CodeWarfares.Web.Views.Contracts.Coding;
using System;
using System.Linq;
using WebFormsMvp;

namespace CodeWarfares.Web.Presenters.Codings
{
    /// <summary>
    /// Presenter for Leaderboard Page
    /// </summary>
    public class LeaderboardPresenter : Presenter<ILeaderboardView>, ILeaderboardPresenter
    {
        private IUserServices userServices;

        public LeaderboardPresenter(ILeaderboardView view, IUserServices userServices) : base(view)
        {
            if (userServices == null)
            {
                throw new NullReferenceException("userServices cannot be null");
            }

            view.MyInit += Initialization;

            this.userServices = userServices;
        }

        private void Initialization(object sender, EventArgs e)
        {
            this.View.Model.Leaderboard = this.userServices.GetAllUsersWithPoints()
                                          .OrderByDescending(x => x.TotalPoints);
        }
    }
}