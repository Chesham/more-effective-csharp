using System;
using System.Threading;
using System.Threading.Tasks;

namespace item33
{
    public class Coo
    {
        Random rnd { get; set; } = new Random();

        public (int min, int max) randomBoundaries { get; set; } = (0, 0);

        TimeSpan getRandomDelay() => TimeSpan.FromMilliseconds(rnd.Next(randomBoundaries.min, randomBoundaries.max));

        public async Task foo(CancellationToken cancelToken, IProgress<(int, string)> progress)
        {
            // stage 1
            cancelToken.ThrowIfCancellationRequested();
            progress?.Report((0, "stage 1"));
            await Task.Delay(getRandomDelay());
            // stage 2
            cancelToken.ThrowIfCancellationRequested();
            progress?.Report((20, "stage 2"));
            await Task.Delay(getRandomDelay());
            // stage 3
            cancelToken.ThrowIfCancellationRequested();
            progress?.Report((40, "stage 3"));
            await Task.Delay(getRandomDelay());
            // stage 4
            cancelToken.ThrowIfCancellationRequested();
            progress?.Report((60, "stage 4"));
            await Task.Delay(getRandomDelay());
            // stage 5
            progress?.Report((80, "stage 5"));
            await Task.Delay(getRandomDelay());
            progress?.Report((100, "done"));
        }

        public async Task foo() => await foo(CancellationToken.None, null);

        public async Task foo(CancellationToken cancelToken) => await foo(cancelToken, null);

        public async Task foo(IProgress<(int, string)> progress) => await foo(CancellationToken.None, progress);
    }
}
