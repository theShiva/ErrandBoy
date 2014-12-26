﻿using System.Net.Http;
using System.Web.Http;
using ErrandBoy.Web.Api.Models;

namespace ErrandBoy.Web.Api.Controllers.V2
{
    [RoutePrefix("api/{apiVersion:apiVersionConstraint(v2)}/tasks")]
    public class TasksController : ApiController
    {
        [Route("", Name = "AddTaskRouteV2")]
        [HttpPost]
        public Task AddTask(HttpRequestMessage requestMessage, Task newTask)
        {
            return new Task()
            {
                Subject = "In v2 : newTask.Subject = " + newTask.Subject
            };
        }
    }
}
