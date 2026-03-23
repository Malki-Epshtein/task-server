using AutoMapper;
using BLL.Interfaces;
using DAL.interfaces;
using DAL.Models;
using DTO;
using DTO.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Classes
{
    public class KindTaskBLL : IKindTaskBLL
    {
        IKindTaskDAL _IDal_KindTask;
        IMapper iMapper;

        public KindTaskBLL(IKindTaskDAL iDal_KindTask) {

            _IDal_KindTask = iDal_KindTask;

            var config = new MapperConfiguration(cfg => { cfg.AddProfile<MyProfile>(); });
            iMapper = config.CreateMapper();

        }

        //1.1
        public List<KindTaskDTO> GetKindTasks()
        {
            return iMapper.Map<List <KindTask> , List <KindTaskDTO> >(_IDal_KindTask.GetKindTasks());
        }

        //1.2
        public KindTaskDTO GetKindTasksById(int id)
        {
            try
            {
                KindTask kindTask = _IDal_KindTask.GetKindTasksById(id);
                return iMapper.Map<KindTask, KindTaskDTO>(kindTask);
            }
            catch
            {
                return null;
            }

        }

        //2
        public bool Add(KindTaskDTO kindTask)
        {
            try
            {
                KindTask k= iMapper.Map<KindTaskDTO, KindTask>(kindTask);
                _IDal_KindTask.Add(k);
                return true;
            }
            catch
            {
                return false;
            }
        }

      
        //3
        public bool Remove(int id)
        {
            try {
                _IDal_KindTask.Remove(id);
                return true;
            }
            catch{ 
                return false;
            }
           
        }

        //4
        public bool UpDate(KindTaskDTO kindTask)
        {
            try
            {
                KindTask k = iMapper.Map<KindTaskDTO, KindTask>(kindTask);
                _IDal_KindTask.UpDate(k);
                return true;
            }
            catch
            {
                throw;//להמשיך לעלות את השגיאה
            }
        }

       
    }
}
