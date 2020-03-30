namespace EdnaMonitoring.Domain.Entities
{
    public class MonitoringEntity : BaseEntity
    {
        public string Name { get; set; }
        public string EdnaId { get; set; }

        public int? AlertUpThresh { get; set; }
        public int? AlertDownThresh { get; set; }

        public int? DangerUpThresh { get; set; }
        public int? DangerDownThresh { get; set; }

        public int? ReasonabilityUpThresh { get; set; }
        public int? ReasonabilityDownThresh { get; set; }
    }
}
