using System;

namespace item01
{
    class Item01Impl : Item01
    {
        public override string firstName { get; set; }

        public override string lastName { get; set; }

        public override TimeSpan Timeout => timeout ?? base.Timeout;

        public TimeSpan? timeout { get; set; }
    }
}
