using AutoMapper;
using DAL.Models;
using DTO.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = DAL.Models.Task;

namespace DTO
{
    public class MyProfile : Profile
    {
        public MyProfile()
        {
            CreateMap<KindTask, KindTaskDTO>();
            CreateMap<KindTaskDTO, KindTask>();
            CreateMap<Task, TaskDTO>().ForMember(x => x.KindNameTask, y => y.MapFrom(z => z.PasswordKindNavigation.KindNameTask))
                                      .ForMember(x => x.NameUser, y => y.MapFrom(z => z.TzUserNavigation.NameUser));
            CreateMap<TaskDTO, Task>();
            CreateMap<UserTask, UserTaskDTO>();
            CreateMap<UserTaskDTO, UserTask>();   
        }







    }

}
