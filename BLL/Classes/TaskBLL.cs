using AutoMapper;
using BLL.Interfaces;
using DAL.Classes;
using DAL.interfaces;
using DAL.Models;
using DTO;
using DTO.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Task = DAL.Models.Task;


namespace BLL.Classes
{
    public class TaskBLL : ITaskBLL
    {
        ITaskDAL _IDal_Task;
        IMapper iMapper;
        public TaskBLL(ITaskDAL IDal_Task) {

            _IDal_Task = IDal_Task;
            var config = new MapperConfiguration(cfg => { cfg.AddProfile<MyProfile>(); });
            iMapper = config.CreateMapper();

        }

        //1.1
        public List<TaskDTO> GetTasks()
        {
            return iMapper.Map<List< Task> ,List<TaskDTO>> (_IDal_Task.GetTasks());
        }

        //1.2
        public TaskDTO GetTaskById(int id)
        {
            try
            {
                Task task = _IDal_Task.GetTasksById(id);
                return iMapper.Map<Task, TaskDTO>(task);
            }
            catch {
                return null;
            }


        }



        //2
        public int Add(TaskDTO task)
        {


            try
            {


                DateOnly dateOnly = task.DataTask.Value;
                DateOnly now = DateOnly.FromDateTime(DateTime.Now);
                if (dateOnly < now)
                    throw new Exception("the date not volid");

                Task t = iMapper.Map<TaskDTO, Task>(task);
           int idTaskReturn = _IDal_Task.Add(t);
            return idTaskReturn;
        }
            catch (Exception ex)
            {
                throw;
            }
        }

       
        //3
        public bool Remove(int id)
        {
            try
            {
                _IDal_Task.Remove(id);
                return true;
            }
            catch
            {
                return false;
            }
        }

        ///4
        public bool UpDate(TaskDTO task)
        {
            try
            {
                DateOnly dateOnly = task.DataTask.Value;
                DateOnly now = DateOnly.FromDateTime(DateTime.Now);
                if (dateOnly < now)
                    return false;

                Task t = iMapper.Map<TaskDTO, Task>(task);
                _IDal_Task.UpDate(t);
                return true;
            }
            catch(Exception ex)
            {
                throw;//להמשיך לעלות את השגיאה
            }
        }



    }
}
