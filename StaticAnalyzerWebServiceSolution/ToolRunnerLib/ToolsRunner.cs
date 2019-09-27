using IToolLib;
using System;
using System.Collections.Generic;
using System.Reflection;
using ToolDataLib;

/// <summary>
/// This library is made for running tools.
/// </summary>
namespace ToolRunnerLib
{
    /// <summary>
    /// This class have RunTools method which is used running all the tools
    /// </summary>
    public class ToolsRunner
    {
        public ITool Tool { get; set; }
        #region RunTools Method
        /// <summary>
        /// RunTools Method
        /// </summary>
        /// <param name="tools">tools information list</param>
        /// <param name="inputFile"> list of inputs provided</param>
        public void RunTools(List<ToolData> tools, List<string> inputFile)
        {
            if(tools.Count > 0 && inputFile.Count > 0)
            {
                int j = 0;
                foreach (var i in tools)
                {
                    Console.WriteLine(i.ToolDLLPath);
#pragma warning disable S3885 // "Assembly.Load" should be used
                    Assembly assembly = Assembly.LoadFrom(i.ToolDLLPath);
#pragma warning restore S3885 // "Assembly.Load" should be used
                    Tool = assembly.CreateInstance(i.ToolName) as ITool;
                    foreach (var input in inputFile)
                    {
                        if (i.ToolName.Equals("StyleCopToolLib.StyleCopTool") && input.Contains("cs"))
                        {
                            Tool.ExecuteTool(i.ToolExe, input, i.OutputDirectoryPath, (j + 1).ToString());
                        }
                        if(i.ToolName.Equals("FxCopToolLib.FxCopTool")&&input.Contains("exe"))
                        {
                            Tool.ExecuteTool(i.ToolExe, input, i.OutputDirectoryPath, (j + 1).ToString());
                        }
                        j++;
                    }

                    


                }
            }
            else
            {
              string message = "Argument should be valid";
              throw new ArgumentNullException(message);
            }
        }
        #endregion

    }
}
