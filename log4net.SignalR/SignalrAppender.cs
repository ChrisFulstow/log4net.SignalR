#region Using directives

using System;
using log4net.Appender;
using log4net.Core;
using Microsoft.AspNet.SignalR.Client;

#endregion


namespace log4net.SignalR
{
    public class SignalrAppender : AppenderSkeleton
    {
        public Action<LogEntry> MessageLogged;
        private FixFlags _fixFlags = FixFlags.All;

        private string _proxyUrl = "";
        private IHubProxy proxyConnection;

        public SignalrAppender()
        {
            System.Diagnostics.Debug.WriteLine("Instantiating");
            LocalInstance = this;
        }

        public static SignalrAppender LocalInstance { get; private set; }

        public string ProxyUrl
        {
            get { return _proxyUrl; }
            set
            {
                if (value != "")
                {
                    HubConnection connection = new HubConnection(value);
                    proxyConnection = connection.CreateHubProxy("signalrAppenderHub");
                    connection.Start().Wait();
                }
                else
                {
                    proxyConnection = null;
                }
                _proxyUrl = value;
            }
        }

        public virtual FixFlags Fix
        {
            get { return _fixFlags; }
            set { _fixFlags = value; }
        }

        protected override void Append(LoggingEvent loggingEvent)
        {
            // LoggingEvent may be used beyond the lifetime of the Append()
            // so we must fix any volatile data in the event
            loggingEvent.Fix = Fix;

            var formattedEvent = RenderLoggingEvent(loggingEvent);

            var logEntry = new LogEntry(formattedEvent, new JsonLoggingEventData(loggingEvent));

            if (proxyConnection != null)
            {
                ProxyOnMessageLogged(logEntry);
            }
            else if (MessageLogged != null)
            {
                MessageLogged(logEntry);
            }
        }

        private void ProxyOnMessageLogged(LogEntry entry)
        {
            try
            {
                proxyConnection.Invoke("OnMessageLogged", entry);
            }
            catch (Exception e)
            {
                LogManager.GetLogger("").Warn("OnMessageLogged Failed:", e);
            }
        }
    }


    public class LogEntry
    {
        public LogEntry(string formttedEvent, JsonLoggingEventData loggingEvent)
        {
            FormattedEvent = formttedEvent;
            LoggingEvent = loggingEvent;
        }

        public string FormattedEvent { get; set; }
        public JsonLoggingEventData LoggingEvent { get; set; }
    }
}