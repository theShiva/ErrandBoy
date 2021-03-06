﻿using System.Net.Http;
using System.Web.Http;
using ErrandBoy.Web.Api.Models;
using ErrandBoy.Web.Common;

namespace ErrandBoy.Web.Api.Controllers.V2
{
    [RoutePrefix("api/{apiVersion:apiVersionConstraint(v2)}/tasks")]
    [UnitOfWorkActionFilter]
    public class TasksController : ApiController
    {
        [Route("", Name = "AddTaskRouteV2")]
        [HttpPost]
        public Task AddTask(HttpRequestMessage requestMessage, NewTaskV2 newTask)
        {
            return new Task()
            {
                Subject = "In v2 : newTask.Subject = " + newTask.Subject
            };
        }
    }
}
