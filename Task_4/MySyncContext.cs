using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task_4
{
    public class MySyncContext : SynchronizationContext
    {
        public override void Post(SendOrPostCallback d, object state)
        {
			try
			{
                d.Invoke(state);

            }
			catch (Exception)
			{
                Console.WriteLine("Exception Post");
            }
        }
    }
}
