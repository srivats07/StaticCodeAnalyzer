using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThresholdMetricsLib
{
    public class ThresholdMetrics
    {
        

        #region Constructor

        public ThresholdMetrics(int targetErrorCount,int targetWarningCount,int recievedErrorCount,int recievedWarningCount)
        {
            TargetErrorCount = targetErrorCount;
            TargetWarningCount = targetWarningCount;
            RecievedErrorCount = recievedErrorCount;
            RecievedWarningCount = recievedWarningCount;
        }

        #endregion

        public int TargetErrorCount { get; set; }

        public int TargetWarningCount { get; set; }

        public int RecievedErrorCount { get; set; }

        public int RecievedWarningCount { get; set; }
    }
}
