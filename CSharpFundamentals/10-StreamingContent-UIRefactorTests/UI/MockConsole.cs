using _09_StreamingContent_Console.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_StreamingContent_UIRefactorTests.UI
{
    class MockConsole : IConsole
    {
        public Queue<string> UserInput;
        public string Output;
        public MockConsole(IEnumerable<string> input)
        {
            UserInput = new Queue<string>(input);
        }

        public void Clear ()
        {
            Output += "Console Cleared. \n";
        }

        public ConsoleKeyInfo ReadKey()
        {
            return new ConsoleKeyInfo();
        }
        public string ReadLine()
        {
            return UserInput.Dequeue();
        }
        public void WriteLine(string str)
        {
            Output += str + "\n";
        }
        public void WriteLine(object obj)
        {
            Output += obj + "\n";
        }

    }
}
