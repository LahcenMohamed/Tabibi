﻿namespace Tabibi.Core.Wrapper
{
    public class PaginatedResquestBase
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; } = 0;
        public string? Search { get; set; }
    }
}
