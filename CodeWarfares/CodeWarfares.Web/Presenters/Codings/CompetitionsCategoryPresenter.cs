using CodeWarfares.Data.Models.Enums;
using CodeWarfares.Data.Services.Contracts.CodeTesting;
using CodeWarfares.Web.EventArguments;
using CodeWarfares.Web.Presenters.Contracts.Codings;
using CodeWarfares.Web.Views.Contracts.Coding;
using System;
using System.Linq;
using WebFormsMvp;

namespace CodeWarfares.Web.Presenters.Codings
{
    public class CompetitionsCategoryPresenter : Presenter<ICompetitionsCategoryView>, ICompetitionsCategoryPresenter
    {
        private IProblemService problemService;

        public CompetitionsCategoryPresenter(ICompetitionsCategoryView view, IProblemService problemService) : base(view)
        {
            if (problemService == null)
            {
                throw new ArgumentNullException("problemService cannot be null");
            }

            this.problemService = problemService;

            view.MyInit += Initialize;
        }

        public void Initialize(object sender, CompetitionsCategoryEventArgs e)
        {
            DifficultyType diffuculty;

            if (e.Difficulty == "Easy")
            {
                diffuculty = DifficultyType.Easy;
                this.View.Model.CategoryTitle = "Лесни Задачи";
            }
            else if (e.Difficulty == "Medium")
            {
                diffuculty = DifficultyType.Medium;
                this.View.Model.CategoryTitle = "Средни Задачи";
            }
            else if (e.Difficulty == "Hard")
            {
                diffuculty = DifficultyType.Hard;
                this.View.Model.CategoryTitle = "Трудни Задачи";
            }
            else
            {
                diffuculty = DifficultyType.VeryHard;
                this.View.Model.CategoryTitle = "Много Трудни Задачи";
            }

            this.View.Model.Problems = this.problemService.GetAllOrderedByType(diffuculty).ToList();
        }
    }
}