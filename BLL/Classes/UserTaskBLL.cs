using AutoMapper;
using BLL.Interfaces;
using DAL.interfaces;
using DAL.Models;
using DTO;
using DTO.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserTask = DAL.Models.UserTask;

namespace BLL.Classes
{
    public class UserTaskBLL : IUserTaskBLL
    {

        IUserTaskDAL _IDal_UserTask;
        IMapper iMapper;
        public UserTaskBLL(IUserTaskDAL iDal_UserTask) {

            _IDal_UserTask= iDal_UserTask;
            var config = new MapperConfiguration(cfg => { cfg.AddProfile<MyProfile>(); });
            iMapper = config.CreateMapper();
        }

        //1.1
        public List<UserTaskDTO> GetUserTask()
        {
            return iMapper.Map <List<UserTask>, List<UserTaskDTO>> (_IDal_UserTask.GetUserTask());

        }

        //1.2
        public UserTaskDTO GetUserTaskByID(string tz)
        {
            try
            {
                UserTask userTask = _IDal_UserTask.GetUserTaskById(tz);
                return iMapper.Map<UserTask, UserTaskDTO>(userTask);
            }
            catch
            {
                return null;
            }

        }

        //1.3

        public UserTaskDTO GetUserTaskByNameAndPassword(string NameUser ,string PasswordUser)
        {
            try
            {
                List<UserTask> listDb = _IDal_UserTask.GetUserTask();
                UserTask userTask = listDb.FirstOrDefault(x => x.NameUser.Equals(NameUser) && x.PasswordUser.Equals(PasswordUser));
                return iMapper.Map<UserTask, UserTaskDTO>(userTask);
            }
            catch  {
                return null;
            }

        }



        //2
        public bool Add(UserTaskDTO userTask)
        {
            try
            {
                UserTask u = iMapper.Map<UserTaskDTO, UserTask>(userTask);
                _IDal_UserTask.Add(u);
                return true;
            }
            catch
            {
                return false;
            }
        }

       
        //3
        public bool Remove(string tzUser)
        {
            try
            {
                _IDal_UserTask.Remove(tzUser);
                return true;
            }
            catch
            {
                return false;
            }
        }

        //4
        public bool UpDate(UserTaskDTO userTask)
        {
            try
            {
                UserTask u = iMapper.Map<UserTaskDTO, UserTask>(userTask);
                _IDal_UserTask.UpDate(u);
                return true;
            }
            catch(Exception ex)
            {
                throw;
            }
        }

       
    }
}
