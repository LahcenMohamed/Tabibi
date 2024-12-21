namespace Tabibi.Core.Features.JobTimes.Queries.Get
{
    public sealed class JobTimeResponse
    {
        public Guid Id { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public DayOfWeek Day { get; set; }
    }
}
