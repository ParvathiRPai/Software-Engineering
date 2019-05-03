using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Async
{
    public interface IDataProvider
    {
        Task<List<int>> GetDataAsync();
    }

    public class DataProvider : IDataProvider
    {
        public async Task<List<int>> GetDataAsync()
        {
            var retVal = await GetNums();
            return retVal;
        }

        public Task<List<int>> GetNums()
        {
            return Task.Run(() => new List<int> { 1, 2, 3 });
        }
    }

    public class DataConsumer
    {
        public int Sum(IDataProvider provider)
        {
            var data = provider.GetDataAsync().Result;
            return data.Sum();
        }
    }

    public class Program
    {


        public static Task<string> BuildStringTask(List<string> strings)
        {
            return Task.Factory.StartNew((x) => 
            {
               var myStrings = x as List<string>;

               var sb = new StringBuilder();
               foreach (var str in myStrings)
               {
                   sb.Append(str);
               }
               return sb.ToString();
           },

           strings // this is the state object
           );
        }

        public static Task HelloWorldTask()
        {
            Console.WriteLine("Starting task");
            return Task.Run(() => Console.WriteLine("Hello World"));
        }

        public static Task<DateTime> GetDateTask()
        {
            return Task.Run(() =>
            {
                return DateTime.Now;
            });

            //var task = new Task<DateTime>(() => DateTime.Now);
            //task.Start();
            //return task;
        }

        public static void HelloWorld()
        {
            Console.WriteLine("Hello World!");
        }

        public static async Task<int> DoSomething()
        {
            var retVal = await Task.Run(() => 5);
            return retVal;
        }

        static void Main(string[] args)
        {
            //Console.WriteLine("Starting main");
            //var task = HelloWorldTask();
            //task.Wait();
            //Console.WriteLine("Task finished!");

            //var dateFromTask = GetDateTask().Result;
            //Console.WriteLine($"Date from task = {dateFromTask}");

            for (var i=0; i<10; i++)
            {
                Task.Run(() => HelloWorld());
            }

            Console.ReadLine();
        }
    }
}
