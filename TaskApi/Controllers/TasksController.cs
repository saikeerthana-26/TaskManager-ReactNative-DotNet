using Microsoft.AspNetCore.Mvc;

namespace TaskApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private static List<TaskItem> tasks = new()
        {
            new TaskItem { Id = 1, Title = "Build .NET API", IsDone = true }
        };

        [HttpGet]
        public IActionResult GetTasks() => Ok(tasks);

        [HttpPost]
        public IActionResult AddTask(TaskItem newTask)
        {
            newTask.Id = tasks.Count + 1;
            tasks.Add(newTask);
            return Ok(newTask);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTask(int id)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task == null) return NotFound();

            tasks.Remove(task);
            return NoContent();
        }
         [HttpPut("{id}")]
        public IActionResult ToggleTask(int id)
        {
          var task = tasks.FirstOrDefault(t => t.Id == id);
           if (task == null) return NotFound();

          task.IsDone = !task.IsDone; // flip true ↔ false
           return Ok(task);
        }


    }

    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsDone { get; set; }
    }
}
