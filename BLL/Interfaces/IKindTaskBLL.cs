using DAL.Models;
using DTO.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IKindTaskBLL
    {

        //1.1
        public List<KindTaskDTO> GetKindTasks();

        //1.2
        public KindTaskDTO GetKindTasksById(int id);

        //2
        public bool Add(KindTaskDTO kindTask);

        //3
        public bool Remove(int id);

        //4
        public bool UpDate(KindTaskDTO kindTask);
    }
}
