using CodeWarfares.Web.Presenters.Contracts.Admin;
using CodeWarfares.Web.Views.Contracts.Admin;
using WebFormsMvp;

namespace CodeWarfares.Web.Presenters.Admin
{
    public class ProblemEditPresenter : Presenter<IProblemEditView>, IProblemEditPresenter
    {
        public ProblemEditPresenter(IProblemEditView view) : base(view)
        {
        }
    }
}