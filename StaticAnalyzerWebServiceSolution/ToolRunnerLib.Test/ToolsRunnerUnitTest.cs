using System;
using System.Collections.Generic;
using IToolLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToolDataLib;

namespace ToolRunnerLib.Test
{
    [TestClass]
    public class ToolsRunnerUnitTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Given_NullListInputs_When_RunToolsInvoked_Exptected_Exception()
        {
            ToolsRunner toolsRunner = new ToolsRunner();
            List<ToolData> tools = new List<ToolData>();
            List<string> inputs = new List<string>();
            toolsRunner.RunTools(tools,inputs);
        }
        [TestMethod]
        public void Given_Parameters_When_RunToolsInvoked_Then_Expected_To_Call_ExecuteTool_Method_Zero()
        {
            Moq.Mock<ITool> _moq = new Moq.Mock<ITool>();

            //class under test
            ToolsRunner toolsRunner = new ToolsRunner();

            //set Depedency
            ITool cranckEngine = _moq.Object;
            toolsRunner.Tool = cranckEngine;

            //Behaviour
            List<ToolData> tools = new List<ToolData>();
            tools.Add(new ToolData("C:\\Users\\320052122\\Downloads\\stylecopcli_1.4.0.0_bin (1)\\StyleCopCLI.exe"
                , "..\\..\\..\\GeneratedFiles",
                "StyleCopToolLib.StyleCopTool", 
                "..\\..\\..\\StyleCopToolLib\\bin\\Debug\\StyleCopToolLib.dll"
                ));

            List<string> inputs = new List<string>();
            inputs.Add("C:\\Users\\320068391\\source\\repos\\StaticAnalysisTool\\StaticAnalysisTool\\Program.cs");

            toolsRunner.RunTools(tools, inputs);

            //Expectation
            _moq.Verify(neighbour => neighbour.ExecuteTool(tools[0].ToolExe, inputs[0], 
                tools[0].OutputDirectoryPath, "1"), Moq.Times.Exactly(0));
            
        }


    }
}
