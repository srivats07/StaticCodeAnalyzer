using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToolDataLib;

namespace ToolConfigurationLib.Test
{
    [TestClass]
    public class ToolConfigurationUnitTest
    {
        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void Given_File_When_ReadToolInfoInvoked_Exptected_FileNotFound()
        {
            ToolConfiguration toolConfiguration = new ToolConfiguration();
            toolConfiguration.ReadToolInfo("abc");
        }

        [TestMethod]
        public void Given_ValidFileWithTwoToolInfoEntry_When_ReadToolInfoInvoked_Exptected_ReturnedListSizeTwo()
        {
            ToolConfiguration toolConfiguration = new ToolConfiguration();
            List<ToolData> toolOutputs = toolConfiguration.ReadToolInfo(@"..\..\..\ToolConfigurationLib.Test\TestFiles\ToolsInfo.xml");
            int actualValue = toolOutputs.Count;
            int expectedValue = 2;
            Assert.AreEqual(actualValue, expectedValue);
        }
        [TestMethod]
        public void Given_ValidFile_When_ReadToolInfoInvoked_Exptected_EqualListValues()
        {

            ToolConfiguration toolConfiguration = new ToolConfiguration();
            List<ToolData> actualValue = toolConfiguration.ReadToolInfo(@"..\..\..\ToolConfigurationLib.Test\TestFiles\ToolsInfo.xml");
            List<ToolData> exptectedValue = new List<ToolData>();
            actualValue.Add(new ToolData("StyleCopToolLib.StyleCopTool",
             "..\\..\\..\\StyleCopToolLib\\bin\\Debug\\StyleCopToolLib.dll",
             @"C:\Users\320068391\Desktop\stylecopcli_1.4.0.0_bin (2)\StyleCopCLI.exe",
             "..\\..\\..\\GeneratedFiles"));
            actualValue.Add(new ToolData("FxCopToolLib.FxCopTool","..\\..\\..\\FxCopToolLib\\bin\\Debug\\FxCopToolLib.dll",
             @"C:\\Program Files (x86)\\Microsoft Visual Studio\\2019\Community\\Team Tools\\Static Analysis Tools\\FxCop\\FxCopCmd.exe",
             "..\\..\\..\\GeneratedFiles"));

            int k = 1;
            foreach (var i in actualValue)
            {
                foreach (var j in exptectedValue)
                {
                    if (i.ToolName != j.ToolName || i.ToolExe != j.ToolExe
                        || i.ToolDLLPath != j.ToolDLLPath || i.OutputDirectoryPath != j.OutputDirectoryPath)
                    {
                        k = 0;
                        break;
                    }

                }
            }

            Assert.AreEqual(1, k);
        }
    }
}
