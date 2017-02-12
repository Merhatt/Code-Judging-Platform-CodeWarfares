using CodeWarfares.Data.Services.Enums;
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
using CodeWarfares.Data.Services.Contracts.Account;

namespace CodeWarfares.Web.Presenters.Codings
{
    public class CompetitionProbelmPresenter : Presenter<ICompetitionProblemView>, ICompetitionProbelmPresenter
    {
        private IDictionary<string, ContestLaungagesTypes> laungages;
        private IProblemService problemService;
        private ICodeSubmitionService codeSubmitionService;

        public CompetitionProbelmPresenter(ICompetitionProblemView view, IProblemService problemService, ICodeSubmitionService codeSubmitionService) : base(view)
        {
            this.laungages = new Dictionary<string, ContestLaungagesTypes>();
            this.laungages.Add("C#", ContestLaungagesTypes.CSharp);
            this.laungages.Add("C++", ContestLaungagesTypes.CPP);
            this.laungages.Add("C", ContestLaungagesTypes.C);

            view.MyInit += Initialization;
            view.GetDescriptionEvent += GetDescription;
            view.SendTaskEvent += SendTask;

            this.problemService = problemService;
            this.codeSubmitionService = codeSubmitionService;
        }

        private void SendTask(object sender, SendTaskEventArgs e)
        {
            ContestLaungagesTypes laungageNow = laungages[e.Laungage];

            this.codeSubmitionService.SendSubmition(e.User, this.View.Model.Problem, e.Code, laungageNow);
        }

        private void GetDescription(object sender, EventArgs e)
        {
            this.View.Model.ProblemPath = "../ProblemDescriptions/ProblemDescription" + this.View.Model.Problem.Id  + ".docx";
        }

        private void Initialization(object sender, CompetitionProblemInitEventArgs e)
        {
            Problem problemNow = this.problemService.GetById(e.ProblemId);
            this.View.Model.ProblemTitle = problemNow.Name;
            this.View.Model.Problem = problemNow;

            List<string> problemLaungages = new List<string>();

            foreach (var item in this.laungages)
            {
                problemLaungages.Add(item.Key);
            }

            this.View.Model.ProgrammingLaungages = problemLaungages;
        }
    }
}