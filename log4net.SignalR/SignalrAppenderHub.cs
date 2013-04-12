using Microsoft.AspNet.SignalR;
using System;
using System.Diagnostics;

namespace log4net.SignalR
{
    public class SignalrAppenderHub : Hub
    {
        private const string Log4NetGroup = "Log4NetGroup";
        
        public SignalrAppenderHub()
        {
            SignalrAppender.LocalInstance.MessageLogged = OnMessageLogged;
        }

        public void Listen() 
        {
            Groups.Add(Context.ConnectionId, Log4NetGroup);         
        }

        public void OnMessageLogged(LogEntry e)
        {
            Clients.Group(Log4NetGroup).onLoggedEvent(e.FormattedEvent, e.LoggingEvent);
        }
    }
}