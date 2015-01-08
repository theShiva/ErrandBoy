using System.Net.Http;
using System.Web.Http;
using ErrandBoy.Web.Api.Models;
using ErrandBoy.Web.Common;
using ErrandBoy.Web.Common.Routing;

namespace ErrandBoy.Web.Api.Controllers.V1
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>The [ApiVersion1RoutePrefix("tasks")] attribute is equivalent to saying [RoutePrefix("api/{apiVersion:apiVersionConstraint(v1)}/tasks")]
    /// </remarks>
    [ApiVersion1RoutePrefix("tasks")]
    [UnitOfWorkActionFilter]
    public class TasksController : ApiController
    {
        [Route("",Name = "AddTaskRoute")]
        [HttpPost]
        public Task AddTask(HttpRequestMessage requestMessage, NewTask newTask)
        {
            return new Task()
            {
                Subject = "In v1 : newTask.Subject = " + newTask.Subject
            };
        }
    }
}
