using CodeWarfares.Data.Models.Enums;
using CodeWarfares.Data.Services.Contracts.CodeTesting;
using CodeWarfares.Web.Presenters.Contracts.Codings;
using CodeWarfares.Web.Views.Contracts.Coding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebFormsMvp;

namespace CodeWarfares.Web.Presenters.Codings
{
    public class CompetitionsPresenter : Presenter<ICompetitionsView>, ICompetitionsPresenter
    {
        private IProblemService problemService;
        private const int ProblemCount = 4;

        public CompetitionsPresenter(ICompetitionsView view, IProblemService problemService) : base(view)
        {
            if (problemService == null)
            {
                throw new ArgumentNullException("problemService cannot be null");
            }

            this.problemService = problemService;

            view.MyInit += Initialize;
        }

        public void Initialize(object sender, EventArgs e)
        {
            this.View.Model.EasyProblems = this.problemService.GetNewestTopFromCategory(ProblemCount, DifficultyType.Easy).ToList();
        }
    }
}