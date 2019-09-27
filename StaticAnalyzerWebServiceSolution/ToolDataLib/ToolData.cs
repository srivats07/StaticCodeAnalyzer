/// <summary>
/// This library provide formating for storing information regarding tools.
/// </summary>

namespace ToolDataLib
{
    /// <summary>
    /// Tooldata contains fields which store the formating data.
    /// </summary>
    public class ToolData
    {
        #region Data Fields
        /// <summary>
        /// Data Fields
        /// </summary>
        public string ToolExe { get; set; }
        public string OutputDirectoryPath { get; set; }
        public string ToolName { get; set; }
        public string ToolDLLPath { get; set; }
        #endregion

        #region Parameterized Constructor
        /// <summary>
        /// Assigning values to Data Fields
        /// </summary>
        /// <param name="toolExeFile">tool exe file location</param>
        /// <param name="outputFile">output directory</param>
        /// <param name="toolName">Name of the tool</param>
        /// <param name="toolDLLPath">where tool dll is located</param>
        public ToolData(string toolExeFile, string outputFile,string toolName, string toolDLLPath)
        {
            ToolExe = toolExeFile;
            OutputDirectoryPath = outputFile;
            ToolName = toolName;
            ToolDLLPath = toolDLLPath;
        }
        #endregion

    }
}
