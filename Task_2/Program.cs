using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task_2
{

    public class MyContext : SynchronizationContext
    {
        public override void Post(SendOrPostCallback d, object state)
        {
            Task.Run(() =>
            {

                Thread.CurrentThread.Name = "My Thread in Post";

                Console.WriteLine($"Задача выполняется в потоке {Thread.CurrentThread.ManagedThreadId}, " +
                    $"имя потока: {Thread.CurrentThread.Name}, " +
                    $"поток из пула: {Thread.CurrentThread.IsThreadPoolThread}");
                d.Invoke(state);

            });
        }
    }

    internal class Program
    {
        static async Task Main(string[] args)
        {
            SynchronizationContext.SetSynchronizationContext(new MyContext());


            Console.WriteLine($"Main выполняется в потоке {Thread.CurrentThread.ManagedThreadId}, имя потока: {Thread.CurrentThread.Name}, поток из пула: {Thread.CurrentThread.IsThreadPoolThread}");

           await FactorialAsync(5);

            Console.ReadKey();
        }

        static async Task FactorialAsync(int n)
        {
            await Task.Run(() =>
            {
                int factorial = 1;
                for (int i = 1; i <= n; i++)
                {
                    factorial *= i;
                    Console.WriteLine($"Цикл выполняется в потоке {Thread.CurrentThread.ManagedThreadId}, имя потока: {Thread.CurrentThread.Name}, поток из пула: {Thread.CurrentThread.IsThreadPoolThread}");
                }
                Console.WriteLine($"Факториал числа {n} равен {factorial}");
            });
        }

    }
}
