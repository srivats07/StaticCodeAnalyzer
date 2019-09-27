using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToolOutputDataFormatLib;

namespace StyleCopDataParserLib.Test
{
    [TestClass]
    public class StyleCopDataParserUnitTest
    {
        [TestMethod][ExpectedException(typeof(FileNotFoundException))]
        public void Given_InvalidFilePath_When_ParseInvoked_Exptected_FileNotFoundException()
        {
            StyleCopDataParser styleCopDataParser = new StyleCopDataParser();
            styleCopDataParser.Parse("abc");
        }
        [TestMethod]
        public void Given_FileWithOneEntry_When_ParseInvoked_Exptected_ListOfOneEntry()
        {
            StyleCopDataParser styleCopDataParser = new StyleCopDataParser();
            List<ToolOutputDataFormat> actualValue = styleCopDataParser.Parse("..\\..\\..\\StyleCopDataParserLib.Test\\Xml_Files\\Test.xml");

            List<ToolOutputDataFormat> exptectedValue = new List<ToolOutputDataFormat>();
            exptectedValue.Add(new ToolOutputDataFormat("SA1600", "StyleCop", "ElementsMustBeDocumented",
            "StyleCop.CSharp.DocumentationRules", 
            "C:\\Users\\320068391\\source\\repos\\StaticAnalysisTool\\StaticAnalysisTool\\Program.cs", "16",
            "Root.StaticAnalysisTool.MainProgram.path1", "Warning",
            "The field must have a documentation header."));
       
            int t = 1;
            foreach (var a in actualValue)
            {
                foreach (var b in exptectedValue)
                {
                    if (a.description != b.description || a.level != b.level || a.linenumber != b.linenumber
                        || a.source != b.source || a.tool != b.tool || a.rule != b.rule || a.ruleId != b.ruleId
                        || a.rulenamespace != b.rulenamespace || a.section != b.section)
                    {
                        t = 0;
                        break;
                    }

                }
            }
         
            Assert.AreEqual(1, t);
        }
        [TestMethod]
        public void Given_ValidXmlFileWith10Enteries_When_ParseMethodReturned_Exptected_ListSizeOne()
        {
            StyleCopDataParser styleCopDataParser = new StyleCopDataParser();
            List<ToolOutputDataFormat> toolOutputs = styleCopDataParser.Parse(@"..\..\..\StyleCopDataParserLib.Test\\Xml_Files\\Test.xml");
            int actualValue = toolOutputs.Count;
            int expectedValue = 1;
            Assert.AreEqual(actualValue, expectedValue);
        }

    }
}
