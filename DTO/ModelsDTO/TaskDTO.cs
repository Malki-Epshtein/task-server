using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.ModelsDTO
{
    public class TaskDTO
    {
        public int IdTask { get; set; }

        public string? Discreption { get; set; }

        public int? PasswordKind { get; set; }

        public string? KindNameTask { get; set; }
       
        public string? TzUser { get; set; }

        public string? NameUser { get; set; }

        public string? TColort { get; set; }

        public DateOnly? DataTask { get; set; }
    }
}
