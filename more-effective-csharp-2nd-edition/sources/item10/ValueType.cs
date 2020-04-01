namespace item10
{
    public struct ValueType
    {
        static object nullId { get; } = new object();

        public object Id { get; set; }

        public override int GetHashCode() => Id?.GetHashCode() ?? nullId.GetHashCode();
    }
}
