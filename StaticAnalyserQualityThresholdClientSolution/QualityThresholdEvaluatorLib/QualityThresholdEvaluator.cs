using CompareLib;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using ThresholdMetricsLib;
using CounterLib;
using CountRecievedErrorLib;
using CountRecievedWarningLib;
using CountTargetErrorLib;
using CountTargetWarningLib;
namespace QualityThresholdEvaluatorLib
{
    public class QualityThresholdEvaluator:ICompare
    {
        public void Compare(List<string> qualityThresholdList, List<string> csvThresholdList)
        {
            var thresholdMetrics = InitializeThresholdMetrics(qualityThresholdList, csvThresholdList);
            
            
            Console.WriteLine(thresholdMetrics.RecievedErrorCount > thresholdMetrics.TargetErrorCount? "Error metric mismatch:NO GO!!!":"No error metric mismatch:GO!!");
            Console.WriteLine(thresholdMetrics.TargetWarningCount < thresholdMetrics.RecievedWarningCount ? "Warning metric mismatch:NO GO!!!" : "No warning metric mismatch:GO!!");
        }

        private ThresholdMetrics InitializeThresholdMetrics(List<string> qualityThresholdList, List<string> csvThresholdList)
        {
            ThresholdMetrics thresholdMetrics = new ThresholdMetrics(0, 0, 0, 0);
            var recievedErrorCount = InitializeCounters(out var recievedWarningCount, out var targetErrorCount, out var targetWarningCount);

            thresholdMetrics.TargetErrorCount = targetErrorCount.Get(qualityThresholdList);
            thresholdMetrics.RecievedErrorCount = recievedErrorCount.Get(csvThresholdList);
            thresholdMetrics.TargetWarningCount = targetWarningCount.Get(qualityThresholdList);
            thresholdMetrics.RecievedWarningCount = recievedWarningCount.Get(csvThresholdList);
            return thresholdMetrics;
        }

        private static ICount InitializeCounters(out ICount recievedWarningCount, out ICount targetErrorCount,
            out ICount targetWarningCount)
        {
            ICount recievedErrorCount = new CountRecievedError();
            recievedWarningCount = new CountRecievedWarning();
            targetErrorCount = new CountTargetError();
            targetWarningCount = new CountTargetWarning();
            return recievedErrorCount;
        }
    }
}
