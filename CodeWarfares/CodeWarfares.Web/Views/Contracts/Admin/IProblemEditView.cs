using CodeWarfares.Web.EventArguments;
using CodeWarfares.Web.Views.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebFormsMvp;

namespace CodeWarfares.Web.Views.Contracts.Admin
{
    public interface IProblemEditView : IView<ProblemEditModel>
    {
        event EventHandler<ProblemEditInitEventArgs> InitProblem;

        event EventHandler<ProblemUploadClickEventArgs> EditProblem;

        event EventHandler<ProblemEditInitEventArgs> DeleteProblem;
    }
}