using System;
using System.Collections;
using System.Collections.Immutable;
using System.Collections.Generic;

namespace item03
{
    public struct Item03
    {
        public string Name { get; }

        public int Age { get; }

        public string City { get; }

        public string[] Phones { get; }

        public IEnumerable<string> Phones2 { get; }

        public Item03(string name,int age, string city,string[] phones) {
            Name = name;
            City = city;
            Age = age;
            Phones = phones;
            Phones2 = phones.ToImmutableList();
        }
    }
}
