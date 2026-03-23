using BLL.Interfaces;
using DTO.ModelsDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Task = DAL.Models.Task;

namespace Lesson_4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskControllers : ControllerBase
    {
        ITaskBLL _IBll_Task;

        public TaskControllers(ITaskBLL IBll_Task)
        {
            _IBll_Task = IBll_Task;
        }

        //1.1
        [HttpGet("GetTasks")]
        public ActionResult<List<TaskDTO>> GetTasks()
        {
            return Ok(_IBll_Task.GetTasks());
        }

        //1.2
        [HttpGet("GetTaskById/{id}")]
        public ActionResult<TaskDTO> GetTaskById(int id)
        {
            return Ok(_IBll_Task.GetTaskById(id));
        }



        //2
        [HttpPost("add")]
        public ActionResult<bool> Add( TaskDTO task)
        {
            try
            {
                return Ok(_IBll_Task.Add(task));
            }
            catch(Exception ex)//כדי שהשרת לא יפול
            {
               return BadRequest(ex.Message);
            }
           
        }

        //3
        [HttpDelete("Remove/{id}")]
        public ActionResult<bool> Remove(int id)
        {
            return Ok(_IBll_Task.Remove(id));
        }

        //4
        [HttpPut("UpDate")]
        public ActionResult<bool> UpDate(TaskDTO task)
        {
            try
            {
                return Ok(_IBll_Task.UpDate(task));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }
    }
}
