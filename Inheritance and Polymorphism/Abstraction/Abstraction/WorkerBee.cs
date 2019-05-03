using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction
{
    public class WorkerBee : Employee
    {
        public WorkerBee(string name) : base(name)
        {
        }

        public override int GetSalary()
        {
            return 1000000;
        }
    }
}
