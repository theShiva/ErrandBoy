using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using ErrandBoy.Common.TypeMapping;
using ErrandBoy.Data.Entities;
using ErrandBoy.Web.Common;
using User = ErrandBoy.Web.Api.Models.User;

namespace ErrandBoy.Web.Api.AutoMappingConfiguration
{
    public class TaskAssigneesResolver : ValueResolver<Task, List<User>>
    {
        public IAutoMapper AutoMapper
        {
            get { return WebContainerManager.Get<IAutoMapper>(); }
        }
        protected override List<User> ResolveCore(Task source)
        {
            return source.Users.Select(x => AutoMapper.Map<User>(x)).ToList();
        }
    }
}