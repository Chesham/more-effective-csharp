using System;
using System.Threading;
using System.Threading.Tasks;

namespace item31
{
    public class Item31
    {
        public static async Task<int> DoAsyncThings()
        {
            await Task.Delay(1000);
            return Thread.CurrentThread.ManagedThreadId;
        }

        public static async Task<int> DoAsyncThings2()
        {
            await Task.Delay(1000);
            return Thread.CurrentThread.ManagedThreadId;
        }

        public string msg = "default";
        public async Task<Tuple<int, int>> SomeMethodAsync()
        {
            var result= await DoAsyncThings().ConfigureAwait(continueOnCapturedContext: false);
            var result2 = await DoAsyncThings2().ConfigureAwait(continueOnCapturedContext: false);
            return Tuple.Create(result, result2);
        }

        public async Task<int> AwareAsync()
        {
            //var tids = await SomeMethodAsync();
            await AwareAsync2();
            return Thread.CurrentThread.ManagedThreadId;
        }

        public async Task AwareAsync2()
        {
            Task.Delay(100);
        }
    }

    
}
