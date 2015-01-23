﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ErrandBoy.Common.TypeMapping;
using ErrandBoy.Data.QueryProcessors;
using ErrandBoy.Web.Api.Models;
using Task = System.Threading.Tasks.Task;

namespace ErrandBoy.Web.Api.MaintenanceProcessing
{
    public class AddTaskMaintenanceProcessor : IAddTaskMaintenanceProcessor
    {
        private readonly IAutoMapper _autoMapper;
        private readonly IAddTaskQueryProcessor _queryProcessor;

        public AddTaskMaintenanceProcessor(IAddTaskQueryProcessor queryProcessor,
        IAutoMapper autoMapper)
        {
            _queryProcessor = queryProcessor;
            _autoMapper = autoMapper;
        }

        public Task AddTask(NewTask newTask)
        {
            var taskEntity = _autoMapper.Map<Data.Entities.Task>(newTask);

            _queryProcessor.AddTask(taskEntity);

            var task = _autoMapper.Map<Task>(taskEntity);

            return task;
        }
    }
}