using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.ModelsDTO
{
    public class UserTaskDTO
    {
        public string TzUser { get; set; } = null!;

        public string? NameUser { get; set; }

        public string? PasswordUser { get; set; }
    }
}
