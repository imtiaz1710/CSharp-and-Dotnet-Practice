using System;
using System.Threading;

namespace ThreadExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var instance = new Program();
            var thread1 =new Thread(instance.DoSomeTasks1);
            var thread2 =new Thread(instance.DoSomeTasks2);
            thread1.Start("Printing Even:");
            thread2.Start("Printing Odd:");
            /*instance.DoSomeTasks1("Printing Even:");
            instance.DoSomeTasks2("Printing Odd:");*/
        }

        void DoSomeTasks1(object txt)
        {
            lock (txt)
            {
                for (int i = 0; i < 50; i += 2)
                {
                    Console.WriteLine(txt.ToString());
                    Thread.Sleep(100);
                }
            }
            for (int i = 0; i < 50; i+=2)
            {
                Console.WriteLine(txt.ToString()+i);
                Thread.Sleep(100);
            }
           
        }
        void DoSomeTasks2(object txt)
        {
            for (int i = 1; i < 50; i += 2)
            {
                Console.WriteLine(txt.ToString()+i);
                Thread.Sleep(100);
            }
        }
    }
}
