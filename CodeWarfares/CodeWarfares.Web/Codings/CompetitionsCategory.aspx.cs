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
using CodeWarfares.Data.Models.Enums;
using WebFormsMvp;
using CodeWarfares.Web.Presenters.Codings;
using CodeWarfares.Data.Models;

namespace CodeWarfares.Web.Codings
{
    [PresenterBinding(typeof(CompetitionsCategoryPresenter))]
    public partial class CompetitionsCategory : MvpPage<CompetitionsCategoryViewModel>, ICompetitionsCategoryView
    {
        public event EventHandler<CompetitionsCategoryEventArgs> MyInit;

        public string CategoryName { get; set; }

        public void Page_Load(object sender, EventArgs e)
        {
            string difficulty = this.Request.QueryString["Difficulty"];

            CompetitionsCategoryEventArgs args = new CompetitionsCategoryEventArgs(difficulty);

            this.MyInit?.Invoke(sender, args);
            this.Problems.DataSource = this.Model.Problems;
            this.Problems.DataBind();
            this.CategoryName = this.Model.CategoryTitle;
        }
    }
}