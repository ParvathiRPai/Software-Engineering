using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }


    public class Program
    {
        static void Main(string[] args)
        {
        }

        public static double Average(int[] nums)
        {
            var sum = 0;
            foreach (var num in nums)
                sum += num;

            var avg = (double)sum / nums.Length;

            return avg;
        }

        public static void RemoveFromLinkedList(LinkedList<int> list, int valueToRemove)
        {
            if (list.Count == 0)
                return;

            // using the built-in remove of value
            var valueWasFound = false;
            do
            {
                valueWasFound = list.Remove(valueToRemove);
            }
            while (valueWasFound);

            // manually looping and removing nodes
            //var currentNode = list.First;
            //while (currentNode != null)
            //{
            //    var nextNode = currentNode.Next;

            //    if (currentNode.Value == valueToRemove)
            //        list.Remove(currentNode);

            //    currentNode = nextNode;
            //}
        }

        public static List<int> DoubleList(List<int> list)
        {
            var retVal = new List<int>();

            foreach (var num in list)
            {
                var newVal = num * 2;
                retVal.Add(newVal);
            }

            return retVal;
        }

        public static void UpdateUserById(Dictionary<int, User> users, 
            int id, 
            string firstName = null, 
            string lastName = null)
        {
            if (!users.ContainsKey(id))
                throw new ArgumentException("The specified id " + id + " was not found");

            var matchingUser = users[id];

            if (!string.IsNullOrEmpty(firstName))
                matchingUser.FirstName = firstName;

            if (!string.IsNullOrEmpty(lastName))
                matchingUser.LastName = lastName;
        }

        public static void RemoveFromStack(Stack<int> stack, int valueToRemove)
        {
            var temp = new Stack<int>();

            if (!stack.Contains(valueToRemove))
                return;

            while (stack.Count > 0)
            {
                var topValue = stack.Pop();
                if (topValue != valueToRemove)
                    temp.Push(topValue);
            }

            while (temp.Count > 0)
            {
                stack.Push(temp.Pop());
            }
        }

        public static string GetStringFromQueue(Queue<char> queue, int numCopies)
        {
            var sb = new StringBuilder();

            var max = queue.Count * numCopies;
            var current = 0;
            while (current < max)
            {
                var c = queue.Dequeue();
                queue.Enqueue(c);

                sb.Append(c);

                current++;
            }

            return sb.ToString();
        }
    }
}
