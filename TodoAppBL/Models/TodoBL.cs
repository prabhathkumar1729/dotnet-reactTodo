using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoAppBL.Models
{
    public class TodoBL
    {
        public int TodoId { get; set; }

        public int UserId { get; set; }

        public string Task { get; set; } = null!;

        public DateTime? CreatedData { get; set; }

        public bool? IsCompleted { get; set; } = false;

    }
}
