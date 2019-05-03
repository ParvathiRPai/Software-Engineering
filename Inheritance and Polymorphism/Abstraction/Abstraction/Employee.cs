using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction
{
    public abstract class Employee 
    {
        public string Name { get; private set; }

        protected Employee(string name)
        {
            Name = name;
        }

        public abstract int GetSalary();
    }
}
