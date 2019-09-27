using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StyleCopToolLib.Test
{
    [TestClass]
    public class StyleCopToolUnitTest
    {
        [TestMethod][ExpectedException(typeof(ArgumentNullException))]
        public void Given_NullInputToTool_When_ExecuteToolInvoked_Exptected_Exception()
        {
            StyleCopTool styleCopTool = new StyleCopTool();
            styleCopTool.ExecuteTool("", "", "", "");
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Given_NullExePathWithOtherNotNullValues_When_ExecuteToolInvoked_Exptected_Exception()
        {
            StyleCopTool styleCopTool = new StyleCopTool();
            styleCopTool.ExecuteTool("", "abc", "abc", "abc");
        }
        [TestMethod]
        [ExpectedException(typeof(System.ComponentModel.Win32Exception))]
        public void Given_AllInvalidParmeters_When_ExecuteToolInvoked_Exptected_Exception()
        {
            StyleCopTool styleCopTool = new StyleCopTool();
            styleCopTool.ExecuteTool(@"abc", "abc", "abc", "abc");
        }

        [TestMethod][ExpectedException(typeof(System.ComponentModel.Win32Exception))]
        public void Given_InvalidExeParameter_When_ExecuteTool_Invoked_Exptected_Exception()
        {
            StyleCopTool styleCopTool = new StyleCopTool();
            styleCopTool.ExecuteTool(@"abc", @"..\..\..\StyleCopToolLib\StyleCopTool.cs", "..\\..\\..\\GeneratedFiles", "1");
        }

    }
}
