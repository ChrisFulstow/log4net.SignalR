using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace log4net.SignalR
{
    public class JsonLevel
    {
        public JsonLevel(Core.Level level)
        {
            this.DisplayName = level.DisplayName;
            this.Name = level.Name;
            this.Value = level.Value;
        }

        public JsonLevel()
        {
        }

        public string DisplayName { get; set; }

        public string Name { get; set; }

        public int Value { get; set; }
    }
}
