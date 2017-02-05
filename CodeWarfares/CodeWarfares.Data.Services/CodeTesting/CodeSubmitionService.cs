using CodeWarfares.Data.Contracts;
using CodeWarfares.Data.Models;
using CodeWarfares.Data.Models.Factories;
using CodeWarfares.Data.Services.Contracts.Account;
using CodeWarfares.Data.Services.Contracts.CodeTesting;
using CodeWarfares.Data.Services.Enums;
using CodeWarfares.Utils.JsonModels;
using CodeWarfares.Utils.PassingTests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWarfares.Data.Services.CodeTesting
{
    public class CodeSubmitionService : ICodeSubmitionService
    {
        private ICodeTestingServices codeTestingService;
        private IPassingTestsChecker passingTestsChecker;
        private ISubmitionFactory submitionFactory;
        private IRepository<Submition> submitions;
        private ITestCompletedFactory testCompletedFactory;
        private IUserServices userServices;

        public CodeSubmitionService(IRepository<Submition> submitions, ICodeTestingServices codeTestingService, ISubmitionFactory submitionFactory, ITestCompletedFactory testCompletedFactory, IPassingTestsChecker passingTestsChecker, IUserServices userServices)
        {
            if (submitions == null)
            {
                throw new ArgumentNullException("Submitions cannot be null");
            }
            else if (codeTestingService == null)
            {
                throw new ArgumentNullException("codeTestingService cannot be null");
            }
            else if (submitionFactory == null)
            {
                throw new ArgumentNullException("submitionFactory cannot be null");
            }
            else if (testCompletedFactory == null)
            {
                throw new ArgumentNullException("testCompletedFactory cannot be null");
            }
            else if (passingTestsChecker == null)
            {
                throw new ArgumentNullException("passingTestsChecker cannot be null");
            }
            else if (userServices == null)
            {
                throw new ArgumentNullException("userServices cannot be null");
            }

            this.codeTestingService = codeTestingService;
            this.submitionFactory = submitionFactory;
            this.submitions = submitions;
            this.testCompletedFactory = testCompletedFactory;
            this.passingTestsChecker = passingTestsChecker;
            this.userServices = userServices;
        }

        public void Create(Submition submition)
        {
            if (submition == null)
            {
                throw new ArgumentNullException("submition to add cannot be null");
            }

            this.submitions.Add(submition);
            this.submitions.SaveChanges();
        }

        public void SendSubmition(User user, Problem problem, string source, ContestLaungagesTypes laungage)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user cannot be null");
            }
            else if (problem == null)
            {
                throw new ArgumentNullException("problem cannot be null");
            }
            else if (source == null)
            {
                throw new ArgumentNullException("source cannot be null");
            }

            Submition submition = this.submitionFactory.Create();
            submition.Code = source;
            submition.Author = user;
            submition.Problem = problem;
            submition.TestCounts = problem.TestsCount;
            submition.Finished = false;
            submition.Author = user;
            submition.Problem = problem;

            this.Create(submition);

            string[] testCases = problem.Tests.Select(t => t.TestParameter).ToArray();

            this.userServices.AddProblemToUser(user.Id, problem);

            SubmitionModel model = this.codeTestingService.TestCode(source, laungage, testCases);

            if (string.IsNullOrEmpty(model.CompileMessage) == false)
            {
                submition.CompileMessage = model.CompileMessage;
                submition.CanCompile = false;
            }
            else
            {
                submition.CanCompile = true;

                for (int i = 0; i < model.StdOuts.Length; i++)
                {
                    TestCompleted completedTest = this.testCompletedFactory.Create();
                    completedTest.Error = model.Errors[i];
                    completedTest.Result = model.StdOuts[i];
                    completedTest.Memory = model.Memory[i];
                    completedTest.Time = model.Times[i];

                    submition.CompletedTests.Add(completedTest);
                }

                bool[] passingTests = this.passingTestsChecker.GetPassingTests(submition, problem);

                int index = 0;

                foreach (TestCompleted subTest in submition.CompletedTests)
                {
                    if (passingTests[index])
                    {
                        subTest.Correct = true;
                    }

                    index++;
                }
            }

            submition.Finished = true;

            this.submitions.SaveChanges();
        }
    }
}
