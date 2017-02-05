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

namespace CodeWarfares.Web.Codings
{
    [PresenterBinding(typeof(CompetitionsCategoryPresenter))]
    public partial class CompetitionsCategory : MvpPage<CompetitionsCategoryViewModel>, ICompetitionsCategoryView
    {
        public event EventHandler<CompetitionsCategoryEventArgs> MyInit;

        protected void Page_Load(object sender, EventArgs e)
        {
            CompetitionsCategoryEventArgs args = new CompetitionsCategoryEventArgs(this.Request.QueryString["Difficulty"]);

            this.MyInit.Invoke(sender, args);
        }
    }
}