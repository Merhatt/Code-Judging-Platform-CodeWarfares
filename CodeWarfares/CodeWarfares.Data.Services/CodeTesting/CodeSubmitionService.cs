using CodeWarfares.Data.Contracts;
using CodeWarfares.Data.Models;
using CodeWarfares.Data.Models.Factories;
using CodeWarfares.Data.Services.Contracts.Account;
using CodeWarfares.Data.Services.Contracts.CodeTesting;
using CodeWarfares.Data.Services.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeWarfares.Data.Services.CodeTesting
{
    public class CodeSubmitionService : ICodeSubmitionService
    {
        private ICodeTestingServices codeTestingService;
        private ISubmitionFactory submitionFactory;
        private IRepository<Submition> submitions;
        private ITestCompletedFactory testCompletedFactory;
        private IUserServices userServices;

        public CodeSubmitionService(IRepository<Submition> submitions, ICodeTestingServices codeTestingService, ISubmitionFactory submitionFactory, ITestCompletedFactory testCompletedFactory, IUserServices userServices)
        {
            if (submitions == null)
            {
                throw new NullReferenceException("Submitions cannot be null");
            }
            else if (codeTestingService == null)
            {
                throw new NullReferenceException("codeTestingService cannot be null");
            }
            else if (submitionFactory == null)
            {
                throw new NullReferenceException("submitionFactory cannot be null");
            }
            else if (testCompletedFactory == null)
            {
                throw new NullReferenceException("testCompletedFactory cannot be null");
            }
            else if (userServices == null)
            {
                throw new NullReferenceException("userServices cannot be null");
            }

            this.codeTestingService = codeTestingService;
            this.submitionFactory = submitionFactory;
            this.submitions = submitions;
            this.testCompletedFactory = testCompletedFactory;
            this.userServices = userServices;
        }

        public void Create(Submition submition)
        {
            if (submition == null)
            {
                throw new NullReferenceException("submition to add cannot be null");
            }

            this.submitions.Add(submition);
            this.submitions.SaveChanges();
        }

        public void SendSubmition(User user, Problem problem, string source, ContestLaungagesTypes laungage)
        {
            if (user == null)
            {
                throw new NullReferenceException("user cannot be null");
            }
            else if (problem == null)
            {
                throw new NullReferenceException("problem cannot be null");
            }
            else if (source == null)
            {
                throw new NullReferenceException("source cannot be null");
            }

            Submition submition = this.submitionFactory.Create();
            submition.Code = source;
            submition.Author = user;
            submition.Problem = problem;
            submition.Finished = false;
            submition.Author = user;
            submition.Problem = problem;

            this.Create(submition);

            var testCases = problem.Tests.ToList();

            this.userServices.AddProblemToUser(user.Id, problem);

            for (int i = 0; i < testCases.Count; i++)
            {
                string resultId = this.codeTestingService.TestCode(source, laungage, testCases[i].TestParameter);

                TestCompleted completedTest = this.testCompletedFactory.Create();
                completedTest.SendId = resultId;
                completedTest.ExpectedResult = testCases[i].CorrectAnswer;

                submition.CompletedTests.Add(completedTest);
            }

            submition.CanCompile = true;

            this.submitions.SaveChanges();
        }

        public IQueryable<Submition> GetAllUserSubmition(User user, Problem problem)
        {
            if (user == null)
            {
                throw new NullReferenceException("user cannot be null");
            }

            if (problem == null)
            {
                throw new NullReferenceException("problem cannot be null");
            }

            IQueryable<Submition> userSubmitions = new List<Submition>().AsQueryable();

            if (user.Submition == null)
            {
                return userSubmitions;
            }

            userSubmitions = user.Submition.Where(x => x.ProblemId == problem.Id)
                  .OrderByDescending(x => x.SubmitionTime).AsQueryable();

            foreach (var item in userSubmitions)
            {
                if (item.Finished == false)
                {
                    item.Finished = this.codeTestingService.GetAreAllTestsCompleted(problem, item);
                    this.submitions.SaveChanges();
                }
            }

            return userSubmitions;
        }
    }
}
