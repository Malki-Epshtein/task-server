using DAL.interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Task = DAL.Models.Task;


namespace DAL.Classes
{
    public class TaskDAL : ITaskDAL
    {
        StoreDbContext DB = new StoreDbContext();

        //1.1
        public List<Task> GetTasks()
        {
            return DB.Tasks.Include(v => v.PasswordKindNavigation).Include (V => V.TzUserNavigation).ToList();
        }

        //1.2

        public Task GetTasksById(int id)
        {
            Task task = DB.Tasks.Include(v => v.PasswordKindNavigation).Include(V => V.TzUserNavigation).FirstOrDefault(x => x.IdTask == id);
            return task;
        }

        //2
        public int Add(Task task)
        {
            DB.Tasks.Add(task);
            DB.SaveChanges();
            return task.IdTask;
        }

        //3
        public void Remove(int id)
        {
            Task task = DB.Tasks.FirstOrDefault(x => x.IdTask == id);
            DB.Tasks.Remove(task);
            DB.SaveChanges();
        }

        //4
        public void UpDate(Task task)
        {
            var taskk = DB.Tasks.FirstOrDefault(x => x.IdTask == task.IdTask);
            if (taskk != null) 
            {
                taskk.Discreption = task.Discreption;
                taskk.PasswordKind = task.PasswordKind;
                taskk.TzUser = task.TzUser;
                taskk.TColort = task.TColort;
                taskk.DataTask = task.DataTask;
                DB.SaveChanges();
            }
            else
            {
                throw new Exception("Task not found");
            }
        }


    }
}
