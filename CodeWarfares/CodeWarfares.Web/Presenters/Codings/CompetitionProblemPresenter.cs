using CodeWarfares.Data.Services.Enums;
using CodeWarfares.Web.Presenters.Contracts.Codings;
using CodeWarfares.Web.Views.Contracts.Coding;
using System;
using System.Collections.Generic;
using WebFormsMvp;
using CodeWarfares.Web.EventArguments;
using CodeWarfares.Data.Services.Contracts.CodeTesting;
using CodeWarfares.Data.Models;
using CodeWarfares.Data.Services.Contracts.Account;
using CodeWarfares.Data.Models.Enums;

namespace CodeWarfares.Web.Presenters.Codings
{
    public class CompetitionProblemPresenter : Presenter<ICompetitionProblemView>, ICompetitionProblemPresenter
    {
        private IDictionary<string, ContestLaungagesTypes> laungages;
        private IProblemService problemService;
        private ICodeSubmitionService codeSubmitionService;
        private IUserServices userServices;

        public CompetitionProblemPresenter(ICompetitionProblemView view, IProblemService problemService, ICodeSubmitionService codeSubmitionService, IUserServices userServices) : base(view)
        {
            if (problemService == null)
            {
                throw new NullReferenceException("problemService cannot be null");
            }

            if (codeSubmitionService == null)
            {
                throw new NullReferenceException("codeSubmitionService cannot be null");
            }

            if (userServices == null)
            {
                throw new NullReferenceException("userServices cannot be null");
            }

            this.laungages = new Dictionary<string, ContestLaungagesTypes>();
            this.laungages.Add("C#", ContestLaungagesTypes.CSharp);
            this.laungages.Add("C++", ContestLaungagesTypes.CPP);
            this.laungages.Add("C", ContestLaungagesTypes.C);

            view.MyInitEvent += Initialization;
            view.GetDescriptionEvent += GetDescription;
            view.SendTaskEvent += SendTask;
            view.SetSubmitionsEventArgs += SetSubmitions;

            this.problemService = problemService;
            this.codeSubmitionService = codeSubmitionService;
            this.userServices = userServices;
        }

        private void SetSubmitions(object sender, CompetitionProblemEventArgs e)
        {
            User user = this.userServices.GetByUsername(e.Username);

            Problem problemNow = this.problemService.GetById(e.ProblemId);

            this.View.Model.UserSubmitions = GetSubmitions(user, problemNow);
        }

        private void SendTask(object sender, SendTaskEventArgs e)
        {
            ContestLaungagesTypes laungageNow = laungages[e.Laungage];

            User user = this.userServices.GetByUsername(e.Username);

            this.codeSubmitionService.SendSubmition(user, this.View.Model.Problem, e.Code, laungageNow);
        }

        private void GetDescription(object sender, EventArgs e)
        {
            this.View.Model.ProblemPath = "/ProblemDescriptions/ProblemDescription" + this.View.Model.Problem.Id  + ".docx";
        }

        private void Initialization(object sender, CompetitionProblemEventArgs e)
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

            User user = this.userServices.GetByUsername(e.Username);

            this.View.Model.UserSubmitions = GetSubmitions(user, problemNow);
        }

        private IEnumerable<Submition> GetSubmitions(User user, Problem problem)
        {
            if (user == null)
            {
                throw new NullReferenceException("user cannot be null");
            }

            if (problem == null)
            {
                throw new NullReferenceException("problem cannot be null");
            }

            return this.codeSubmitionService.GetAllUserSubmition(user, problem);
        }
    }
}