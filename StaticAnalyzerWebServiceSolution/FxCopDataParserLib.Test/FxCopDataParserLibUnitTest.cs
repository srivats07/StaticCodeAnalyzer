using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToolOutputDataFormatLib;

namespace FxCopDataParserLib.Test
{
    [TestClass]
    public class FxCopDataParserLibUnitTest
    {
        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void Given_File_When_ParseInvoked_Exptected_FileNotFound()
        {
            FxCopDataParser fxCopDataParser = new FxCopDataParser();
            fxCopDataParser.Parse("abc");
        }
        [TestMethod]
        public void Given_ValidXmlFileWith10Enteries_When_ParseMethodReturned_Exptected_ListSize10()
        {
            FxCopDataParser fxCopDataParser = new FxCopDataParser();
            List<ToolOutputDataFormat> toolOutputs = fxCopDataParser.Parse("..\\..\\..\\FxCopDataParserLib.Test\\Test_XmlFiles\\Test.xml");
            int actualValue = toolOutputs.Count;
            int expectedValue = 10;
            Assert.AreEqual(actualValue, expectedValue);
        }


        [TestMethod]
        public void Given_FileWithOneEntry_When_ParseInvoked_Exptected_ListOfOneEntry()
        {
            FxCopDataParser fxCopDataParser = new FxCopDataParser();
            List<ToolOutputDataFormat> actualValue= fxCopDataParser.Parse("..\\..\\..\\FxCopDataParserLib.Test\\Test_XmlFiles\\Test1.xml");
            List<ToolOutputDataFormat> exptectedValue = new List<ToolOutputDataFormat>();
            exptectedValue.Add(new ToolOutputDataFormat("CA1014", "FxCop", "MarkAssembliesWithClsCompliant",
                "Microsoft.Design", "", "", "", "Error",
                "Mark 'ComputeLibrary.dll' with CLSCompliant(true) because it exposes externally visible types."));
            
            int k = 1;
            foreach (var i in actualValue)
            {
                foreach (var j in exptectedValue)
                {
                    if (i.description != j.description || i.level != j.level || i.linenumber != j.linenumber
                        || i.source != j.source || i.tool != j.tool || i.rule != j.rule || i.ruleId != j.ruleId
                        || i.rulenamespace != j.rulenamespace || i.section != j.section)
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
    