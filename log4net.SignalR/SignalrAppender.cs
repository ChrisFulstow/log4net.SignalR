using System;
using log4net.Core;

namespace log4net.SignalR
{
    public class SignalrAppender : Appender.AppenderSkeleton
    {
        private FixFlags _fixFlags = FixFlags.All;

        public Action<LogEntry> MessageLogged;

        public static SignalrAppender Instance { get; private set; }

        public SignalrAppender()
        {
            Instance = this;
        }

        virtual public FixFlags Fix
        {
            get { return _fixFlags; }
            set { _fixFlags = value; }
        }

        override protected void Append(LoggingEvent loggingEvent)
        {
            // LoggingEvent may be used beyond the lifetime of the Append()
            // so we must fix any volatile data in the event
            loggingEvent.Fix = Fix;

            var formattedEvent = RenderLoggingEvent(loggingEvent);


            var handler = MessageLogged;
            if (handler != null)
            {
                handler(new LogEntry(formattedEvent, loggingEvent));
            }
        }
    }


    public class LogEntry
    {
        public string FormattedEvent { get; private set; }
        public LoggingEvent LoggingEvent { get; private set; }

        public LogEntry(string formttedEvent, LoggingEvent loggingEvent)
        {
            FormattedEvent = formttedEvent;
            LoggingEvent = loggingEvent;
        }
    }
}
