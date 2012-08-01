using System;
using System.Diagnostics;
using SignalR.Hubs;

namespace log4net.SignalR
{
    public class SignalrAppenderHub : Hub
    {
        private const string Log4NetGroup = "Log4NetGroup";
        
        public SignalrAppenderHub()
        {
            SignalrAppender.Instance.MessageLogged = OnMessageLogged;
        }

        public void Listen() 
        {
            Groups.Add(Context.ConnectionId, Log4NetGroup);         
        }

        private void OnMessageLogged(LogEntry e)
        {
            Clients[Log4NetGroup].onLoggedEvent(e.FormattedEvent, e.LoggingEvent);
        }
    }
}