using CodeWarfares.Web.Presenters.Contracts.Codings;
using CodeWarfares.Web.Views.Contracts.Coding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebFormsMvp;
using CodeWarfares.Web.EventArguments;
using CodeWarfares.Data.Services.Contracts.CodeTesting;
using CodeWarfares.Data.Models;

namespace CodeWarfares.Web.Presenters.Codings
{
    /// <summary>
    /// Presemter for Problem Leaderboard page
    /// </summary>
    public class ProblemLeaderboardPresenter : Presenter<IProblemLeaderboardView>, IProblemLeaderboardPresenter
    {
        private IProblemService problemService;

        public ProblemLeaderboardPresenter(IProblemLeaderboardView view, IProblemService problemService) : base(view)
        {
            if (problemService == null)
            {
                throw new NullReferenceException("problemService cannot be null");
            }

            this.problemService = problemService;

            view.MyInit += Initialization;
        }

        private void Initialization(object sender, ProblemLeaderboardInitEventArgs e)
        {
            Problem problem = this.problemService.GetById(e.Id);

            if (problem == null)
            {
                this.View.Model.PageNotFound = true;
                return;
            }

            this.View.Model.ProblemNow = problem;

            this.View.Model.Leaderboard = this.problemService.GetLeaderboard(problem);
        }
    }
}