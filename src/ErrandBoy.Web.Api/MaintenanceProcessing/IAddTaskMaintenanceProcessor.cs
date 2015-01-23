using ErrandBoy.Web.Api.Models;
using Task = System.Threading.Tasks.Task;

namespace ErrandBoy.Web.Api.MaintenanceProcessing
{
    public interface IAddTaskMaintenanceProcessor
    {
        Task AddTask(NewTask newTask);
    }
}
