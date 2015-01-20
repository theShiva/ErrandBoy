using AutoMapper;
using ErrandBoy.Common.TypeMapping;
using ErrandBoy.Web.Api.Models;

namespace ErrandBoy.Web.Api.AutoMappingConfiguration
{
    public class StatusToStatusEntityAutoMapperTypeConfigurator : IAutoMapperTypeConfigurator
    {
        public void Configure()
        {
            Mapper.CreateMap<Status, Data.Entities.Status>()
            .ForMember(opt => opt.Version, x => x.Ignore());
        }
    }
}