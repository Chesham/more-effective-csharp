using System.Collections.Generic;

namespace item19
{
    public class Tiger : Animal
    {
        public string Foo(Fruit _) => $"{nameof(Tiger)}.{nameof(Foo)}";

        public string Bar(Fruit _1, Fruit _2 = null) => $"{nameof(Tiger)}.{nameof(Bar)}";

        public string Baz(IEnumerable<Fruit> _) => $"{nameof(Tiger)}.{nameof(Baz)}";
    }
}
