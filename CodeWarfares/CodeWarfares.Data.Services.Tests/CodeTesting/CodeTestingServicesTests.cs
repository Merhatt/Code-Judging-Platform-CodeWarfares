using CodeWarfares.Data.Services.CodeTesting;
using CodeWarfares.Data.Services.Enums;
using CodeWarfares.Utils.Https;
using CodeWarfares.Utils.Json;
using CodeWarfares.Utils.JsonModels;
using CodeWarfares.Utils.PassingTests;
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
            var passingTestCheckerMock = new Mock<IPassingTestsChecker>();

            var ex = Assert.Throws<NullReferenceException>(() => new CodeTestingServices(null, jsonConverterMock.Object, passingTestCheckerMock.Object));

            Assert.AreEqual("Http provider canot be null", ex.Message);
        }

        [Test]
        public void Constructor_NullJsonConverter_ShouldThrow()
        {
            var httpProviderMock = new Mock<IHttpProvider>();
            var passingTestCheckerMock = new Mock<IPassingTestsChecker>();

            var ex = Assert.Throws<NullReferenceException>(() => new CodeTestingServices(httpProviderMock.Object, null, passingTestCheckerMock.Object));

            Assert.AreEqual("Json converter canot be null", ex.Message);
        }

        [Test]
        public void Constructor_NullPassingTestChecker_ShouldThrow()
        {
            var jsonConverterMock = new Mock<IJsonConverter>();
            var httpProviderMock = new Mock<IHttpProvider>();
            var passingTestCheckerMock = new Mock<IPassingTestsChecker>();

            var ex = Assert.Throws<NullReferenceException>(() => new CodeTestingServices(httpProviderMock.Object, jsonConverterMock.Object, null));

            Assert.AreEqual("passingTestsChecker canot be null", ex.Message);
        }

        [Test]
        public void TestCode_NullSource_ShouldThrow()
        {
            var jsonConverterMock = new Mock<IJsonConverter>();
            var httpProviderMock = new Mock<IHttpProvider>();
            var passingTestCheckerMock = new Mock<IPassingTestsChecker>();

            var codeTestingService = new CodeTestingServices(httpProviderMock.Object, jsonConverterMock.Object, passingTestCheckerMock.Object);

            var err = Assert.Throws<NullReferenceException>(() => codeTestingService.TestCode(null, ContestLaungagesTypes.CSharp, "asd"));

            Assert.AreEqual("Source cannot be null", err.Message);
        }

        [Test]
        public void TestCode_NullTestCases_ShouldThrow()
        {
            var jsonConverterMock = new Mock<IJsonConverter>();
            var httpProviderMock = new Mock<IHttpProvider>();
            var passingTestCheckerMock = new Mock<IPassingTestsChecker>();

            var codeTestingService = new CodeTestingServices(httpProviderMock.Object, jsonConverterMock.Object, passingTestCheckerMock.Object);

            var err = Assert.Throws<NullReferenceException>(() => codeTestingService.TestCode("scriptz", ContestLaungagesTypes.CSharp, null));

            Assert.AreEqual("Test case cannot be null", err.Message);
        }

        [Test]
        public void TestCode_CorrectInput_ShouldReturnCorrectAnswer()
        {
            var jsonConverterMock = new Mock<IJsonConverter>();
            var httpProviderMock = new Mock<IHttpProvider>();
            var passingTestCheckerMock = new Mock<IPassingTestsChecker>();

            var testingServices = new CodeTestingServices(httpProviderMock.Object, jsonConverterMock.Object, passingTestCheckerMock.Object);

            string json = "json";
            string source = "Hello World";
            string testCase = "Test";

            httpProviderMock.Setup(x => x.HttpPostJson(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<IDictionary<string, string>>())).Returns(json);

            var model = new ResponseModel();
            model.Id = "123512";

            jsonConverterMock.Setup(x => x.JsonToModel<ResponseModel>(It.IsAny<string>())).Returns(model);

            string resultId = testingServices.TestCode(source, ContestLaungagesTypes.CSharp, testCase);

            var data = new Dictionary<string, string>();

            data.Add("language", ((int)ContestLaungagesTypes.CSharp).ToString());
            data.Add("sourceCode", source);
            data.Add("input", testCase);

            Assert.AreEqual(model.Id, resultId);
            httpProviderMock.Verify(x => x.HttpPostJson("http://api.compilers.sphere-engine.com/api/v3/submissions", "access_token=ad6cce356775b67e6ed8c9b1fae44027", data), Times.Once());
            jsonConverterMock.Verify(x => x.JsonToModel<ResponseModel>(json), Times.Once());
        }
    }
}
