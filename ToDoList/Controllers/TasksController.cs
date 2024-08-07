using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Data.Repositories;
using ToDoList.Model;
namespace ToDoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskRepository _taskRepository;


        public TasksController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTasks()
        {
            return Ok(await _taskRepository.GetAllTasks());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> getTask(int id)
        {
            return Ok(await _taskRepository.GetTasks(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody]Tasks task)
        {
            if (task == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var created = await _taskRepository.InsertTask(task);
            return Created("created", created);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateTask([FromBody] Tasks task)
        {
            if (task == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
             await _taskRepository.UpdateTask(task);
            return NoContent();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteTask(int id)
        {
            await _taskRepository.DeleteTask(new Tasks { Id=id });
            return NoContent();
        }

    }
}
