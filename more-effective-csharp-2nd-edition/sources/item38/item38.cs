using System;
using System.ComponentModel;
using System.Threading;

namespace item38
{
    public class item38
    {


    }

    public class WorkEngine
    {
        public virtual event EventHandler<DoWorkEventArgs> handler;
        private BackgroundWorker _demoBGWorker = new BackgroundWorker();
        public void Start()
        {
            _demoBGWorker.DoWork += BGWorker_DoWork;
            _demoBGWorker.RunWorkerAsync();
        }

        public void Start(int EndNmumber)
        {
            _demoBGWorker.DoWork += BGWorker_DoWork;
            _demoBGWorker.WorkerSupportsCancellation = true;
            _demoBGWorker.RunWorkerAsync(EndNmumber);
        }

        public void Cancel()
        {
            _demoBGWorker.CancelAsync();
        }

        private void BGWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bgWorker = sender as BackgroundWorker;

            if (bgWorker.CancellationPending == true)
            {
                e.Cancel = true;
                e.Result = -999;
                handler?.Invoke(this, e);
                return;
            }
            if (e.Argument == null || !int.TryParse(e.Argument.ToString(), out int endNumber))
            {
                endNumber = 100;
            }

            //在這裡執行耗時的運算。
            int sum = 0;
            for (int i = 0; i <= endNumber; i++)
            {
                sum += i;
            }
            e.Result = sum;
        }

    }
}
