using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task_4
{
    internal class Program
    {

        static Program()
        {
            SynchronizationContext.SetSynchronizationContext(new MySyncContext());
        }



        static void Main(string[] args)
        {
            MaAsy();

            Console.ReadKey();
        }



        public static async void MaAsy()
        {
            //await Task.Run(() => { Console.WriteLine("Hello"); });
            await Task.Run(() => { throw new Exception(); });
        }




    }
}
