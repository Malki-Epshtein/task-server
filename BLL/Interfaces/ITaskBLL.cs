using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Models;
using DTO.ModelsDTO;
using Task = DAL.Models.Task;

namespace BLL.Interfaces
{
    public interface ITaskBLL
    {
        //1.1
        public List<TaskDTO> GetTasks();

        //1.2
        public TaskDTO GetTaskById(int id);

        //2
        public int Add(TaskDTO task);

        //3
        public bool Remove(int id);

        //4
        public bool UpDate(TaskDTO task);
     
    }
}
