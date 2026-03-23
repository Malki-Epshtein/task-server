using DAL.interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserTask = DAL.Models.UserTask;

namespace DAL.Classes
{
    public class UserTaskDAL : IUserTaskDAL
    {
       
        StoreDbContext DB = new StoreDbContext();

        //1.1
        public List<UserTask> GetUserTask()
        {
            return DB.UserTasks.ToList();
        }

        //1.2
        public UserTask GetUserTaskById(string tz)
        {
            UserTask userTask = DB.UserTasks.FirstOrDefault( x => x.TzUser.Equals(tz));
            return userTask;

        }

        //2
        public void Add(UserTask userTask)
        {
            DB.UserTasks.Add(userTask);
            DB.SaveChanges();
        }

        //3
        public void Remove(string tzUser)
        {

            UserTask userTask = DB.UserTasks.FirstOrDefault(x => x.TzUser.Equals(tzUser));
            DB.UserTasks.Remove(userTask);
            DB.SaveChanges(); 
      }

        //4
        public void UpDate(UserTask userTask)
        {
            UserTask userTaskK = DB.UserTasks.FirstOrDefault(x => x.TzUser.Equals(userTask.TzUser));
            if (userTaskK != null)
            {
                userTaskK.TzUser = userTask.TzUser;
                userTaskK.NameUser = userTask.NameUser;
                userTaskK.PasswordUser = userTask.PasswordUser;
                DB.SaveChanges();
            }
            else
            {
                throw new Exception("UserTask not found");
            }
        }

      
    }
}
