using System;
using log4net;

namespace ErrandBoy.Web.Api.Logging
{
    public interface ILogManager
    {
        ILog GetLog(Type typeAssociatedWithRequestedLog);
    }
}
