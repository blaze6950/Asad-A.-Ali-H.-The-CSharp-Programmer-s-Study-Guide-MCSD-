using System;
using System.Diagnostics;

namespace Challenge_18_Perform_tracing_and_logging_in_your_application
{
    public static class DevideAction
    {
        public static int Devide(int numerator, int denominator = 0)
        {
            Program._traceNLog.TraceSource.TraceInformation($"Enter the static method \"Devide\" with parameters: numerator = {numerator}, denominator = {denominator}");
            int res = denominator;
            try
            {
                res =  numerator / denominator;
                Program._traceNLog.TraceSource.TraceInformation("DevideAction method successfully done devide...");
            }
            catch (Exception e)
            {
                Trace.Assert(false);
                // ReSharper disable once HeuristicUnreachableCode
                Trace.TraceError(e.Message);
            }
            Program._traceNLog.TraceSource.TraceInformation($"DevideAction method returning result value : {res}");
            return res;
        }
    }
}