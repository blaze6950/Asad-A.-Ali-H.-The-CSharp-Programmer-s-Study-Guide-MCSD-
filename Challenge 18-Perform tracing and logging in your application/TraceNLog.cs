using System;
using System.Diagnostics;

namespace Challenge_18_Perform_tracing_and_logging_in_your_application
{
    public class TraceNLog : IDisposable
    {
        private TraceSource _traceSource;
        private EventLogTraceListener _eventLogTraceListener;

        string _sourceName = "Sample Log";
        string _logName = "Challenge 18 TraceNLog";
        string _machineName = ".";// . means local machine

        public TraceNLog()
        {
            //Creation of log
            if (!EventLog.SourceExists(_sourceName, _machineName))
            {
                EventLog.CreateEventSource(_sourceName, _logName);//EventLog created
            }
            //Specifing created log (target)
            EventLog log = new EventLog();
            log.Source = _sourceName;
            log.Log = _logName;
            log.MachineName = _machineName;

            _eventLogTraceListener = new EventLogTraceListener();
            //specify the target to listener
            _eventLogTraceListener.EventLog = log;


            _traceSource = new TraceSource("TraceSource", SourceLevels.All);
            _traceSource.Listeners.Clear();
            _traceSource.Listeners.Add(_eventLogTraceListener);
            Trace.Listeners.Clear();
            Trace.Listeners.Add(_eventLogTraceListener);

            TraceSource.TraceInformation("Successfully initialize TraceSource and EventLogTraceListener object..");
            TraceSource.Flush();//flush the buffers
        }

        public TraceSource TraceSource { get => _traceSource; }

        public void Dispose()
        {
            TraceSource.Flush();
            TraceSource?.Close();
            _eventLogTraceListener?.Dispose();
        }
    }
}