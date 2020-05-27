using System;
using System.Collections.Generic;

namespace item26
{
    public static class Generator
    {
        public static IEnumerable<T> DelayedException<T>(IEnumerable<T> sequence, int sampleFrequency)
        {
            if (sequence == null)
                throw new ArgumentNullException();
            if (sampleFrequency < 1)
                throw new ArgumentException();
            var idx = 0;
            foreach (var i in sequence)
            {
                if (idx % sampleFrequency == 0)
                    yield return i;
            }
        }

        public static IEnumerable<T> Generate<T>(IEnumerable<T> sequence, int sampleFrequency)
        {
            if (sequence == null)
                throw new ArgumentNullException();
            if (sampleFrequency < 1)
                throw new ArgumentException();
            return internalGenerator();

            IEnumerable<T> internalGenerator()
            {
                var idx = 0;
                foreach (var i in sequence)
                {
                    if (idx % sampleFrequency == 0)
                        yield return i;
                }
            }
        }
    }
}
