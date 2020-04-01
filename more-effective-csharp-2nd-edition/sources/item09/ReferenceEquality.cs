using System;
using System.Diagnostics.CodeAnalysis;

namespace item09
{
    public class ReferenceEquality : IEquatable<ReferenceEquality>
    {
        public object Id { get; set; }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
                return true;
            return Equals(obj as ReferenceEquality);
        }

        public bool Equals([AllowNull] ReferenceEquality other)
        {
            if (other == null)
                return false;
            return Id.Equals(other.Id);
        }

        public override int GetHashCode() => Id.GetHashCode();
    }
}
