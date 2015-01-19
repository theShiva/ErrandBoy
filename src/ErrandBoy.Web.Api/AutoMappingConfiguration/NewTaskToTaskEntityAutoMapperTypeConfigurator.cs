using AutoMapper;
using ErrandBoy.Common.TypeMapping;
using ErrandBoy.Web.Api.Models;
using Task = ErrandBoy.Data.Entities.Task;

namespace ErrandBoy.Web.Api.AutoMappingConfiguration
{
    public class NewTaskToTaskEntityAutoMapperTypeConfigurator : IAutoMapperTypeConfigurator
    {
        public void Configure()
        {
            Mapper.CreateMap<NewTask, Task>()
                .ForMember(opt => opt.Version, x => x.Ignore())
                .ForMember(opt => opt.CreatedBy, x => x.Ignore())
                .ForMember(opt => opt.TaskId, x => x.Ignore())
                .ForMember(opt => opt.CreatedOnDate, x => x.Ignore())
                .ForMember(opt => opt.CompletedOnDate, x => x.Ignore())
                .ForMember(opt => opt.CurrentStatus, x => x.Ignore())
                .ForMember(opt => opt.Users, x => x.Ignore());
        }
    }
}