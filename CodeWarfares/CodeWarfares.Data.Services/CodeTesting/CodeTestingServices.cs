using CodeWarfares.Data.Models;
using CodeWarfares.Data.Services.Contracts.CodeTesting;
using CodeWarfares.Data.Services.Enums;
using CodeWarfares.Utils.Https;
using CodeWarfares.Utils.Json;
using CodeWarfares.Utils.JsonModels;
using CodeWarfares.Utils.PassingTests;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeWarfares.Data.Services.CodeTesting
{
    public class CodeTestingServices : ICodeTestingServices
    {
        private const string ApiKey = "ad6cce356775b67e6ed8c9b1fae44027";
        private const string ApiUrl = "http://api.compilers.sphere-engine.com/api/v3/submissions";
        private const string ReciveResultUrl = "https://c3b70bc3.compilers.sphere-engine.com/api/v3/submissions/{0}?access_token={1}&withOutput=true&withStderr=true&withCmpinfo=true";

        private IHttpProvider httpProvider;
        private IJsonConverter jsonConverter;
        private IPassingTestsChecker passingTestChecker;

        public CodeTestingServices(IHttpProvider httpProvider, IJsonConverter jsonConverter, IPassingTestsChecker passingTestsChecker)
        {
            if (httpProvider == null)
            {
                throw new NullReferenceException("Http provider canot be null");
            }

            if (jsonConverter == null)
            {
                throw new NullReferenceException("Json converter canot be null");
            }

            if (passingTestsChecker == null)
            {
                throw new NullReferenceException("passingTestsChecker canot be null");
            }

            this.httpProvider = httpProvider;
            this.jsonConverter = jsonConverter;
            this.passingTestChecker = passingTestsChecker;
        }

        public string TestCode(string source, ContestLaungagesTypes laungage, string testCase)
        {
            if (source == null)
            {
                throw new NullReferenceException("Source cannot be null");
            }

            if (testCase == null)
            {
                throw new NullReferenceException("Test case cannot be null");
            }

            string queryParameters = string.Format("access_token={0}", ApiKey);

            var data = new Dictionary<string, string>();

            data.Add("language", ((int)laungage).ToString());
            data.Add("sourceCode", source);
            data.Add("input", testCase);

            string json = this.httpProvider.HttpPostJson(ApiUrl, queryParameters, data);

            ResponseModel model = this.jsonConverter.JsonToModel<ResponseModel>(json);

            return model.Id;
        }

        public bool GetAreAllTestsCompleted(Problem problem, Submition submition)
        {
            if (problem == null)
            {
                throw new NullReferenceException("problem cannot be null");
            }

            if (submition == null)
            {
                throw new NullReferenceException("submition cannot be null");
            }

            if (submition.Finished)
            {
                return true;
            }

            bool areAllTestsCompleted = true;

            int passingTestsCount = 0;

            foreach (var test in submition.CompletedTests)
            {
                if (test.Compiled)
                {
                    continue;
                }

                string json = this.httpProvider.HttpGetJson(string.Format(ReciveResultUrl, test.SendId, ApiKey));

                var model = this.jsonConverter.JsonToModel<SubmitionModel>(json);

                if (model.Status == 0)
                {
                    test.Compiled = true;

                    if (model.Result == 15)
                    {
                        test.Result = model.StdOut;
                        test.Memory = model.Memory;
                        test.IsCorrect = this.passingTestChecker.IsPassingTest(problem, test);
                        test.Compiled = true;

                        if (test.IsCorrect)
                        {
                            passingTestsCount++;
                        }

                        submition.CompileMessage = "Компилира се Успешно!";
                    }
                    else
                    {
                        submition.CompileMessage = model.Message;

                        if (string.IsNullOrEmpty(submition.CompileMessage))
                        {
                            submition.CompileMessage = "Грешка при компилация";
                        }
                    }
                }
                else
                {
                    submition.CompileMessage = "Компилира се";
                    areAllTestsCompleted = false;
                    break;
                }
            }

            if (areAllTestsCompleted)
            {
                submition.CompletedPercentage = (double)passingTestsCount / (double)problem.Tests.Count * 100;
            }

            return areAllTestsCompleted;
        }
    }
}
