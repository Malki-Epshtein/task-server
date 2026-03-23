using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserTask = DAL.Models.UserTask;

namespace DAL.interfaces
{
    public interface IUserTaskDAL
    {
        //1.1
        public List<UserTask> GetUserTask();

        //1.2
        public UserTask GetUserTaskById(string tz);

        //2
        public void Add(UserTask userTask);

        //3
        public void Remove(string tzUser);

        //4
        public void UpDate(UserTask userTask);
    }
}
