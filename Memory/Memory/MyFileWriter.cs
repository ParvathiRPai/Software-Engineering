using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory
{
    public class MyFileWriter : IDisposable
    {
        private StreamWriter sw;

        public MyFileWriter(string path)
        {
            var dir = Path.GetDirectoryName(path);
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            sw = new StreamWriter(path);
        }

        public void Dispose()
        {
            if (sw != null)
                sw.Close();
        }

        public void WriteLine(string str)
        {
            sw.WriteLine(str);
        }
    }
}
