using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticket_Processing
{
     interface IHelpDesk
    {
        public void AddTicket(ITicket ticket);
        public void AddEmployee(IEmployee employee);
        public void CompleteTicket(string employeeFullName, int ticketId);
        public int GetWaitingTicketCount();
        public int GetCompletedTicketsTotalPoint();
        public List<(Category category, int totalPoint)> GetTicketsTotalPointByCategory();
        public List<(IEmployee employee, int totalPoint)> GetTicketsTotalPointByEmployee();
    }
}
