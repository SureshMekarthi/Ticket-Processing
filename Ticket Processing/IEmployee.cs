using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticket_Processing
{
   interface IEmployee
    {
        public string FullName { get; set; }
        public int PointLevel { get; set; }
        public List<Category> AssignedCategories { get; set; }
    }
}
