using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using ErrandBoy.Common.TypeMapping;
using ErrandBoy.Data.Entities;

namespace ErrandBoy.Web.Api.AutoMappingConfiguration
{
    public class TaskEntityToTaskAutoMapperTypeConfigurator : IAutoMapperTypeConfigurator
    {
        public void Configure()
        {
            Mapper.CreateMap<Task, ErrandBoy.Web.Api.Models.Task>()
                .ForMember(opt => opt.Links, x => x.Ignore())
                .ForMember(opt => opt.Assignees, x => x.ResolveUsing<TaskAssigneesResolver>());
        }
    }
}