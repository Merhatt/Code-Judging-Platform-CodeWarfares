using CodeWarfares.Data.Models;
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

        [Test]
        public void GetAreAllTestsCompleted_NullProblem_ShouldThrow()
        {
            var jsonConverterMock = new Mock<IJsonConverter>();
            var httpProviderMock = new Mock<IHttpProvider>();
            var passingTestCheckerMock = new Mock<IPassingTestsChecker>();

            var testingServices = new CodeTestingServices(httpProviderMock.Object, jsonConverterMock.Object, passingTestCheckerMock.Object);

            var err = Assert.Throws<NullReferenceException>(() => testingServices.GetAreAllTestsCompleted(null, new Submition()));

            Assert.AreEqual("problem cannot be null", err.Message);
        }

        [Test]
        public void GetAreAllTestsCompleted_NullSubmition_ShouldThrow()
        {
            var jsonConverterMock = new Mock<IJsonConverter>();
            var httpProviderMock = new Mock<IHttpProvider>();
            var passingTestCheckerMock = new Mock<IPassingTestsChecker>();

            var testingServices = new CodeTestingServices(httpProviderMock.Object, jsonConverterMock.Object, passingTestCheckerMock.Object);

            var err = Assert.Throws<NullReferenceException>(() => testingServices.GetAreAllTestsCompleted(new Problem(), null));

            Assert.AreEqual("submition cannot be null", err.Message);
        }

        [Test]
        public void GetAreAllTestsCompleted_SubmitionFinished()
        {
            var jsonConverterMock = new Mock<IJsonConverter>();
            var httpProviderMock = new Mock<IHttpProvider>();
            var passingTestCheckerMock = new Mock<IPassingTestsChecker>();

            var testingServices = new CodeTestingServices(httpProviderMock.Object, jsonConverterMock.Object, passingTestCheckerMock.Object);

            var problem = new Problem();
            var submition = new Submition();

            submition.Finished = true;

            bool res = testingServices.GetAreAllTestsCompleted(problem, submition);
            Assert.IsTrue(res);
        }

        [Test]
        public void GetAreAllTestsCompleted_Status0_Result15_TestCorrect_SubmitionFinishedFalse()
        {
            // Arrange
            var jsonConverterMock = new Mock<IJsonConverter>();
            var httpProviderMock = new Mock<IHttpProvider>();
            var passingTestCheckerMock = new Mock<IPassingTestsChecker>();

            var testingServices = new CodeTestingServices(httpProviderMock.Object, jsonConverterMock.Object, passingTestCheckerMock.Object);

            var problem = new Problem();
            var submition = new Submition();

            problem.Tests.Add(new Test());
            problem.Tests.Add(new Test());

            var completedTest = new TestCompleted();
            completedTest.Compiled = true;
            submition.CompletedTests.Add(completedTest);

            var completedTest2 = new TestCompleted();
            completedTest2.Compiled = false;
            completedTest2.SendId = "asdasd";
            submition.CompletedTests.Add(completedTest2);

            submition.Finished = false;

            string json = "it is json";

            httpProviderMock.Setup(x => x.HttpGetJson(It.IsAny<string>())).Returns(json);

            var model = new SubmitionModel();

            model.Status = 0;
            model.Result = 15;
            model.StdOut = "stdout";
            model.Memory = 100000;

            passingTestCheckerMock.Setup(x => x.IsPassingTest(It.IsAny<Problem>(), It.IsAny<TestCompleted>())).Returns(true);

            jsonConverterMock.Setup(x => x.JsonToModel<SubmitionModel>(It.IsAny<string>())).Returns(model);
            
            // Act
            bool res = testingServices.GetAreAllTestsCompleted(problem, submition);
            
            // Assert
            httpProviderMock.Verify(x => x.HttpGetJson("https://c3b70bc3.compilers.sphere-engine.com/api/v3/submissions/asdasd?access_token=ad6cce356775b67e6ed8c9b1fae44027&withOutput=true&withStderr=true&withCmpinfo=true"), Times.Once());
            jsonConverterMock.Verify(x => x.JsonToModel<SubmitionModel>(json), Times.Once());
            passingTestCheckerMock.Verify(x => x.IsPassingTest(problem, completedTest2), Times.Once());

            Assert.IsTrue(res);
            Assert.IsTrue(completedTest2.Compiled);
            Assert.AreEqual("Компилира се Успешно!", submition.CompileMessage);
            Assert.AreEqual(50, submition.CompletedPercentage);
        }

        [Test]
        public void GetAreAllTestsCompleted_Status0_Result10_TestCorrect_SubmitionFinishedFalse()
        {
            var jsonConverterMock = new Mock<IJsonConverter>();
            var httpProviderMock = new Mock<IHttpProvider>();
            var passingTestCheckerMock = new Mock<IPassingTestsChecker>();

            var testingServices = new CodeTestingServices(httpProviderMock.Object, jsonConverterMock.Object, passingTestCheckerMock.Object);

            var problem = new Problem();
            var submition = new Submition();

            problem.Tests.Add(new Test());
            problem.Tests.Add(new Test());

            var completedTest = new TestCompleted();
            completedTest.Compiled = true;
            submition.CompletedTests.Add(completedTest);

            var completedTest2 = new TestCompleted();
            completedTest2.Compiled = false;
            completedTest2.SendId = "asdasd";
            submition.CompletedTests.Add(completedTest2);

            submition.Finished = false;

            string json = "it is json";

            httpProviderMock.Setup(x => x.HttpGetJson(It.IsAny<string>())).Returns(json);

            var model = new SubmitionModel();

            model.Status = 0;
            model.Result = 10;
            model.StdOut = "stdout";
            model.Memory = 100000;

            passingTestCheckerMock.Setup(x => x.IsPassingTest(It.IsAny<Problem>(), It.IsAny<TestCompleted>())).Returns(true);

            jsonConverterMock.Setup(x => x.JsonToModel<SubmitionModel>(It.IsAny<string>())).Returns(model);

            bool res = testingServices.GetAreAllTestsCompleted(problem, submition);

            httpProviderMock.Verify(x => x.HttpGetJson("https://c3b70bc3.compilers.sphere-engine.com/api/v3/submissions/asdasd?access_token=ad6cce356775b67e6ed8c9b1fae44027&withOutput=true&withStderr=true&withCmpinfo=true"), Times.Once());
            jsonConverterMock.Verify(x => x.JsonToModel<SubmitionModel>(json), Times.Once());
            passingTestCheckerMock.Verify(x => x.IsPassingTest(problem, completedTest2), Times.Exactly(0));

            Assert.IsTrue(res);
            Assert.IsTrue(completedTest2.Compiled);
            Assert.AreEqual("Грешка при компилация", submition.CompileMessage);
            Assert.AreEqual(0, submition.CompletedPercentage);
        }

        [Test]
        public void GetAreAllTestsCompleted_Status1_TestCorrect_SubmitionFinishedFalse()
        {
            var jsonConverterMock = new Mock<IJsonConverter>();
            var httpProviderMock = new Mock<IHttpProvider>();
            var passingTestCheckerMock = new Mock<IPassingTestsChecker>();

            var testingServices = new CodeTestingServices(httpProviderMock.Object, jsonConverterMock.Object, passingTestCheckerMock.Object);

            var problem = new Problem();
            var submition = new Submition();

            problem.Tests.Add(new Test());
            problem.Tests.Add(new Test());

            var completedTest = new TestCompleted();
            completedTest.Compiled = true;
            submition.CompletedTests.Add(completedTest);

            var completedTest2 = new TestCompleted();
            completedTest2.Compiled = false;
            completedTest2.SendId = "asdasd";
            submition.CompletedTests.Add(completedTest2);

            submition.Finished = false;

            string json = "it is json";

            httpProviderMock.Setup(x => x.HttpGetJson(It.IsAny<string>())).Returns(json);

            var model = new SubmitionModel();

            model.Status = 1;
            model.Result = 10;
            model.StdOut = "stdout";
            model.Memory = 100000;

            passingTestCheckerMock.Setup(x => x.IsPassingTest(It.IsAny<Problem>(), It.IsAny<TestCompleted>())).Returns(true);

            jsonConverterMock.Setup(x => x.JsonToModel<SubmitionModel>(It.IsAny<string>())).Returns(model);

            bool res = testingServices.GetAreAllTestsCompleted(problem, submition);

            httpProviderMock.Verify(x => x.HttpGetJson("https://c3b70bc3.compilers.sphere-engine.com/api/v3/submissions/asdasd?access_token=ad6cce356775b67e6ed8c9b1fae44027&withOutput=true&withStderr=true&withCmpinfo=true"), Times.Once());
            jsonConverterMock.Verify(x => x.JsonToModel<SubmitionModel>(json), Times.Once());
            passingTestCheckerMock.Verify(x => x.IsPassingTest(problem, completedTest2), Times.Exactly(0));

            Assert.IsFalse(res);
            Assert.IsFalse(completedTest2.Compiled);
            Assert.AreEqual("Компилира се", submition.CompileMessage);
            Assert.AreEqual(0, submition.CompletedPercentage);
        }
    }
}
