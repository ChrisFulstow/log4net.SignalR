using System;
using log4net.Core;
using Microsoft.AspNet.SignalR.Client.Hubs;
using Microsoft.AspNet.SignalR.Client.Transports;

namespace log4net.SignalR
{
    public class SignalrAppender : Appender.AppenderSkeleton
    {
        private FixFlags _fixFlags = FixFlags.All;

        public Action<LogEntry> MessageLogged;

        public static SignalrAppender LocalInstance { get; private set; }

        private IHubProxy proxyConnection = null;

        private string _proxyUrl = "";
        public string ProxyUrl {
            get
            {
                return _proxyUrl;
            }
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

        public SignalrAppender()
        {

            LocalInstance = this;
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

            var logEntry = new LogEntry(formattedEvent, new JsonLoggingEventData(loggingEvent));

            if (proxyConnection != null)
            {
                ProxyOnMessageLogged(logEntry);
            } else if (MessageLogged != null)
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
            catch (Exception e){
                LogManager.GetLogger("").Warn("OnMessageLogged Failed:", e);
            }
        }
    }


    public class LogEntry
    {
        public string FormattedEvent { get; set; }
        public JsonLoggingEventData LoggingEvent { get; set; }

        public LogEntry(string formttedEvent, JsonLoggingEventData loggingEvent)
        {
            FormattedEvent = formttedEvent;
            LoggingEvent = loggingEvent;
        }
    }
}
