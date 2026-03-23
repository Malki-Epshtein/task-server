using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class UserTask
{
    public string TzUser { get; set; } = null!;

    public string? NameUser { get; set; }

    public string? PasswordUser { get; set; }

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
