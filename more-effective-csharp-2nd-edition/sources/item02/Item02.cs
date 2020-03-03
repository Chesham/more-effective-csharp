using System;
using System.Diagnostics.CodeAnalysis;

namespace item02
{
    [Serializable]
    public class Item02 : IEquatable<Item02>
    {
        public string Name { get; set; }

        public bool Equals([AllowNull] Item02 other) => Name == other.Name;

        public override bool Equals(object obj) => (obj as Item02)?.Equals(this) ?? false;

        public override int GetHashCode() => Name.GetHashCode();
    }
}
