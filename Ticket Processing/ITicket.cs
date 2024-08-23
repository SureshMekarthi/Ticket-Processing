using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticket_Processing
{
    interface ITicket
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
        public int Point { get; set; }
        public bool IsCompleted { get; set; }
        public string AssignedEmployee { get; set; }
    }
}
