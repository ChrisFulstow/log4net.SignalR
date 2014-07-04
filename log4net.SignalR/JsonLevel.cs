#region Using directives

using log4net.Core;

#endregion


namespace log4net.SignalR
{
    public class JsonLevel
    {
        public JsonLevel(Level level)
        {
            DisplayName = level.DisplayName;
            Name = level.Name;
            Value = level.Value;
        }

        public JsonLevel()
        {
        }

        public string DisplayName { get; set; }

        public string Name { get; set; }

        public int Value { get; set; }
    }
}