using System;
using System.Linq;
using System.Threading.Tasks;

namespace item20
{
    public class WorkEngine
    {
        public event EventHandler<WorkEventArgs> onProgress;

        public async Task Start()
        {
            var rnd = new Random();
            var tasks = Enumerable.Range(0, 3).Select(async i =>
            {
                var delay = TimeSpan.FromMilliseconds(rnd.Next(500, 1500));
                await Task.Delay(delay);
            }).ToList();
            var step = 0;
            foreach (var task in tasks)
            {
                var caughtException = default(Exception);
                try
                {
                    await task;
                }
                catch (Exception ex)
                {
                    caughtException = ex;
                }
                var args = new WorkEventArgs { exception = caughtException, step = step++ };
                try
                {
                    onProgress?.Invoke(this, args);
                }
                catch (Exception)
                {
                    // log here
                }
                if (args.isCancelled)
                    break;
            }
        }
    }
}
