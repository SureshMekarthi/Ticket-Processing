using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

namespace Ticket_Processing
{
    internal class Program
    {
        static void Main(string[] args)
        {

            TextWriter textWriter = new StreamWriter("C:\\Users\\v-smekarthi\\source\\repos\\Ticket Processing\\Ticket Processing\\outfolder\\test.txt", true);

            HelpDesk hd = new HelpDesk();

            int eCount = Convert.ToInt32(Console.ReadLine().Trim());
            for (int i = 1; i <= eCount; i++)
            {
                var a = Console.ReadLine().Trim().Split(',');
                List<Category> eCa = new List<Category>();
                foreach (string cc in a[2].Split(' '))
                {
                    eCa.Add((Category)Enum.Parse(typeof(Category), cc));
                }
                var e = new Employee(a[0], Convert.ToInt32(a[1]), eCa);
                hd.AddEmployee(e);
            }

            int tCount = Convert.ToInt32(Console.ReadLine().Trim());
            for (int i = 1; i <= tCount; i++)
            {
                var a = Console.ReadLine().Trim().Split(',');
                var t = new Ticket(Convert.ToInt32(a[0]), a[1], (Category)Enum.Parse(typeof(Category), a[2]), Convert.ToInt32(a[3]));
                hd.AddTicket(t);
            }
            int pCount = Convert.ToInt32(Console.ReadLine().Trim());
            for (int i = 1; i <= pCount; i++)
            {
                var a = Console.ReadLine().Trim().Split(',');
                hd.CompleteTicket(a[0], Convert.ToInt32(a[1]));
            }

            textWriter.WriteLine("WaitingTicketCount:" + hd.GetWaitingTicketCount());
            textWriter.WriteLine("CompletedTicketsTotalPoint:" + hd.GetCompletedTicketsTotalPoint());
            textWriter.WriteLine("TicketsTotalPointByCategory:");
            foreach (var item in hd.GetTicketsTotalPointByCategory())
            {
                textWriter.WriteLine(item.category.ToString() + ":" + item.totalPoint.ToString());
            }
            textWriter.WriteLine("TicketsTotalPointByEmployee:");
            foreach (var item in hd.GetTicketsTotalPointByEmployee())
            {
                textWriter.WriteLine(item.employee.FullName + ":" + item.totalPoint.ToString());
            }

            textWriter.Flush();
            textWriter.Close();
        }
    }
}

