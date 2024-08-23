using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticket_Processing
{
    public class Ticket : ITicket
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
        public int Point { get; set; }
        public bool IsCompleted { get; set; }
        public string AssignedEmployee { get; set; }

        public Ticket(int id, string name, Category category, int point)
        {
            Id = id;
            Name = name;
            Category = category;
            Point = point;
            IsCompleted = false;
            AssignedEmployee = null;
        }
    }
}
