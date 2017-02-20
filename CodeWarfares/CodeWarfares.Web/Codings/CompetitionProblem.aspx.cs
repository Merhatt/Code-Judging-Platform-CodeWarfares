using CodeWarfares.Web.Views.Contracts.Coding;
using CodeWarfares.Web.Views.Models;
using System;
using System.Linq;
using System.Web.UI.WebControls;
using WebFormsMvp.Web;
using CodeWarfares.Web.EventArguments;
using WebFormsMvp;
using CodeWarfares.Web.Presenters.Codings;

namespace CodeWarfares.Web.Codings
{
    [PresenterBinding(typeof(CompetitionProblemPresenter))]
    public partial class CompetitionProblem : MvpPage<CompetitionProblemViewModel>, ICompetitionProblemView
    {
        public event EventHandler<CompetitionProblemEventArgs> MyInitEvent;
        public event EventHandler GetDescriptionEvent;
        public event EventHandler<SendTaskEventArgs> SendTaskEvent;
        public event EventHandler<CompetitionProblemEventArgs> SetSubmitionsEventArgs;

        protected void Page_Load(object sender, EventArgs e)
        {
            int id = 0;
            bool canParse = int.TryParse(this.Request.QueryString["Id"], out id);

            if (canParse == false)
            {
                Response.Redirect("/Errors/404");
                return;
            }

            MyInitEvent.Invoke(this, new CompetitionProblemEventArgs(id, this.User.Identity.Name));

            if (this.Model.NotFoundPage)
            {
                Response.Redirect("/Errors/404");
                return;
            }

            this.PageTitle.InnerText = this.Model.ProblemTitle;

            DropdownLaungages.DataSource = this.Model.ProgrammingLaungages.ToList();

            DropdownLaungages.DataBind();

            this.SubmitionsGridView.DataSource = this.Model.UserSubmitions.ToList();
            this.SubmitionsGridView.DataBind();

            this.LeaderboardButton.PostBackUrl = "/Codings/ProblemLeaderboard?Id=" + id;
        }

        protected void GetDescription_Click(object sender, EventArgs e)
        {
            this.GetDescriptionEvent?.Invoke(sender, e);
            string filePath = this.Model.ProblemPath;

            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("Content-Disposition", string.Format("attachment; filename={0}", filePath));

            Response.TransmitFile(filePath);
            Response.End();
        }

        protected void SendTask_Click(object sender, EventArgs e)
        {
            string name = this.User.Identity.Name;

            var args = new SendTaskEventArgs(this.CodeText.Text, this.DropdownLaungages.SelectedValue, name);

            this.SendTaskEvent.Invoke(sender, args);
        }

        protected void SubmitionsGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.SubmitionsGridView.PageIndex = e.NewPageIndex;
            this.SubmitionsGridView.DataSource = this.Model.UserSubmitions;
            this.SubmitionsGridView.DataBind();
        }

        protected void PartialPostBackSynchronization_Click(object sender, EventArgs e)
        {
            int id = 0;
            bool canParse = int.TryParse(this.Request.QueryString["Id"], out id);

            if (canParse == false)
            {
                Response.Redirect("/Errors/404");
                return;
            }

            this.SetSubmitionsEventArgs.Invoke(this, new CompetitionProblemEventArgs(id, this.User.Identity.Name));

            if (this.Model.NotFoundPage)
            {
                Response.Redirect("/Errors/404");
                return;
            }

            this.SubmitionsGridView.DataSource = this.Model.UserSubmitions.ToList();
            this.SubmitionsGridView.DataBind();
        }
    }
}
