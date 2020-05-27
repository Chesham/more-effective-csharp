namespace item25
{
    public class D2 : B
    {
        public static new B Factory() => new D2();

        public override void WriteType() => WriteLine(nameof(D2));
    }
}
