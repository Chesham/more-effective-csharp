using System;
using System.Collections.Generic;
using System.Text;
using item16;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace more_effective_csharp_2nd_edition
{
    [TestClass()]
    public class item16
    {
        [TestMethod()]
        public void Test01()
        {
            string projectName = string.Empty;
            string projectVersion = string.Empty; ;
            EventHandler myevent = (object sender, EventArgs e) =>
                {
                    if (e is GetNameEventArgs)
                    {
                        var _ = e as GetNameEventArgs;
                        projectName = _.name;
                    }
                    else if (e is GetVersionEventArgs)
                    {
                        var _ = e as GetVersionEventArgs;
                        projectVersion = _.version;
                    }
                };

            Assert.AreNotEqual("dotnet.exe", projectName);
            Assert.AreNotEqual("15.0.0.0", projectVersion);


            SystemMgr mgr = new SystemMgr();
            mgr.GetInfo(myevent);
            Assert.AreEqual("dotnet.exe", projectName);
            Assert.AreEqual("15.0.0.0", projectVersion.ToString());
        }

        [TestMethod()]
        public void Test02()
        {
            string projectName = string.Empty;
            string projectVersion = string.Empty; ;
            EventHandler myevent = (object sender, EventArgs e) =>
            {
                if (e is GetNameEventArgs)
                {
                    var _ = e as GetNameEventArgs;
                    projectName = _.name;
                }
            };

            Assert.AreNotEqual("dotnet.exe", projectName);

            SystemMgr mgr = new SystemMgr();
            mgr.GetInfo(myevent);
            Assert.AreEqual("dotnet.exe", projectName);
            Assert.AreNotEqual("15.0.0.0", projectVersion.ToString());
        }

    }


}
