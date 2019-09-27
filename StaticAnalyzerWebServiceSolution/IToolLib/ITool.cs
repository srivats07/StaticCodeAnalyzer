/// <summary>
/// This contain ITool interface
/// on that every tools is being implemented
/// </summary>

namespace IToolLib
{
    public interface ITool
    {
        #region Execute Tool Method defintion
        /// <summary>
        /// Execute Tool Method defintion
        /// </summary>
        /// <param name="exePath"> Tool exe file path</param>
        /// <param name="inputFile">input file</param>
        /// <param name="outputDirectory">where you want to store output file </param>
        /// <param name="toolName"> name of the output file </param>
        void ExecuteTool(string exePath, string inputFile, string outputDirectory, string toolName);
        #endregion
    }
}
