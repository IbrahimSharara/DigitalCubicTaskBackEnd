using DigitalCubicTask.API.DTO;

namespace DigitalCubicTask.API.Interfaces
{
    public interface ITaskService
    {
        Task<Int64> CreateTask(TaskSaveDto dto);
        Task<int> UpdateTask(Int64 id, TaskSaveDto dto);
        Task<List<TaskDto>> ListTasks();
        Task<TaskDto> GetTask(Int64 id);
        Task<int> MarkComplete(Int64 id);
    }
}
