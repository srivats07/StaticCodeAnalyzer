using System.Collections.Generic;
using ToolOutputDataFormatLib;

/// <summary>
/// It contains IToolParser interfaces on that every tools parser is being implemented.
/// </summary>
namespace IToolDataParserLib
{
    public interface IToolDataParser
    {
        #region ParseMethod definition
        /// <summary>
        /// ParseMethod definition
        /// </summary>
        /// <param name="filePath">file path</param>
        /// <returns>list of data </returns>
        List<ToolOutputDataFormat> Parse(string filePath);
        #endregion
    }
}
