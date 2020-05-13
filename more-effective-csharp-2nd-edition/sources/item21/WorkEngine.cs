using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace item21
{
    public abstract class WorkEngine
    {
        public virtual event EventHandler<WorkEventArgs> onProgress;

        public async Task Start()
        {
            var rnd = new Random();
            var tasks = Enumerable.Range(0, 3).Select(async i =>
            {
                var delay = TimeSpan.FromMilliseconds(rnd.Next(500, 1500));
                await Task.Delay(delay);
            }).ToList();
            SomeWork();
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

        protected abstract void SomeWork();
    }

    public class WorkEngineDerived : WorkEngine
    {
        protected override void SomeWork()
        {
            Thread.Sleep(50);
        }

        public override event EventHandler<WorkEventArgs> onProgress;
    }

    public class WorkEngineDerived2 : WorkEngine
    {
        protected override void SomeWork()
        {
            Thread.Sleep(50);
        }

        public override event EventHandler<WorkEventArgs> onProgress
        {
            add { base.onProgress += value; }
            remove { base.onProgress += value; }
        }
    }

    public abstract class WorkEngineV2
    {

        protected EventHandler<WorkEventArgs> progressEvent;

        public virtual event EventHandler<WorkEventArgs> OnProgress
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            add { progressEvent += value; }
            [MethodImpl(MethodImplOptions.Synchronized)]
            remove { progressEvent -= value; }
        }

        public async Task Start()
        {
            var rnd = new Random();
            var tasks = Enumerable.Range(0, 3).Select(async i =>
            {
                var delay = TimeSpan.FromMilliseconds(rnd.Next(500, 1500));
                await Task.Delay(delay);
            }).ToList();
            SomeWork();
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
                    progressEvent?.Invoke(this, args);
                }
                catch (Exception)
                {
                    // log here
                }
                if (args.isCancelled)
                    break;
            }
        }

        protected abstract void SomeWork();
    }
    public class WorkEngineDerivedV2 : WorkEngineV2
    {
        protected override void SomeWork()
        {
            Thread.Sleep(50);
        }

        public override event EventHandler<WorkEventArgs> OnProgress
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            add { progressEvent += value; }
            [MethodImpl(MethodImplOptions.Synchronized)]
            remove { progressEvent -= value; }
        }
    }
}

