using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ErrandBoy.Data.Entities;
using FluentNHibernate.Conventions;
using FluentNHibernate.Mapping;

namespace ErrandBoy.Data.SqlServer.Mapping
{
    public abstract class VersionedClassMap<T> : ClassMap<T> where T : IVersionedEntity
    {

    }
}
