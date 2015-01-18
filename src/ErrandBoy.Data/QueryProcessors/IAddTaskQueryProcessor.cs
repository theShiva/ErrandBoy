using ErrandBoy.Data.Entities;

namespace ErrandBoy.Data.QueryProcessors
{
    public interface IAddTaskQueryProcessor
    {
        void AddTask(Task task);
    }
}
