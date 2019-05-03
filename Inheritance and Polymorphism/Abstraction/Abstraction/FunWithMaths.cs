using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction
{
    public class FunWithMaths
    {
        public int MultiplyNumbers(INumberProvider provider)
        {
            var product = 1;
            var nums = provider.GetNumbers();
            foreach (var num in nums)
            {
                product *= num;
            }

            return product;
        }
    }
}
