using CodeWarfares.Web.EventArguments;
using CodeWarfares.Web.Views.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace CodeWarfares.Web.Views.Contracts.Admin
{
    /// <summary>
    /// Problem Upload Page View 
    /// </summary>
    public interface IProblemUploadView : IView<ProblemUploadModel>
    {
        event EventHandler<ProblemUploadClickEventArgs> ProblemUploadEvent;

        event EventHandler MyInit;
    }
}
