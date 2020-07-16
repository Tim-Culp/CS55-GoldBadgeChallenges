using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_StreamingContent_Console.UI
{
    class RealConsole : IConsole
    {
        public void Clear()
        {
            Console.Clear();
        }

        public ConsoleKeyInfo ReadKey()
        {
            return Console.ReadKey();
        }
        public string ReadLine()
        {
            return Console.ReadLine();
        }
        public void WriteLine(string line)
        {
            Console.WriteLine(line);
        }
        public void WriteLine(object obj)
        {
            Console.WriteLine(obj);
        }

    }
}
