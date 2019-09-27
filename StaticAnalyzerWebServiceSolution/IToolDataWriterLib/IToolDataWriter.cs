using System.Collections.Generic;

/// <summary>
/// It contains IToolDataWriter interface that is used for provinding defintion for any 
/// </summary>
namespace IToolDataWriterLib
{
    public interface IToolDataWriter
    {
        #region WriteMethod Definition
        /// <summary>
        /// This interfaces contains WriteMethod
        /// </summary>
        /// <typeparam name="ToolOutputDataFormat">Formate of returned data</typeparam>
        /// <param name="items">List of returned data</param>
        /// <param name="path">file location where to store the returned data</param>
        void Write<ToolOutputDataFormat>(IEnumerable<ToolOutputDataFormat> items, string path);
        #endregion

    }
}
