using DAL.interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Classes
{
    public class KindTaskDAL : IKindTaskDAL
    {
        StoreDbContext DB = new StoreDbContext();


        //1.1
        public List<KindTask> GetKindTasks()
        {
            return DB.KindTasks.ToList();
        }


        //1.2

        public KindTask GetKindTasksById(int id)
        {
            KindTask kindTask = DB.KindTasks.FirstOrDefault(x => x.PasswordKind == id);
            return kindTask;
        }

        //2
        public void Add(KindTask kindTask)
        {
             DB.KindTasks.Add(kindTask);
             DB.SaveChanges();
        }

        //3
        public void Remove(int id)
        {
            KindTask kindTask = DB.KindTasks.FirstOrDefault(x=>x.PasswordKind == id);
            DB.KindTasks.Remove(kindTask);
            DB.SaveChanges();
           
        }

        //4
        public void UpDate(KindTask kindTask)
        {
            KindTask kindTaskk = DB.KindTasks.FirstOrDefault(x => x.PasswordKind == kindTask.PasswordKind);
            if (kindTaskk != null)
            {
                kindTaskk.PasswordKind = kindTask.PasswordKind;
                kindTaskk.KindNameTask = kindTask.KindNameTask;
                kindTaskk.Tcolor = kindTask.Tcolor;
                DB.SaveChanges();
            }
            else
            {
                throw new Exception("Task kind not found");

            }
          

        }

       
    }
}
