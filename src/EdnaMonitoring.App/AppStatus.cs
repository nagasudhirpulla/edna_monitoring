using System;
using System.Collections.Generic;
using System.Text;

namespace EdnaMonitoring.App
{
    public class AppStatus
    {
        public DateTime LastIctsUpdated { get; set; } = new DateTime();
        public DateTime LastTransLinesUpdated { get; set; } = new DateTime();
    }
}
