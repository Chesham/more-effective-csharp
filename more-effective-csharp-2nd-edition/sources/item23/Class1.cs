using System;

namespace item23
{
    public partial class GeneratedStuff
    {
        private struct ReportChange
        {
            public readonly int OldValue;
            public readonly int NewValue;

            public ReportChange(int oldValue,int newValue)
            {
                OldValue = oldValue;
                NewValue = newValue;
            }
        }

        private class RequestChange
        {
            public ReportChange Values { get; set; }
            public bool Cancel { get; set; }
        }

        partial void ReportValueChanging(RequestChange args);
        partial void ReportValueChanged(ReportChange values);

        public int storage = 0;
        public void UpdateValue(int newValue)
        {
            RequestChange updateArgs = new RequestChange
            {
                Values = new ReportChange(storage, newValue)
            };
            ReportValueChanging(updateArgs);

            if(!updateArgs.Cancel)
            {
                storage = newValue;

                ReportValueChanged(new ReportChange(storage, newValue));
            }
        }
    }
}
