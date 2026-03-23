using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Task
{
    public int IdTask { get; set; }

    public string? Discreption { get; set; }

    public int? PasswordKind { get; set; }

    public string? TzUser { get; set; }

    public string? TColort { get; set; }

    public DateOnly? DataTask { get; set; }

    public virtual KindTask? PasswordKindNavigation { get; set; }

    public virtual UserTask? TzUserNavigation { get; set; }
}
