using System.Diagnostics;
using SignalR.Hubs;

namespace log4net.SignalR
{
    public class SignalrAppenderHub : Hub
    {
        public SignalrAppenderHub()
        {
            var signalrAppender = SignalrAppender.Instance;
            signalrAppender.MessageLoggedEvent += OnMessageLoggedEvent;
        }

        public void Listen()
        {
        }

        private void OnMessageLoggedEvent(object sender, MessageLoggedEventArgs e)
        {
            var logEventObject = new
            {
                e.LoggingEvent.Domain,
                e.LoggingEvent.ExceptionObject,
                e.LoggingEvent.Identity,
                e.LoggingEvent.Level,
                e.LoggingEvent.LocationInformation,
                e.LoggingEvent.LoggerName,
                e.LoggingEvent.MessageObject,
                e.LoggingEvent.Properties,
                e.LoggingEvent.RenderedMessage,
                e.LoggingEvent.ThreadName,
                TimeStamp = e.LoggingEvent.TimeStamp.ToString("yyyy-MM-dd HH:mm:ss.fff"),
                e.LoggingEvent.UserName
            };

            Clients.onLoggedEvent(e.FormattedEvent, logEventObject);
        }
    }
}