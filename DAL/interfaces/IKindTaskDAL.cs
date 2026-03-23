using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.interfaces
{
    public interface IKindTaskDAL
    {
        //1.1
        public List<KindTask> GetKindTasks();

        //1.2
        public KindTask GetKindTasksById(int id);

        //2
        public void Add(KindTask kindTask);

        //3
        public void Remove(int id);

        //4
        public void UpDate(KindTask kindTask);
    }
}
