/// <summary>
/// This Librarary is utility library which is used for providing data format in storing output data.
/// </summary>
namespace ToolOutputDataFormatLib
{
    /// <summary>
    /// ToolOutputDataFormat have fields and contructuctor used to assigned them values.
    /// </summary>
    public class ToolOutputDataFormat
    {
        #region Data Fields
        /// <summary>
        /// Data Fields
        /// </summary>
        public string ruleId { get; set; }
        public string tool { get; set; }
        public string rule { get; set; }
        public string rulenamespace { get; set; }
        public string source { get; set; }
        public string linenumber { get; set; }
        public string section { get; set; }
        public string level { get; set; }
        public string description { get; set; }
        #endregion

        #region ToolOutputDataFormat 

        /// <summary>
        /// ToolOutputDataFormat is default contructor
        /// We make this private intensetionaly because nobody can use it without passing any parameter.
        /// </summary>

        private ToolOutputDataFormat()
        {

        }
        #endregion

        #region ToolOutputDataFormat Parameterized Constructor
        /// <summary>
        /// ToolOutputDataFormat is Parameterized Constructor that 
        /// is used for storing the output data 
        /// into corresponding fields.
        /// </summary>
        /// <param name="RuleId">This represents RuleId </param>
        /// <param name="Tool">output given by which Tool</param>
        /// <param name="Rule"> which rule is voilated</param>
        /// <param name="RuleNamespace">In which namespace it is being voilated</param>
        /// <param name="Source">Source location of voilation</param>
        /// <param name="Line_Number">Line number where voilation/error/warning occurs</param>
        /// <param name="Section">Section</param>
        /// <param name="Level">Level</param>
        /// <param name="Description">Suggestion and Description about voilation/error/warning </param>

        public ToolOutputDataFormat(string RuleId, string Tool, string Rule, string RuleNamespace, string Source, string Line_Number, string Section, string Level, string Description)
        {

            this.ruleId = RuleId;
            this.tool = Tool;
            this.rule = Rule;
            this.rulenamespace = RuleNamespace;
            this.source = Source;
            this.linenumber = Line_Number;
            this.section = Section;
            this.level = Level;
            this.description = Description;

        }
        #endregion


    }
}
