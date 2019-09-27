using IToolDataWriterLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
/// <summary>
/// This library is for writer list of data to csv file.
/// </summary>

namespace ToolDataCsvWriterLib
{
    /// <summary>
    /// ToolDataCsvWriter class have write method which take the data from list and write the data into csv files.
    /// </summary>
    public class ToolDataCsvWriter : IToolDataWriter
    {
        #region
        /// <summary>
        /// Write method write list of data into csv file
        /// </summary>
        /// <typeparam name="ToolOutputDataFormat">format of list of data</typeparam>
        /// <param name="items">list of data</param>
        /// <param name="path">where to store the csv file</param>
        public void Write<ToolOutputDataFormat>(IEnumerable<ToolOutputDataFormat> items, string path)
        {
            Type itemType = typeof(ToolOutputDataFormat);
            var props = itemType.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                                .OrderBy(p => p.Name);
            Console.WriteLine(props);

            using (var writer = new StreamWriter(path))
            {
                writer.WriteLine(" ");
                writer.Close();
            }
            
            using (var writer = new StreamWriter(path,true))
            {
                
                writer.WriteLine(string.Join(", ", props.Select(p => p.Name)));
                
                foreach (var item in items)
                {
                    writer.WriteLine(string.Join(", ", props.Select(p => p.GetValue(item, null))));
                }
                writer.Close();
            }
        }
        #endregion
    }
}
