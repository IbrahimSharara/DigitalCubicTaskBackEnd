using DigitalCubicTask.API.DTO;
using DigitalCubicTask.API.Entities;
using DigitalCubicTask.API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DigitalCubicTask.API.Service
{
    public class TaskService(ApplicationDBContext context) : ITaskService
    {
        public async Task<Int64> CreateTask(TaskSaveDto dto)
        {
            if (dto != null)
            {
                var task = new TaskItem
                {
                    title = dto.title,
                    description = dto.description,
                    assigned_user_id = dto.assigned_user_id,
                    startDate = dto.startDate,
                    endDate = dto.endDate,
                    isCompleted = false
                };
                await context.Tasks.AddAsync(task);

                var result =await  context.SaveChangesAsync();
                if (result > 0)
                {
                    return task.Id;
                }
                else
                {
                    throw new Exception("Failed to create task");
                }
            }
            return 0;
        }
        public async Task<TaskDto> GetTask(Int64 id)
        {
            var task = await context.Tasks.Include(x=>x.assigned_user_nav).FirstOrDefaultAsync(x => x.Id == id);
            if (task != null)
            {
                return new TaskDto
                {
                    assigned_user_id = task.assigned_user_id,
                    startDate = task.startDate,
                    endDate = task.endDate,
                    isCompleted = task.isCompleted,
                    title = task.title,
                    description = task.description,
                    assigned_user_Name = task.assigned_user_nav.UserName
                };
            }
            return default;
        }
        public async Task<List<TaskDto>> ListTasks()
        {
           var tasks =await  context.Tasks.Include(x=> x.assigned_user_nav).Select(t => 
               new TaskDto{
                   description = t.description,
                   endDate = t.endDate,
                   isCompleted = t.isCompleted,
                   startDate = t.startDate,
                   title = t.title,
                   assigned_user_id=t.assigned_user_id,
                   assigned_user_Name = t.assigned_user_nav.UserName
            }).AsNoTracking().ToListAsync();
            return tasks;
        }
        public async Task MarkComplete(Int64 id)
        {
            var task =await context.Tasks.FindAsync(id);
            if (task != null)
            {
                task.isCompleted = true;
                await context.SaveChangesAsync();
            }
        }
        public async Task UpdateTask(long id, TaskSaveDto dto)
        {
            try
            {
                var task = await context.Tasks.FindAsync(id);
                if (task != null)
                {
                    task.title = dto.title;
                    task.description = dto.description;
                    task.endDate = dto.endDate;
                    task.startDate = dto.startDate;
                    task.assigned_user_id = dto.assigned_user_id;
                    var resul = await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }
    }
}
