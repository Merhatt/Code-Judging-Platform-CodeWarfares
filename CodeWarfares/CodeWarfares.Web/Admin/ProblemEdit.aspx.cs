using CodeWarfares.Web.Presenters.Admin;
using CodeWarfares.Web.Views.Contracts.Admin;
using CodeWarfares.Web.Views.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace CodeWarfares.Web.Admin
{
    [PresenterBinding(typeof(ProblemEditPresenter))]
    public partial class ProblemEdit : MvpPage<ProblemEditModel>, IProblemEditView
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}