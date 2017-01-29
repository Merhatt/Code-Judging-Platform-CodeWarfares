using CodeWarfares.Data.Models;
using CodeWarfares.Data.Services.Contracts.CodeTesting;
using CodeWarfares.Data.Services.Enums;
using CodeWarfares.Utils.Https;
using CodeWarfares.Utils.Json;
using CodeWarfares.Utils.JsonModels;
using System;
using System.Linq;

namespace CodeWarfares.Data.Services.CodeTesting
{
    public class CodeTestingServices : ICodeTestingServices
    {
        private const string ApiKey = "hackerrank|2120084-1183|9cb5e5e3e0c716149975b167a39e70bc8c3361e5";
        private const string ApiUrl = "http://api.hackerrank.com/checker/submission.json";

        private IHttpProvider httpProvider;
        private IJsonConverter jsonConverter;

        public CodeTestingServices(IHttpProvider httpProvider, IJsonConverter jsonConverter)
        {
            if (httpProvider == null)
            {
                throw new ArgumentNullException("Http provider canot be null");
            }

            if (jsonConverter == null)
            {
                throw new ArgumentNullException("Json converter canot be null");
            }

            this.httpProvider = httpProvider;
            this.jsonConverter = jsonConverter;
        }

        public SubmitionModel TestCode(string source, ContestLaungagesTypes laungage, string[] testCases)
        {
            if (source == null)
            {
                throw new ArgumentNullException("Source cannot be null");
            }

            if (testCases == null)
            {
                throw new ArgumentNullException("Test cases cannot be null");
            }

            string tests = "";

            for (int i = 0; i < testCases.Length; i++)
            {
                tests += "\"" + testCases[i] + "\"";

                if (i != testCases.Length - 1)
                {
                    tests += ",";
                }
            }

            string queryParameters = string.Format("source={0}&lang={1}&testcases=[{2}]&api_key={3}", source, (int)laungage, tests, ApiKey);

            string json = this.httpProvider.HttpPostJson(ApiUrl, queryParameters);

            ResponseModel model = this.jsonConverter.JsonToModel<ResponseModel>(json);

            return model.Model;
        }
    }
}
