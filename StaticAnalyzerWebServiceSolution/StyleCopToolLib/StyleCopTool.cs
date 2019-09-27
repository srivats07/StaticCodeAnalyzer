using IToolLib;
using System;
using System.ComponentModel;
using System.Diagnostics;
/// <summary>
/// This Library is for generating xml files using stylecop tool
/// We need to parse the input file, the path of stylecop tool execution file.
/// </summary>

namespace StyleCopToolLib
{
    public class StyleCopTool : ITool
    {
        #region ExecuteToolMethod
        /// <summary>
        ///  The ExecuteTool method first preparing the argument and then calling the tool to generate the xml file
        /// </summary>
        /// <param name="exePath">This is Tool Execution file path</param>
        /// <param name="inputFile"> This is input file Path</param>
        /// <param name="outputDirectory">Where we want to store the generated files</param>
        /// <param name="toolName">filename</param>

        public void ExecuteTool(string exePath, string inputFile, string outputDirectory, string toolName)
        {

                string styleCopToolArgument = "";
                if (inputFile != "" && outputDirectory != "" && toolName !="")
                {
                styleCopToolArgument = "--sourceFiles " + inputFile + " --outputFile " + outputDirectory + "\\" + toolName + ".xml";
                }
                else
                {
                    string message = "Input to Stylecop is empty";
                    throw new ArgumentNullException(message);
                }

                ProcessStartInfo startStyleCopTool = new ProcessStartInfo();
                if (exePath != "")
                {
                startStyleCopTool.FileName = exePath;
                }
                else
                {
                    string message = "Input is empty";
                    throw new ArgumentNullException(message);
                }
                startStyleCopTool.Arguments = styleCopToolArgument;
                if(Process.Start(startStyleCopTool) == null)
                {
                    string message = "Argument to Stylecop is not Valid, Tool has not started";
                    throw new Win32Exception(message);
                }
            
        }
        #endregion
    }
}
