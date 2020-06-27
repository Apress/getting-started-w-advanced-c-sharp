using System;
using System.Threading;

namespace TestingBackgroundThreads
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Comparing a foreground threads with a background thread****");
            Thread.CurrentThread.Name = "Main Thread";
            Console.WriteLine($"{Thread.CurrentThread.Name} has started.");           
            Thread childThread = new Thread(MyMethod);
            childThread.Name = "Child Thread-1";
            Console.WriteLine("Starting Child Thread-1 shortly.");
            //threadOne starts
            childThread.Start();
            childThread.IsBackground = true;            
            Console.WriteLine("Control comes at the end of Main() method.");
            //Console.ReadKey();
        }
        static void MyMethod()
        {
            Console.WriteLine($"{Thread.CurrentThread.Name} enters into MyMethod()");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"{Thread.CurrentThread.Name} from MyMethod() prints {i}");
                //Taking a small sleep
                Thread.Sleep(100);
            }
            Console.WriteLine($"{Thread.CurrentThread.Name} exits from MyMethod()");
        }        
    }
}
