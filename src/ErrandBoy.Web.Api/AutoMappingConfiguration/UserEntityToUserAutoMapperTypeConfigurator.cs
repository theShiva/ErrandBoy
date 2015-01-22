using AutoMapper;
using ErrandBoy.Common.TypeMapping;

namespace ErrandBoy.Web.Api.AutoMappingConfiguration
{
    public class UserEntityToUserAutoMapperTypeConfigurator : IAutoMapperTypeConfigurator
    {
        public void Configure()
        {
            Mapper.CreateMap<Data.Entities.User, Models.User>()
            .ForMember(opt => opt.Links, x => x.Ignore());
        }
    }
}