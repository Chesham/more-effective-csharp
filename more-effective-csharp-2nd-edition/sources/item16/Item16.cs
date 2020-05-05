using System;
using System.ComponentModel;
using System.Reflection;

namespace item16
{

    public class SystemMgr
    {
        public string projectName = System.Diagnostics.Process.GetCurrentProcess().MainModule.ModuleName;
        public string projectVersion = Assembly.GetEntryAssembly().GetName().Version.ToString();
        public EventHandlerList lsit = new EventHandlerList();
        public event EventHandler<EventArgs> hanlder;
        public void GetInfo(EventHandler eventHandler = null)
        {
            eventHandler?.Invoke(null, new GetNameEventArgs { name = projectName });
            eventHandler?.Invoke(null, new GetVersionEventArgs { version = projectVersion });
        }

    }

    public class GetNameEventArgs : EventArgs
    {
        public string name { set; get; }
    }

    public class GetVersionEventArgs : EventArgs
    {
        public string version { set; get; }
    }
}
