using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoAppBL.Models
{
    public class CredentialsBL
    {

        public int UserId { get; set; }
        public string UserEmail { get; set; } = null!;
        public string UserPass { get; set; } = null!;

    }
}
