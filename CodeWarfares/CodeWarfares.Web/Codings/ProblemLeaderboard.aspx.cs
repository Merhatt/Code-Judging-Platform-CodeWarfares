using CodeWarfares.Web.Views.Contracts.Coding;
using CodeWarfares.Web.Views.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsMvp.Web;
using CodeWarfares.Web.EventArguments;
using WebFormsMvp;
using CodeWarfares.Web.Presenters.Codings;

namespace CodeWarfares.Web.Codings
{
    [PresenterBinding(typeof(ProblemLeaderboardPresenter))]
    public partial class ProblemLeaderboard : MvpPage<ProblemLeaderboardModel>, IProblemLeaderboardView
    {
        public event EventHandler<ProblemLeaderboardInitEventArgs> MyInit;

        protected void Page_Load(object sender, EventArgs e)
        {
            int id = 0;
            bool canParse = int.TryParse(this.Request.QueryString["Id"], out id);

            if (canParse == false)
            {
                this.Response.Redirect("/Errors/404");
                return;
            }

            this.MyInit?.Invoke(sender, new ProblemLeaderboardInitEventArgs(id));

            if (this.Model.PageNotFound)
            {
                this.Response.Redirect("/Errors/404");
                return;
            }

            this.ProblemLeaderboardGridView.DataSource = this.Model.Leaderboard.ToList();
            this.ProblemLeaderboardGridView.DataBind();
            this.ProblemName.Text = "Класация за " + this.Model.ProblemNow.Name;
        }

        protected void ProblemLeaderboardGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.ProblemLeaderboardGridView.PageIndex = e.NewPageIndex;
            this.ProblemLeaderboardGridView.DataSource = this.Model.Leaderboard;
            this.ProblemLeaderboardGridView.DataBind();
        }
    }
}