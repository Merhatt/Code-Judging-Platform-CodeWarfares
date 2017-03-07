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
    /// <summary>
    /// Presenter for Competitin Problem Page
    /// </summary>
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
            this.laungages.Add("C", ContestLaungagesTypes.C);
            this.laungages.Add("C++ 14", ContestLaungagesTypes.CPP14);
            this.laungages.Add("C++ 4.3.2", ContestLaungagesTypes.CPPGcc432);
            this.laungages.Add("C++ 4.9.2", ContestLaungagesTypes.CPPGcc492);
            this.laungages.Add("C99", ContestLaungagesTypes.C99);
            this.laungages.Add("CLIPS", ContestLaungagesTypes.CLIPS);
            this.laungages.Add("Clojure", ContestLaungagesTypes.Clojure);
            this.laungages.Add("COBOL", ContestLaungagesTypes.Cobol);
            this.laungages.Add("D", ContestLaungagesTypes.D);
            this.laungages.Add("Erlang", ContestLaungagesTypes.Erlang);
            this.laungages.Add("F#", ContestLaungagesTypes.FSharp);
            this.laungages.Add("Factor", ContestLaungagesTypes.Factor);
            this.laungages.Add("Forth", ContestLaungagesTypes.Forth);
            this.laungages.Add("Fortran", ContestLaungagesTypes.Fortran);
            this.laungages.Add("Go", ContestLaungagesTypes.Go);
            this.laungages.Add("Groovy", ContestLaungagesTypes.Groovy);
            this.laungages.Add("Haskell", ContestLaungagesTypes.Haskel);
            this.laungages.Add("Icon", ContestLaungagesTypes.Icon);
            this.laungages.Add("Intercal", ContestLaungagesTypes.Intercal);
            this.laungages.Add("Java", ContestLaungagesTypes.Java);
            this.laungages.Add("JavaScript", ContestLaungagesTypes.Javascript);
            this.laungages.Add("Lua", ContestLaungagesTypes.Lua);
            this.laungages.Add("Nemerle", ContestLaungagesTypes.Nemerle);
            this.laungages.Add("Nice", ContestLaungagesTypes.Nice);
            this.laungages.Add("Nimrod", ContestLaungagesTypes.Nimrod);
            this.laungages.Add("Node.js", ContestLaungagesTypes.NodeJs);
            this.laungages.Add("Objective-C", ContestLaungagesTypes.ObjectiveC);
            this.laungages.Add("Ocaml", ContestLaungagesTypes.Ocaml);
            this.laungages.Add("Octave", ContestLaungagesTypes.Octave);
            this.laungages.Add("Oz", ContestLaungagesTypes.Oz);
            this.laungages.Add("PARIGP", ContestLaungagesTypes.PariGp);
            this.laungages.Add("Pascal", ContestLaungagesTypes.Pascal);
            this.laungages.Add("Perl", ContestLaungagesTypes.Perl);
            this.laungages.Add("PHP", ContestLaungagesTypes.PHP);
            this.laungages.Add("Pike", ContestLaungagesTypes.Pike);
            this.laungages.Add("Prolog", ContestLaungagesTypes.Prolog);
            this.laungages.Add("Python", ContestLaungagesTypes.Python);
            this.laungages.Add("R", ContestLaungagesTypes.R);
            this.laungages.Add("Ruby", ContestLaungagesTypes.Ruby);
            this.laungages.Add("Scala", ContestLaungagesTypes.Scala);
            this.laungages.Add("Scheme", ContestLaungagesTypes.Scheme);
            this.laungages.Add("Smalltalk", ContestLaungagesTypes.SmallTalk);
            this.laungages.Add("VB.NET", ContestLaungagesTypes.VBNET);
            this.laungages.Add("Whitespace", ContestLaungagesTypes.WhiteSpace);

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

            if (problemNow == null)
            {
                this.View.Model.NotFoundPage = true;
            }

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

            if (problemNow == null)
            {
                this.View.Model.NotFoundPage = true;
                return;
            }

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