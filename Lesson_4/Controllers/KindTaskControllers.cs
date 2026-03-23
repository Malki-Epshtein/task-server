using BLL.Interfaces;
using DAL.Models;
using DTO.ModelsDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lesson_4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KindTaskControllers : ControllerBase
    {
        IKindTaskBLL _IBll_KindTask;

        public KindTaskControllers(IKindTaskBLL iBll_KindTask) {

            _IBll_KindTask = iBll_KindTask;

        }

        //1.1
        [HttpGet("GetKindTasks")]
        public ActionResult<List<KindTaskDTO>> GetKindTasks()
        {
            return Ok(_IBll_KindTask.GetKindTasks());
        }

        //1.2
        [HttpGet("GetKindTasksById/{id}")]
        public ActionResult<KindTaskDTO> GetKindTasksById(int id)
        {
            return Ok(_IBll_KindTask.GetKindTasksById(id));
        }

        //2
        [HttpPost("Add")]
        public ActionResult<bool> Add(KindTaskDTO kindTask) {
            return Ok(_IBll_KindTask.Add(kindTask));
        }

        //3
        [HttpDelete("Remove/{id}")]
        public ActionResult<bool> Remove(int id)
        {
            return Ok(_IBll_KindTask.Remove(id));
        }

        //4
        [HttpPut("UpDate")]
        public ActionResult<bool> UpDate(KindTaskDTO kindTask)
        {
            try
            {
                return Ok(_IBll_KindTask.UpDate(kindTask));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
  
}
