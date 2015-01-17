using System.Threading.Tasks;

namespace ErrandBoy.Data.QueryProcessors
{
    public interface IAddTaskQueryProcessor
    {
        void AddTask(Task task);
    }
}
