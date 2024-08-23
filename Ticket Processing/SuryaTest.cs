using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticket_Processing
{
    public class SuryaTest
    {
        private readonly ISuryaTest _helpDeskImplementation;

        public SuryaTest()
        {
            _helpDeskImplementation = new HelpDeskImplementation(); // Internal class
        }

         void AddEmployee(IEmployee employee)
        {
            _helpDeskImplementation.AddEmployee(employee);
        }

        // Other public methods wrapping the internal interface implementation
    }

    class HelpDeskImplementation : ISuryaTest
    {
        public void AddEmployee(IEmployee employee)
        {
            // Implementation
        }

        // Implement other methods...
    }
}
