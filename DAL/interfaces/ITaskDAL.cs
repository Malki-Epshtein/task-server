using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Task = DAL.Models.Task;


namespace DAL.interfaces
{
    public interface ITaskDAL
    {
        //1.1
        public List<Task> GetTasks();

        //1.2
        public Task GetTasksById(int id);

        //2
        public int Add(Task task);

        //3
        public void Remove(int id);

        //4
        public void UpDate(Task task);
    }
}
