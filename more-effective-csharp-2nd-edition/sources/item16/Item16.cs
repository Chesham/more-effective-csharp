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


    public class Logger
    {

        private EventHandler<LoggerEventArgs> log;
        public event EventHandler<LoggerEventArgs> Log
        {
            add { log = log + value; }
            remove { log = log - value; }
        }

        public void AddMsg(string msg) => log?.Invoke(this, new LoggerEventArgs { msg = msg });
    }

    public class LoggerV2
    {
        private EventHandlerList Handlers = new EventHandlerList();


        private EventHandler<LoggerEventArgs> log;
        public event EventHandler<LoggerEventArgs> Log
        {
            add { log = log + value; }
            remove { log = log - value; }
        }

        public void AddMsg(string system, string msg)
        {
            if (!string.IsNullOrEmpty(system))
            {
                EventHandler<LoggerEventArgs> handler = Handlers[system] as EventHandler<LoggerEventArgs>;

                LoggerEventArgs args = new LoggerEventArgs { msg = $"{system} {msg}" };
                handler?.Invoke(null, args);

                //空字串代表接受全部訊息
                //handler = Handlers[""] as EventHandler<LoggerEventArgs>;
                //handler?.Invoke(null, args);

            }
        }

        public void AddMsgV2(string system, string msg)
        {
            if (!string.IsNullOrEmpty(system))
            {
                // EventHandler<LoggerEventArgs> handler = Handlers[system] as EventHandler<LoggerEventArgs>;
                LoggerEventArgs args = new LoggerEventArgs { msg = $"{system} {msg}" };
                // handler?.Invoke(null, args);
                //空字串代表接受全部訊息
                EventHandler<LoggerEventArgs> handler = Handlers[null] as EventHandler<LoggerEventArgs>;
                handler?.Invoke(null, args);

            }


        }
        public void AddLogger(string system, EventHandler<LoggerEventArgs> ev) => Handlers.AddHandler(system, ev);

        public void RemoveLogger(string system, EventHandler<LoggerEventArgs> ev) => Handlers.RemoveHandler(system, ev);
    }
}
