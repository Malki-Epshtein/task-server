using DAL.Models;
using DTO.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserTask = DAL.Models.UserTask;

namespace BLL.Interfaces
{
    public interface IUserTaskBLL
    {
        //1.1
        public List<UserTaskDTO> GetUserTask();

        //1.2
        public UserTaskDTO GetUserTaskByID(string tz);

        //1.3

        public UserTaskDTO GetUserTaskByNameAndPassword(string NameUser, string PasswordUser);

        //2
        public bool Add(UserTaskDTO userTask);

        //3
        public bool Remove(string tzUser);

        //4
        public bool UpDate(UserTaskDTO userTask);
    }
}
