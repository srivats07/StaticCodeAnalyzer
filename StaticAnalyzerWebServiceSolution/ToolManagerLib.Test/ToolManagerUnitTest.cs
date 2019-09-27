using System;
using System.Collections.Generic;
using System.IO;
using IToolDataWriterLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToolOutputDataFormatLib;

namespace ToolManagerLib.Test
{
    [TestClass]
    public class ToolManagerUnitTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Given_NullInput_When_StartSessionInvoked_Exptected_ArgumentNullException()
        {
            ToolManager toolManager = new ToolManager();
            List<string> list = new List<string>();
            toolManager.StartSession(list);
        }
        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void When_ParseXMlFilesInvoked_Exptected_FileNotFoundException()
        {
            List<string> input=new List<string>();
            ToolManager toolManager = new ToolManager();
            toolManager.ParseXMlFiles(input);
        }
        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void When_EndSession_Invoked_Exptected_FileNotFoundException()
        {
            ToolManager toolManager = new ToolManager();
            toolManager.EndSession();
        }
        [TestMethod]
        public void Given_Parameters_When_EndSession_Invoked_Then_Expected_To_Call_Write_Method_Zero()
        {
            Moq.Mock<IToolDataWriter> _moq = new Moq.Mock<IToolDataWriter>();

            //class under test
            ToolManager toolManager = new ToolManager();

            //set Depedency
            IToolDataWriter cranckEngine = _moq.Object;
            toolManager.ToolDataCsvWriter = cranckEngine;

            _moq.Verify(neighbour => neighbour.Write(toolManager.ToolsOutputData, "..\\..\\..\\GeneratedFiles\\Output.csv"), Moq.Times.Exactly(0));

        }
    }
}
