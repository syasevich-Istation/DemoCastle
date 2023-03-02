using Castle.DynamicProxy;
using System.Diagnostics;


namespace HigherTower
{
    public class PerformanceLoggingInterceptor : IInterceptor
    {
        public PerformanceLoggingInterceptor(/*inject a real logger to log to a file/db/etc*/)
        { }

        public void Intercept(IInvocation invocation)
        {
            Console.WriteLine($"----PERFORMACE: Calling {invocation.Method.Name}");
            var timer = new Stopwatch();
            bool isFailed = false;
            timer.Start();
            try
            {
                invocation.Proceed();
            }
            catch (Exception)
            {
                isFailed= true;
                throw;
            }
            finally
            {
                timer.Stop();
                var result = isFailed ? "failed" : "succeeded";
                Console.WriteLine($"----PERFORMACE: Call to {invocation.Method.Name} {result} in {timer.ElapsedMilliseconds} ms");
            }
        }
    }
}
