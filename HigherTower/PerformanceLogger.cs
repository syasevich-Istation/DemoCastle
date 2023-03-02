using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigherTower
{
    public class PerformanceLogger : IInterceptor
    {
        public PerformanceLogger() { }

        public void Intercept(IInvocation invocation)
        {
            Console.WriteLine($"Calling {invocation.Method.Name}");
            var timer = new Stopwatch();
            timer.Start();
            invocation.Proceed();
            timer.Stop();
            Console.WriteLine($"Calle to {invocation.Method.Name} completed in {timer.ElapsedMilliseconds} ms");
        }
    }
}
