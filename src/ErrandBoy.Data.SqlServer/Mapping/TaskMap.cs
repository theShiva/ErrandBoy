using FluentNHibernate.Conventions.Inspections;
using Prefix = FluentNHibernate.Mapping.Prefix;
using Task = ErrandBoy.Data.Entities.Task;

namespace ErrandBoy.Data.SqlServer.Mapping
{
    public class TaskMap : VersionedClassMap<Task>
    {
        public TaskMap()
        {
            Id(x => x.TaskId);
            Map(x => x.Subject).Not.Nullable();
            Map(x => x.StartedOnDate).Nullable();
            Map(x => x.DueOnDate).Nullable();
            Map(x => x.CompletedOnDate).Nullable();
            Map(x => x.CreatedOnDate).Not.Nullable();
            References(x => x.CurrentStatus, "StatusId");
            References(x => x.CreatedBy, "CreatedUserId");
            
            HasManyToMany(x => x.Users)
            .Access.ReadOnlyPropertyThroughCamelCaseField(Prefix.Underscore)
            .Table("TaskUser")
            .ParentKeyColumn("TaskId")
            .ChildKeyColumn("UserId");            
        }
    }
}
