using IToolLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// This Library is for generating xml files using Fxcop tool
/// We need to parse the input file, the path of Fxcop tool execution file.
/// </summary>

namespace FxCopToolLib
{
    public class FxCopTool : ITool
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

            string fxCopToolargument = "";
            if (inputFile != "" && outputDirectory != "" && toolName != "")
            {
                fxCopToolargument = "/f:" + inputFile + " /out:" + outputDirectory + "\\" + toolName + ".xml";
            }
            else
            {
                //string message = "Input to Fxcop is empty";
                //throw new ArgumentNullException(message);
                return;
            }

            ProcessStartInfo fxCopToolStart = new ProcessStartInfo();
            if (exePath != "")
            {
                fxCopToolStart.FileName = exePath;
            }
            else
            {
                string message = "Exe path of FxCop is empty";
                throw new ArgumentNullException(message);
            }
            fxCopToolStart.Arguments = fxCopToolargument;
            if (Process.Start(fxCopToolStart) == null)
            {
                string message = "Argument to FxCop is not Valid";
                throw new Win32Exception(message);
            }
        
        }
        #endregion
    }
}
