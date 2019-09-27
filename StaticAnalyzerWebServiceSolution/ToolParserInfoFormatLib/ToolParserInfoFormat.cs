/// <summary>
/// This library is used for providing data format to the information which is being provided from parsers xml.
/// </summary>

namespace ToolParserInfoFormatLib
{
    /// <summary>
    /// ToolParserInfoFormat class
    /// </summary>
    public class ToolParserInfoFormat
    {
        #region Data Fields
        /// <summary>
        /// Data Fields
        /// </summary>
        public string Name { get; set; }
        public string DllPath { get; set; }
        #endregion

        #region ToolParserInfoFormat parameterized contructor
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name">Parser Assembly Name</param>
        /// <param name="dllPath">Parser dll path</param>
        public ToolParserInfoFormat(string name, string dllPath)
        {
            Name = name;
            DllPath = dllPath;
        }
        #endregion
    }
}
