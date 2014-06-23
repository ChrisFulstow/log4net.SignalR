#region Using directives

using log4net.Core;

#endregion


namespace log4net.SignalR
{
    public class JsonLocationInfo
    {
        public JsonLocationInfo()
        {
        }

        public JsonLocationInfo(LocationInfo locationInfo)
        {
            ClassName = locationInfo.ClassName;
            FileName = locationInfo.FileName;
            FullInfo = locationInfo.FullInfo;
            LineNumber = locationInfo.LineNumber;
            MethodName = locationInfo.MethodName;
            StackFrames = locationInfo.StackFrames;
        }

        public string ClassName { get; set; }

        public string FileName { get; set; }

        public string FullInfo { get; set; }

        public string LineNumber { get; set; }

        public string MethodName { get; set; }

        public StackFrameItem[] StackFrames { get; set; }
    }
}