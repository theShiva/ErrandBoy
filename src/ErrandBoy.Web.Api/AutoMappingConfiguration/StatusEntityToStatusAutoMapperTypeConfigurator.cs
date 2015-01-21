using AutoMapper;
using ErrandBoy.Common.TypeMapping;
using ErrandBoy.Data.Entities;

namespace ErrandBoy.Web.Api.AutoMappingConfiguration
{
    public class StatusEntityToStatusAutoMapperTypeConfigurator : IAutoMapperTypeConfigurator
    {
        public void Configure()
        {
            Mapper.CreateMap<Status, Models.Status>();
        }
    }
}