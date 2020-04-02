using System;

namespace EdnaMonitoring.Domain.Entities
{
    public class TransLine : MonitoringEntity
    {
        public string Substation { get; set; }
        public int Voltage { get; set; }
    }
}
