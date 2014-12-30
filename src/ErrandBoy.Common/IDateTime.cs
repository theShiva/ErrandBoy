using System;

namespace ErrandBoy.Common
{
    interface IDateTime
    {
        DateTime UtcNow { get; }
    }
}
