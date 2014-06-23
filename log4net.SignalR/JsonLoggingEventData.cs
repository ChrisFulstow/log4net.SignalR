#region Using directives

using System;
using log4net.Core;
using log4net.Util;

#endregion


namespace log4net.SignalR
{
    public class JsonLoggingEventData
    {
        public JsonLoggingEventData()
        {
        }

        public JsonLoggingEventData(LoggingEvent loggingEvent)
        {
            LoggingEventData loggingEventData = loggingEvent.GetLoggingEventData();
            Domain = loggingEventData.Domain;
            ExceptionString = loggingEventData.ExceptionString;
            Identity = loggingEventData.Identity;
            Level = new JsonLevel(loggingEventData.Level);
            LocationInfo = new JsonLocationInfo(loggingEventData.LocationInfo);
            LoggerName = loggingEventData.LoggerName;
            Message = loggingEventData.Message;
            Properties = loggingEventData.Properties;
            ThreadName = loggingEventData.ThreadName;
            TimeStamp = loggingEventData.TimeStamp;
            UserName = loggingEventData.UserName;
        }

        public string Domain { get; set; }

        public string ExceptionString { get; set; }

        public string Identity { get; set; }

        public JsonLevel Level { get; set; }

        public JsonLocationInfo LocationInfo { get; set; }

        public string LoggerName { get; set; }

        public string Message { get; set; }

        public PropertiesDictionary Properties { get; set; }

        public string ThreadName { get; set; }

        public DateTime TimeStamp { get; set; }

        public string UserName { get; set; }
    }
}