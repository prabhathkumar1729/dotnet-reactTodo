using System;
using System.Collections.Generic;

namespace TodoAppDAL.Models;

public partial class Profile
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PhoneNo { get; set; } = null!;

    public bool? IsUserActive { get; set; }

    public virtual ICollection<Todo> Todos { get; } = new List<Todo>();
}
