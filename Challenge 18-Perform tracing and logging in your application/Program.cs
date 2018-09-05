namespace Challenge_18_Perform_tracing_and_logging_in_your_application
{
    class Program
    {
        // ReSharper disable once InconsistentNaming
        public static TraceNLog _traceNLog;

        static void Main()
        {
            using (_traceNLog = new TraceNLog())
            {
                _traceNLog.TraceSource.TraceInformation("Start executing code at main..");
                DevideAction.Devide(10);
            }
            _traceNLog.TraceSource.TraceInformation("Method main done all code and dispose resources");
        }
    }
}
