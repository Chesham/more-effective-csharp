using System;
using System.Diagnostics.CodeAnalysis;

namespace item10
{
    public class ReferenceType : IEquatable<ReferenceType>
    {
        static object nullId { get; } = new object();

        public object Id { get; set; }

        public override int GetHashCode() => Id?.GetHashCode() ?? nullId.GetHashCode();

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
                return true;
            return Equals(obj as ReferenceType);
        }

        public bool Equals([AllowNull] ReferenceType other)
        {
            if (other == null)
                return false;
            return Equals(Id, other.Id);
        }
    }
}
