using ErrandBoy.Web.Api.Models;
using Task = ErrandBoy.Web.Api.Models.Task;

namespace ErrandBoy.Web.Api.MaintenanceProcessing
{
    public interface IAddTaskMaintenanceProcessor
    {
        Task AddTask(NewTask newTask);
    }
}
