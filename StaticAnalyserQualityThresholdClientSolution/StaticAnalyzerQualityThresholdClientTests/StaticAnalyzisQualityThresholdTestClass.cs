using System;
using System.Collections.Generic;
using System.IO;
using CompareLib;
using CounterLib;
using CountRecievedErrorLib;
using CountRecievedWarningLib;
using CountTargetErrorLib;
using CountTargetWarningLib;
using CsvDataExtractorLib;
using DataExtractorLib;
using DataRemoveLib;
using GitCloneExecutorLib;
using GitCommandExecuteLib;
using InputRecieverLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using QualityThresholdListRecieverLib;
using SendInputLib;
using SendProjectInputLib;
using StaticAnalyserQualityThresholdConsoleClient;
using TemporaryDataRemoverLib;
using WebDataRecieverLib;
using ZipGitRepoLib;
using ZipOperationsLib;

namespace StaticAnalyzerQualityThresholdClientTests
{
    

    [TestClass]
    public class UnitTest1
    {
        
        private static Mock<IGitCommandExecute> _mockObjForExecuteUrl;
        private static Mock<IZip> _mockObjForZipOperation;
        private static Mock<ISendInput> _mockObjForSendOperation;
        private static Mock<ICompare> _mockObjCompareOperation;
        private static Mock<IDataRemove> _mockObjForCleanUpOperation;

        private static Helper _helper;
        private static IZip _zip;
        private static ICount _count;
        private static IDataExtract _dataExtract;
        private static IThresholdRecieve _thresholdRecieve;
        private static IDataRemove _dataRemove;
        private static ISendInput _sendInput;
        private static TestHelper _testHelper;
        
        

        private static List<string> _recievedThresholdList;
        private static List<string> _targetThresholdList;


        [AssemblyInitialize]
        public static void TestInitialize(TestContext testContext)
        {
            
            _mockObjForExecuteUrl = new Mock<IGitCommandExecute>();
            _mockObjForZipOperation=new Mock<IZip>();
            _mockObjForSendOperation=new Mock<ISendInput>();
            _mockObjCompareOperation=new Mock<ICompare>();
            _mockObjForCleanUpOperation=new Mock<IDataRemove>();
           
            _helper = new Helper();
            _zip=new ZipGitRepo();
            _dataExtract=new CsvDataExtractor();
            _thresholdRecieve=new QualityThresholdListRecieve();
            _dataRemove=new TemporaryDataRemover();
            _sendInput=new SendProjectPathAsInput();
            _testHelper=new TestHelper();

            
            _recievedThresholdList=new List<string>(){ "Error","Warning","Error","Warning"};
            _targetThresholdList=new List<string>(){ "error: 3", "Warning: 3" };
        }
        
        [TestMethod]
        public void GivenUrlWhenExecuteUrlCalledThenExecuteCalledExactlyOnce()
        {
            
            _helper.ExecuteUrl(_mockObjForExecuteUrl.Object,It.IsAny<string>());

            _mockObjForExecuteUrl.Verify(obj=>obj.Execute(It.IsAny<string>()), Times.Exactly(1));

        }

        [TestMethod]
        public void GivenPathWhenHelperFunctionCalledThenZipMethodCalledExactlyOnce()
        {
            _helper.PerformZipOperation(_mockObjForZipOperation.Object, It.IsAny<ISendInput>(), It.IsAny<string>(), It.IsAny<string>());

            _mockObjForZipOperation.Verify(obj=>obj.Zip(It.IsAny<string>()),Times.Exactly(1));
        }

        [TestMethod]
        public void GivenPathWhenZipFunctionCalledThenZipMethodReturnsNotNull()
        {
            
            
            string actual=_zip.Zip("lib");
            Assert.AreNotEqual(null,actual);
        }

        [TestMethod]
        public void GivenZipPathWhenSendInputCalledThenSendMethodCalledExactlyOnce()
        {
            _helper.PerformSendOperation(_mockObjForSendOperation.Object,It.IsAny<string>());

            _mockObjForSendOperation.Verify(obj=>obj.Send(It.IsAny<string>()),Times.Exactly(1));
        }

        [TestMethod]
        public void GivenThresholdListsWhenPerformCompareMethodCalledThenCompareMethodCalledExactlyOnce()
        {
            _helper.PerformComparisonAndCleanUp(new TestHelper.FakeGetThresholdListStub(), new TestHelper.FakeExtractDataStub(), _mockObjCompareOperation.Object,new TestHelper.FakeRemoveStub(), It.IsAny<string>(),It.IsAny<string>(), It.IsAny<string>());

            _mockObjCompareOperation.Verify(obj=>obj.Compare(It.IsAny<List<string>>(), It.IsAny<List<string>>()),Times.Exactly(1));
        }

        [TestMethod]
        public void GivenListOfThresholdsWhenCountRecievedErrorInvokedThenAssertToSuccess()
        { 
          _count=new CountRecievedError();
          
          Assert.AreEqual(2,_count.Get(_recievedThresholdList));
        }

        [TestMethod]
        public void GivenListOfThresholdsWhenCountRecievedWarningsInvokedThenAssertToSuccess()
        {
            _count = new CountRecievedWarning();

            Assert.AreEqual(2,_count.Get(_recievedThresholdList));
        }

        [TestMethod]
        public void GivenListOfThresholdsWhenCountTargetWarningsInvokedThenAssertToSuccess()
        {
            _count = new CountTargetWarning();

            Assert.AreEqual(3,_count.Get(_targetThresholdList));
        }

        [TestMethod]
        public void GivenListOfThresholdsWhenCountTargetErrorsInvokedThenAssertToSuccess()
        {
            _count = new CountTargetError();

            Assert.AreEqual(3,_count.Get(_targetThresholdList));
        }

        [TestMethod]
        public void GivenTemporaryFilesWhenPerformCleanUpMethodCalledThenCleanUpMethodCalledExactlyOnce()
        {
            _helper.PerformComparisonAndCleanUp(new TestHelper.FakeGetThresholdListStub(), new TestHelper.FakeExtractDataStub(), new TestHelper.FakeCompareStub(), _mockObjForCleanUpOperation.Object, It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>());

            _mockObjForCleanUpOperation.Verify(obj=>obj.Remove(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()),Times.Exactly(1));
        }
        

        [TestMethod]
        [ExpectedException(typeof(DirectoryNotFoundException))]
        public void GivenRandomPathWhenQualityThresholdListRecieveInvokedThenDirectoryNotFoundException()
        {
            _thresholdRecieve.getThresholdList("testPath");
        }

        [TestMethod]
        [ExpectedException(typeof(TypeInitializationException))]
        public void GivenRandomPathWhenDataRemoverInvokedThenTypeInitializationException()
        {
            _dataRemove.Remove("path1","path2","path3");
           
        }
        [TestMethod]
        [ExpectedException(typeof(AggregateException))]
        public void GivenRandomPathWhenSendInvokedThenAggregateException()
        {
            _sendInput.Send("testPath");

        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void GivenRandomPathWhenCsvDataExtractorInvokedThenFileNotFoundException()
        {
            _dataExtract.ExtractData("TestPath");
        }

        
    }
}
