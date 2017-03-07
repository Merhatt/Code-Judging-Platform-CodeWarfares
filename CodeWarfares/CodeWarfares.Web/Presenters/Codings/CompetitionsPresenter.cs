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
    /// <summary>
    /// Presenter Competitions Page
    /// </summary>
    public class CompetitionsPresenter : Presenter<ICompetitionsView>, ICompetitionsPresenter
    {
        private IProblemService problemService;
        private const int ProblemCount = 4;

        public CompetitionsPresenter(ICompetitionsView view, IProblemService problemService) : base(view)
        {
            if (problemService == null)
            {
                throw new NullReferenceException("problemService cannot be null");
            }

            this.problemService = problemService;

            view.MyInit += Initialize;
        }

        private void Initialize(object sender, EventArgs e)
        {
            this.View.Model.EasyProblems = this.problemService.GetNewestTopFromCategory(ProblemCount, DifficultyType.Easy).ToList();
            this.View.Model.MediumProblems = this.problemService.GetNewestTopFromCategory(ProblemCount, DifficultyType.Medium).ToList();
            this.View.Model.HardProblems = this.problemService.GetNewestTopFromCategory(ProblemCount, DifficultyType.Hard).ToList();
            this.View.Model.VeryHardProblems = this.problemService.GetNewestTopFromCategory(ProblemCount, DifficultyType.VeryHard).ToList();
        }
    }
}