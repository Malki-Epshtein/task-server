using BLL.Interfaces;
using DAL.Models;
using DTO.ModelsDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lesson_4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserTaskControllers : ControllerBase
    {
        IUserTaskBLL _IBll_UserTask;

        public UserTaskControllers(IUserTaskBLL iBll_UserTask)
        {
            _IBll_UserTask = iBll_UserTask;

        }

        //1.1
        [HttpGet("GetUserTask")]
        public ActionResult<List<UserTaskDTO>> GetUserTask()
        {

            return Ok(_IBll_UserTask.GetUserTask());
        }

        //1.2
        [HttpGet ("GetUserTaskByID/{tz}")]
        public ActionResult<UserTaskDTO> GetUserTaskByID(string tz)
        {

            return Ok(_IBll_UserTask.GetUserTaskByID(tz));
        }

        //1.2Ss
        [HttpGet("GetUserTaskByNameAndPassword/{nameUser}/{passwordUser}")]
        public ActionResult<UserTaskDTO> GetUserTaskByNameAndPassword(string nameUser , string passwordUser)
        {

            return Ok(_IBll_UserTask.GetUserTaskByNameAndPassword(nameUser, passwordUser));
        }

        //2
        [HttpPost("Add")]
        public ActionResult<bool> Add(UserTaskDTO userTask)
        {

            return Ok(_IBll_UserTask.Add( userTask));
        }


        //3
        [HttpDelete("Remove/{tzUser}")]
        public ActionResult Remove(string tzUser)
        {
            return Ok(_IBll_UserTask.Remove(tzUser));
        }

        //4
        [HttpPut("UpDate")]

        public ActionResult UpDate(UserTaskDTO userTask) 
        {
            try
            {
                return Ok(_IBll_UserTask.UpDate(userTask));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

           
        }

    }
}
