using DigitalCubicTask.API.DTO;
using DigitalCubicTask.API.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DigitalCubicTask.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController(ITaskService service) : ControllerBase
    {
        [HttpPost]
        public IActionResult CreateTask(TaskSaveDto task)
        {
            service.CreateTask(task);
            return Ok(new { Message = "Task created successfully" , Task = task });
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateTask(int id, [FromBody] TaskSaveDto task)
        {
            await service.UpdateTask(id , task);
            return Ok(new { Message = "Task updated successfully" , Task = task});
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTask(int id) {
            var task = await service.GetTask(id);
            if (task == null )
            {
                return NotFound(new { Message = "No tasks found" });
            }
            return Ok(new { Task = task });
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var tasks = await service.ListTasks();
            if (tasks == null)
            {
                return NotFound(new { Message = "No tasks found" });
            }
            return Ok(new { Taska = tasks });
        }

        [HttpPatch]
        [Route("{id}/complete")]
        public async Task<IActionResult> PatchTask(int id)
        {
            await service.MarkComplete(id);
            return Ok(new { Message = "Task Updated successfully" });
        }
    }
}
