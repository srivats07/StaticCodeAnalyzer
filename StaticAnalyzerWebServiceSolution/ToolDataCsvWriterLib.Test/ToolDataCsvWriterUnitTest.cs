using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ToolDataCsvWriterLib.Test
{
    [TestClass]
    public class ToolDataCsvWriterUnitTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Given_InvalidFile_When_WriteInvoked_Exptected_Exception()
        {
            ToolDataCsvWriter toolDataCsvWriter = new ToolDataCsvWriter();
            toolDataCsvWriter.Write("","");
        }
    }
}
