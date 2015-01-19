using AutoMapper;
using ErrandBoy.Common.TypeMapping;
using ErrandBoy.Web.Api.Models;

namespace ErrandBoy.Web.Api.AutoMappingConfiguration
{
    public class UserToUserEntityAutoMapperTypeConfigurator : IAutoMapperTypeConfigurator
    {
        public void Configure()
        {
            Mapper.CreateMap<User, Data.Entities.User>()
                .ForMember(opt => opt.Version, x => x.Ignore());
        }
    }
}