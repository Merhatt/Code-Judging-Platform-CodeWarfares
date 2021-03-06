﻿using CodeWarfares.Web.EventArguments;
using CodeWarfares.Web.Views.Models;
using System;
using WebFormsMvp;

namespace CodeWarfares.Web.Views.Contracts.Coding
{
    /// <summary>
    /// Competition problem page view
    /// </summary>
    public interface ICompetitionProblemView : IView<CompetitionProblemViewModel>
    {
        event EventHandler<CompetitionProblemEventArgs> MyInitEvent;

        event EventHandler GetDescriptionEvent;

        event EventHandler<SendTaskEventArgs> SendTaskEvent;

        event EventHandler<CompetitionProblemEventArgs> SetSubmitionsEventArgs;
    }
}