using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using ErrandBoy.Common.TypeMapping;

namespace ErrandBoy.Web.Api
{
    public class AutoMapperConfigurator
    {
        public void Configure(IEnumerable<IAutoMapperTypeConfigurator> autoMapperTypeConfigurations)
        {
            autoMapperTypeConfigurations.ToList().ForEach(x => x.Configure());
            Mapper.AssertConfigurationIsValid();
        }
    }
}