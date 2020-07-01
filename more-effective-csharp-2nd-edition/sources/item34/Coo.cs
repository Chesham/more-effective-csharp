using System;
using System.Threading.Tasks;

namespace item34
{
    public class Coo
    {
        public TimeSpan cacheTimeout { get; set; } = TimeSpan.Zero;

        public Func<DateTime> getNow { get; set; } = () => DateTime.Now;

        public (int min, int max) randomRange { get; set; } = (0, 0);

        Random rnd { get; set; } = new Random();

        DateTime? lastCacheTime { get; set; }

        int? data { get; set; }

        public ValueTask<int> getCache()
        {
            try
            {
                if (!lastCacheTime.HasValue || (getNow() - lastCacheTime) > cacheTimeout)
                {
                    async Task<int> query()
                    {
                        var value = rnd.Next(randomRange.min, randomRange.max);
                        await Task.Delay(TimeSpan.FromMilliseconds(value));
                        data = value;
                        return value;
                    }
                    return new ValueTask<int>(query());
                }
                else
                {
                    return new ValueTask<int>(data.Value);
                }
            }
            finally
            {
                lastCacheTime = DateTime.Now;
            }
        }

        public async Task<int> getCacheTask()
        {
            try
            {
                if (!lastCacheTime.HasValue || (getNow() - lastCacheTime) > cacheTimeout)
                {
                    var value = rnd.Next(randomRange.min, randomRange.max);
                    await Task.Delay(TimeSpan.FromMilliseconds(value));
                    data = value;
                    return value;
                }
                else
                {
                    return data.Value;
                }
            }
            finally
            {
                lastCacheTime = DateTime.Now;
            }
        }
    }
}
