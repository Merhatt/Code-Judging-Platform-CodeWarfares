using CodeWarfares.Data.Models;
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
    [PresenterBinding(typeof(CompetitionsPresenter))]
    public partial class Competitions : MvpPage<CompetitionsViewModel>, ICompetitionsView
    {
        public event EventHandler MyInit;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.MyInit?.Invoke(sender, e);

            this.EasyProblems.DataSource = this.Model.EasyProblems;
            this.EasyProblems.DataBind();

            this.MediumProblems.DataSource = this.Model.MediumProblems;
            this.MediumProblems.DataBind();

            this.HardProblems.DataSource = this.Model.HardProblems;
            this.HardProblems.DataBind();

            this.VeryHardProblems.DataSource = this.Model.VeryHardProblems;
            this.VeryHardProblems.DataBind();
        }
    }
}