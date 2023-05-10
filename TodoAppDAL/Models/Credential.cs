using System;
using System.Collections.Generic;

namespace TodoAppDAL.Models;

public partial class Credential
{
    public int CredentialsId { get; set; }

    public int UserId { get; set; }

    public string UserEmail { get; set; } = null!;

    public string UserPass { get; set; } = null!;

    public virtual Profile User { get; set; } = null!;
}
