using log4net.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            this.Domain = loggingEventData.Domain;
            this.ExceptionString = loggingEventData.ExceptionString;
            this.Identity = loggingEventData.Identity;
            this.Level = new JsonLevel(loggingEventData.Level);
            this.LocationInfo = new JsonLocationInfo(loggingEventData.LocationInfo);
            this.LoggerName = loggingEventData.LoggerName;
            this.Message = loggingEventData.Message;
            this.Properties = loggingEventData.Properties;
            this.ThreadName = loggingEventData.ThreadName;
            this.TimeStamp = loggingEventData.TimeStamp;
            this.UserName = loggingEventData.UserName;
        }

        public string Domain { get; set; }

        public string ExceptionString { get; set; }

        public string Identity { get; set; }

        public JsonLevel Level { get; set; }

        public JsonLocationInfo LocationInfo { get; set; }

        public string LoggerName { get; set; }

        public string Message { get; set; }

        public Util.PropertiesDictionary Properties { get; set; }

        public string ThreadName { get; set; }

        public DateTime TimeStamp { get; set; }

        public string UserName { get; set; }
    }
}
