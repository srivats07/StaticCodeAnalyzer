using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToolParserInfoFormatLib;

namespace ToolParserConfigurationLib.Test
{
    [TestClass]
    public class ToolParserConfigurationUnitTest
    {
        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void Given_InvalidFile_When_ReadToolParserInfoInvoked_Exptected_FileNotFoundException()
        {
            ToolParserConfiguration toolConfiguration = new ToolParserConfiguration();
            toolConfiguration.ReadToolParserInfo("abc");
        }

        [TestMethod]
        public void Given_ValidFileWithTwoEntry_When_ReadToolParserInfoReturned_Exptected_ListSizeTwo()
        {
            ToolParserConfiguration toolConfiguration = new ToolParserConfiguration();
            List<ToolParserInfoFormat> toolOutputs = toolConfiguration.ReadToolParserInfo(@"..\..\..\ToolParserConfigurationLib.Test\TestFiles\ToolsXmlParserInfo.xml");
            int actualValue = toolOutputs.Count;
            int expectedValue = 2;
            Assert.AreEqual(actualValue, expectedValue);
        }
        [TestMethod]
        public void Given_ValidFileWithTwoEntries_When_ReadToolParserInfoReturned_Exptected_ListWithTwoEntries()
        {

            ToolParserConfiguration toolConfiguration = new ToolParserConfiguration();
            List<ToolParserInfoFormat> actualValue = toolConfiguration.ReadToolParserInfo(@"..\..\..\ToolParserConfigurationLib.Test\TestFiles\ToolsXmlParserInfo.xml");
            List<ToolParserInfoFormat> exptectedValue = new List<ToolParserInfoFormat>();
            actualValue.Add(new ToolParserInfoFormat("StyleCopDataParserLib.StyleCopDataParser",
             "..\\..\\..\\StyleCopDataParserLib\\bin\\Debug\\StyleCopDataParserLib.dll"));
            actualValue.Add(new ToolParserInfoFormat("FxCopDataParserLib.FxCopDataParser",
                "..\\..\\..\\FxCopDataParserLib\\bin\\Debug\\FxCopDataParserLib.dll"
             ));

            int k = 1;
            foreach (var i in actualValue)
            {
                foreach (var j in exptectedValue)
                {
                    if (i.DllPath != j.DllPath || i.Name != j.Name)
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
