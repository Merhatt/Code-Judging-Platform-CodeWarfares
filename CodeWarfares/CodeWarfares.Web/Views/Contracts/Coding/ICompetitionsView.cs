using CodeWarfares.Web.Views.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebFormsMvp;

namespace CodeWarfares.Web.Views.Contracts.Coding
{
    public interface ICompetitionsView : IView<CompetitionsViewModel>
    {
        event EventHandler MyInit;
    }
}