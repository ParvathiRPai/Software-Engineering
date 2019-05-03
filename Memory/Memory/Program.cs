using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory
{
    class Program
    {
        static void Main(string[] args)
        {
            // create an orphaned instance of MyClass
            //CreateMyClass();

            // Perform garbage collection and wait for finalizers
            // Anything with a finalizer will not be cleaned up until the next GC pass
            //GC.Collect();
            //GC.WaitForPendingFinalizers();

            // second pass of garbage collection, this reclaims allocated memory
            //GC.Collect();
            //GC.WaitForPendingFinalizers();

            var path = @"c:\test\test.txt";
            using (var fw = new MyFileWriter(path))
            {
                fw.WriteLine("Hello World!");
            }

            using (var fw2 = new MyFileWriter(path))
            {
                fw2.WriteLine("Hello World!");
            }
        }

        static void CreateMyClass()
        {
            var mc = new MyClass();
        }
    }
}
