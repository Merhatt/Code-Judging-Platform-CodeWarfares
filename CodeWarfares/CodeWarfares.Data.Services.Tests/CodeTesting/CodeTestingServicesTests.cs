using CodeWarfares.Data.Services.CodeTesting;
using CodeWarfares.Data.Services.Enums;
using CodeWarfares.Utils.Https;
using CodeWarfares.Utils.Json;
using CodeWarfares.Utils.JsonModels;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWarfares.Data.Services.Tests.CodeTesting
{
    [TestFixture]
    public class CodeTestingServicesTests
    {
        [Test]
        public void Constructor_NullHttpProvider_ShouldThrow()
        {
            var jsonConverterMock = new Mock<IJsonConverter>();

            Assert.Throws<ArgumentNullException>(() => new CodeTestingServices(null, jsonConverterMock.Object));
        }

        [Test]
        public void Constructor_NullJsonConverter_ShouldThrow()
        {
            var httpProviderMock = new Mock<IHttpProvider>();

            Assert.Throws<ArgumentNullException>(() => new CodeTestingServices(httpProviderMock.Object, null));
        }

        [Test]
        public void TestCode_NullSource_ShouldThrow()
        {
            var jsonConverterMock = new Mock<IJsonConverter>();
            var httpProviderMock = new Mock<IHttpProvider>();

            var codeTestingService = new CodeTestingServices(httpProviderMock.Object, jsonConverterMock.Object);

            Assert.Throws<ArgumentNullException>(() => codeTestingService.TestCode(null, ContestLaungagesTypes.CSharp, new string[] { "asd" }));
        }

        [Test]
        public void TestCode_NullTestCases_ShouldThrow()
        {
            var jsonConverterMock = new Mock<IJsonConverter>();
            var httpProviderMock = new Mock<IHttpProvider>();

            var codeTestingService = new CodeTestingServices(httpProviderMock.Object, jsonConverterMock.Object);

            Assert.Throws<ArgumentNullException>(() => codeTestingService.TestCode("scriptz", ContestLaungagesTypes.CSharp, null));
        }

        [Test]
        public void TestCode_CorrectInput_ShouldReturnCorrectAnswer()
        {
            var jsonConverterMock = new Mock<IJsonConverter>();
            var httpProviderMock = new Mock<IHttpProvider>();

            ResponseModel model = new ResponseModel();

            model.Model = new SubmitionModel();

            jsonConverterMock.Setup(x => x.JsonToModel<ResponseModel>(It.IsAny<string>())).Returns(model);

            string json = "{json:true}";

            httpProviderMock.Setup(m => m.HttpPostJson(It.IsAny<string>(), It.IsAny<string>())).Returns(json);

            var codeTestingService = new CodeTestingServices(httpProviderMock.Object, jsonConverterMock.Object);

            string[] testCases = { "Hello", "World" };

            string apiKey = "hackerrank|2120084-1183|9cb5e5e3e0c716149975b167a39e70bc8c3361e5";
            string apiUrl = "http://api.hackerrank.com/checker/submission.json";
            string queryParameters = string.Format("source={0}&lang={1}&testcases=[\"Hello\",\"World\"]&api_key={2}", "throw new Lol())", (int)ContestLaungagesTypes.CSharp, apiKey);

            SubmitionModel res = codeTestingService.TestCode("throw new Lol())", ContestLaungagesTypes.CSharp, testCases);

            Assert.AreSame(model.Model, res);
            httpProviderMock.Verify(x => x.HttpPostJson(apiUrl, queryParameters), Times.Once());
            jsonConverterMock.Verify(x => x.JsonToModel<ResponseModel>(json), Times.Once());
        }
    }
}
