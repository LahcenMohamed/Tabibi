namespace Tabibi.Domain.Shared.Entities
{
    public class JobTimeBase : FullAuditedEntity
    {
        public TimeOnly StartTime { get; protected set; }
        public TimeOnly EndTime { get; protected set; }
        public DayOfWeek Day { get; protected set; }
    }
}
