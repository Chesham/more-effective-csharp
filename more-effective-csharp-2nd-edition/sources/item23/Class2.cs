using System;
using System.Collections.Generic;
using System.Text;

namespace item23
{
    public partial class GeneratedStuff
    {
        partial void ReportValueChanging(RequestChange args)
        {
            //檢查
            if (args.Values.NewValue < 0)
            {
                args.Cancel = true;
            }
            else
            { }
        }
        partial void ReportValueChanged(ReportChange values)
        {
            //通知
        }
    }
}
