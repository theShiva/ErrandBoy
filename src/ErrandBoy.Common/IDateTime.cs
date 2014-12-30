using System;

namespace ErrandBoy.Common
{
    public interface IDateTime
    {
        DateTime UtcNow { get; }
    }
}
