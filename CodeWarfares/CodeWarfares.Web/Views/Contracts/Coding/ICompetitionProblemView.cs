using CodeWarfares.Web.EventArguments;
using CodeWarfares.Web.Views.Models;
using System;
using WebFormsMvp;

namespace CodeWarfares.Web.Views.Contracts.Coding
{
    public interface ICompetitionProblemView : IView<CompetitionProblemViewModel>
    {
        event EventHandler<CompetitionProblemInitEventArgs> MyInit;

        event EventHandler GetDescriptionEvent;

        event EventHandler<SendTaskEventArgs> SendTaskEvent;
    }
}