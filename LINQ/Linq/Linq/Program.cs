using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    public class Program
    {
        static void Main(string[] args)
        {
        }

        public static List<int> Increment(List<int> list)
        {
            return list.Select(x => x + 1).ToList();
        }

        public static int[] GetWhereDivisibleBy(List<int> nums, int x)
        {
            return nums.Where(y => y % x == 0).ToArray();
        }

        public static bool AnyCapitals(string s)
        {
            return s.Any(x => char.IsUpper(x));
        }

        public static int GetLastOddElement(int[] nums)
        {
            return nums.LastOrDefault(x => x % 2 == 1);
        }

        public static int GetMinListListValue(List<List<int>> lists)
        {
            return lists.Min(x => x.Min());
        }

        public static List<User> SortUsersByAge(List<User> users)
        {
            return users.OrderByDescending(x => x.Age).ThenBy(x => x.LastName).ToList();
        }
    }
}
