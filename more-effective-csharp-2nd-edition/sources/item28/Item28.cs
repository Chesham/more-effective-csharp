using System;
using System.Threading.Tasks;

namespace item28
{
    public class Item28
    {
        public static async void FireAndForget(TimeSpan timeout)
        {
            var task = Task.Delay(timeout);
            await task;

            throw new Exception();
        }

        public static async Task ReturnTask(TimeSpan timeout)
        {
            var task = Task.Delay(timeout);
            await task;

            throw new Exception();
        }
    }

    public class TaskEvent
    {
        public event EventHandler<EventArgs> OnEvent;
        public TaskEvent()
        {
            OnEvent += HandleShapeChanged;
        }
        private async void HandleShapeChanged(object sender, EventArgs e)
        {
            try//為了確保不會有任何Exception從此方法發出
            {
                await DoAsyncThings();
            }
            catch(Exception ex)
            {
                Console.WriteLine("in HandleShapeChanged");
            }
        }

        private Task DoAsyncThings()
        {
            throw new NotImplementedException();
        }

        public void OnShapeChanged(EventArgs e)
        {
            OnEvent?.Invoke(this, e);
        }
    }
    public class TaskEventStop
    {
        public event EventHandler<EventArgs> OnEvent;
        public TaskEventStop()
        {
            OnEvent += HandleShapeChanged;
        }
        private async void HandleShapeChanged(object sender, EventArgs e)
        {
            try//為了確保不會有任何Exception從此方法發出
            {
                await DoAsyncThings();
            }
            catch (Exception ex)when(logMessage("in HandleShapeChanged"))
            {

            }
        }

        private bool logMessage(string v)
        {
            Console.WriteLine(v);
            return false;
        }

        private Task DoAsyncThings()
        {
            throw new NotImplementedException();
        }

        public void OnShapeChanged(EventArgs e)
        {
            OnEvent?.Invoke(this, e);
        }

    }
}
