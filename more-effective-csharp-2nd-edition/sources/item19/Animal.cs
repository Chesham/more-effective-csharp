using System.Collections.Generic;

namespace item19
{
    public class Animal
    {
        public string Foo(Apple _) => $"{nameof(Animal)}.{nameof(Foo)}";

        public string Bar(Fruit _) => $"{nameof(Animal)}.{nameof(Bar)}";

        public string Baz(IEnumerable<Apple> _) => $"{nameof(Animal)}.{nameof(Baz)}";
    }
}
