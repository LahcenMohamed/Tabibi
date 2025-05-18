namespace Tabibi.Core.Features.JobTimes.Queries.Get
{
    public sealed class JobTimeResponse
    {
        public Guid Id { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public DayOfWeek Day { get; set; }
    }
}
