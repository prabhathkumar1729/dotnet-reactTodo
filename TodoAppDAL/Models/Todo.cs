using System;
using System.Collections.Generic;

namespace TodoAppDAL.Models;

public partial class Todo
{
    public int TodoId { get; set; }

    public int UserId { get; set; }

    public string Task { get; set; } = null!;

    public DateTime? CreatedData { get; set; }

    public bool? IsCompleted { get; set; }

    public bool? IsTodoActive { get; set; }

    public virtual Profile User { get; set; } = null!;
}
