using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class KindTask
{
    public int PasswordKind { get; set; }

    public string? KindNameTask { get; set; }

    public string? Tcolor { get; set; }

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
