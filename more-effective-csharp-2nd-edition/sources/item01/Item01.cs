using System;
using System.Collections.Generic;

namespace item01
{
    public abstract class Item01
    {
        public abstract string firstName { get; set; }

        public abstract string lastName { get; set; }

        public virtual TimeSpan Timeout => TimeSpan.FromSeconds(5);

        public string Name => $"{firstName}, {lastName}";

        List<Item01> members = new List<Item01>();

        public Item01 this[int index] => members[index];

        public static Item01 Create(string firstName, string lastName, TimeSpan? timeout = null, params Item01[] members)
        {
            var item = new Item01Impl { firstName = firstName, lastName = lastName };
            if (timeout.HasValue)
                item.timeout = timeout.Value;
            item.members.AddRange(members);
            return item;
        }
    }
}
