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
        public async Task<IActionResult> CreateTask(TaskSaveDto task)
        {
            var result = await service.CreateTask(task);
            if (result > 0)
            {
                return Ok(new { Message = "Task created successfully", Task = task });

            }
            return NoContent();
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateTask(int id, [FromBody] TaskSaveDto task)
        {
            var result = await service.UpdateTask(id, task);
            if (result >0)
            {
            return Ok(new { Message = "Task updated successfully", Task = task });
            }
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTask(int id)
        {
            var task = await service.GetTask(id);
            if (task == null)
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
            var result = await service.MarkComplete(id);
            if (result > 0)
            {
                return Ok(new { Message = "Task Updated successfully" });
            }
            return NoContent();
        }
    }
}
