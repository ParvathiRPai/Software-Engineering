using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction
{
    public class OddNumberProvider : INumberProvider
    {
        public int[] GetNumbers()
        {
            return new int[] { 1, 3, 5, 7, 9 };
        }
    }
}
