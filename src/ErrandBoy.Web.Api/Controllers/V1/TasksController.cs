using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ErrandBoy.Web.Common.Routing;

namespace ErrandBoy.Web.Api.Controllers.V1
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>The [ApiVersion1RoutePrefix("tasks")] attribute is equivalent to saying [RoutePrefix("api/{apiVersion:apiVersionConstraint(v1)}/tasks")]
    /// </remarks>
    [ApiVersion1RoutePrefix("tasks")]
    public class TasksController : ApiController
    {
    }
}
