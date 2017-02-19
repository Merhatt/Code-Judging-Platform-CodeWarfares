using CodeWarfares.Web.Presenters.Codings;
using CodeWarfares.Web.Views.Contracts.Coding;
using CodeWarfares.Web.Views.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace CodeWarfares.Web.Codings
{
    [PresenterBinding(typeof(LeaderboardPresenter))]
    public partial class Leaderboard : MvpPage<LeaderboardModel>, ILeaderboardView
    {
        public event EventHandler MyInit;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.MyInit?.Invoke(sender, e);

            this.ProblemLeaderboardGridView.DataSource = this.Model.Leaderboard.ToList();
            this.ProblemLeaderboardGridView.DataBind();
            
        }

        protected void ProblemLeaderboardGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.ProblemLeaderboardGridView.PageIndex = e.NewPageIndex;
            this.ProblemLeaderboardGridView.DataSource = this.Model.Leaderboard;
            this.ProblemLeaderboardGridView.DataBind();
        }
    }
}