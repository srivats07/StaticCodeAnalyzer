using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace FxCopToolLib.Test
{
    [TestClass]
    public class FxCopToolUnitTest
    {
        [TestMethod][ExpectedException(typeof(ArgumentNullException))]
        public void Given_NullInputToTool_When_ExecuteToolInvoked_Exptected_Exception()
        {
            FxCopTool fxCopTool = new FxCopTool();
            fxCopTool.ExecuteTool("", "", "", "");
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Given_NullExePathWithOtherNotNullValues_When_ExecuteToolInvoked_Exptected_Exception()
        {
            FxCopTool fxCopTool = new FxCopTool();
            fxCopTool.ExecuteTool("","abc", "abc", "abc");
        }

        [TestMethod]
        [ExpectedException(typeof(System.ComponentModel.Win32Exception))]
        public void Given_ValidArgument_When_ExecuteTool_Invoked_ExptectedWin32Exception()
        {
            FxCopTool fxCopTool = new FxCopTool();
            fxCopTool.ExecuteTool("abc", @"..\..\..\StyleCopToolLib\StyleCopTool.cs", "..\\..\\..\\GeneratedFiles", "1");
        }

        [TestMethod]
        [ExpectedException(typeof(System.ComponentModel.Win32Exception))]
        public void Given_InvlaidParmeters_When_ExecuteToolInvoked_Exptected_Exception()
        {
            FxCopTool fxCopTool = new FxCopTool();
            fxCopTool.ExecuteTool(@"abc", "abc", "abc", "abc");
        }


    }
}
