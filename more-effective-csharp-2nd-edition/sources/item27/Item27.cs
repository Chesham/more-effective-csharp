using System;
using System.Threading.Tasks;

namespace item27
{
    public class Item27
    {
        public string msg = "default";
        public async Task SomeMethodAsync()
        {
            Task awaitable = Task.Delay(10);
            msg ="In SomeMethodAsync,before the await";
            await awaitable;
            msg = "In SomeMethodAsync,after the await";
        }
    }
}
