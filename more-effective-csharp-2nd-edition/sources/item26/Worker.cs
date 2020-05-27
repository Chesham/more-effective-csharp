using System;
using System.Threading.Tasks;

namespace item26
{
    public static class Worker
    {
        public static async Task<string> LoadMessage(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
                throw new ArgumentException();
            await Task.Delay(100);
            return userName;
        }
        public static Task<string> LoadMessageWithLocalFunction(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
                throw new ArgumentException();
            return internalLoad();

            async Task<string> internalLoad()
            {
                await Task.Delay(100);
                return userName;
            }
        }
    }
}
