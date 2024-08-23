using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Ticket_Processing
{
    public class HelpDesk : IHelpDesk
    {
        private List<IEmployee> Employees { get; set; }
        private List<ITicket> Tickets { get; set; }

        public HelpDesk()
        {
            Employees = new List<IEmployee>();
            Tickets = new List<ITicket>();
        }


        public void CompleteTicket(string employeeFullName, int ticketId)
        {
            var employee = Employees.FirstOrDefault(e => e.FullName == employeeFullName);
            var ticket = Tickets.FirstOrDefault(t => t.Id == ticketId);

            if (employee != null && ticket != null && !ticket.IsCompleted && employee.PointLevel >= ticket.Point && employee.AssignedCategories.Contains(ticket.Category))
            {
                ticket.IsCompleted = true;
                ticket.AssignedEmployee = employee.FullName;
            }
        }

        public int GetCompletedTicketsTotalPoint()
        {
            return Tickets.Where(t => t.IsCompleted).Sum(t => t.Point);
        }



        public int GetWaitingTicketCount()
        {
            return Tickets.Count(t => !t.IsCompleted);
        }

        void IHelpDesk.AddEmployee(IEmployee employee)
        {
            Employees.Add(employee);
        }

        public void AddEmployee(Employee employee)
        {
            ((IHelpDesk)this).AddEmployee(employee);
        }

        void IHelpDesk.AddTicket(ITicket ticket)
        {
            Tickets.Add(ticket);
        }

        public void AddTicket(Ticket ticket)
        {
            ((IHelpDesk)this).AddTicket(ticket);
        }

        public List<(Category category, int totalPoint)> GetTicketsTotalPointByCategory()
        {
            return Tickets.GroupBy(t => t.Category)
                          .Select(g => (g.Key, g.Where(t => t.IsCompleted).Sum(t => t.Point)))
                          .ToList();
        }

        List<(IEmployee employee, int totalPoint)> IHelpDesk.GetTicketsTotalPointByEmployee()
        {
            return Employees.Select(e => (e, Tickets.Where(t => t.IsCompleted && t.AssignedEmployee == e.FullName).Sum(t => t.Point)))
                          .ToList();
        }



        //List<(IEmployee employee, int totalPoint)> IHelpDesk.GetTicketsTotalPointByEmployee()
        //{
        //    return Employees.Select(e =>
        //        (
        //            e,
        //            Tickets.Where(t => t.IsCompleted && t.AssignedEmployee == e.FullName)
        //                   .Sum(t => t.Point)
        //        ))
        //        .ToList();
        //}

        // Public method that calls the explicit interface method
        public List<(Employee employee, int totalPoint)> GetTicketsTotalPointByEmployee()
        {
            var result = ((IHelpDesk)this).GetTicketsTotalPointByEmployee();
            return result.Select(r => ((Employee)r.employee, r.totalPoint)).ToList();
        }
    }
}

