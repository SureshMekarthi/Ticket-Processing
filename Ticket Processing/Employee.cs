using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticket_Processing
{
    public class Employee : IEmployee
    {
        public string FullName { get; set; }
        public int PointLevel { get; set; }
        public List<Category> AssignedCategories { get; set; }

        public Employee(string fullName, int pointLevel, List<Category> assignedCategories)
        {
            FullName = fullName;
            PointLevel = pointLevel;
            AssignedCategories = assignedCategories;
        }

    }
}
