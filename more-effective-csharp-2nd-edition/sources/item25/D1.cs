namespace item25
{
    public class D1 : B
    {
        public static new B Factory() => new D1();

        public override void WriteType() => WriteLine(nameof(D1));
    }
}
