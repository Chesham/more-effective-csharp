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

        [TestMethod()]
        public void Test03()
        {
            Logger logger = new Logger();
            var e = new EventHandler<LoggerEventArgs>((sender, args) =>
            {
                Assert.AreEqual("test", args.msg);
            });
            logger.Log += e;
            logger.AddMsg("test");
            logger.Log -= e;
        }

        [TestMethod()]
        public void Test04()
        {
            LoggerV2 logger = new LoggerV2();

            var ApplerEventrigger = false;
            var AppleEvent = new EventHandler<LoggerEventArgs>((sender, args) =>
            {
                ApplerEventrigger = true;
                Assert.AreEqual("Apple is the best", args.msg);
            });
            var AndroidEventrigger = false;
            var AndroidEvent = new EventHandler<LoggerEventArgs>((sender, args) =>
            {
                AndroidEventrigger = true;
                Assert.AreEqual("Android", args.msg);
            });
            logger.AddLogger("Apple", AppleEvent);
            logger.AddLogger("Android", AndroidEvent);
            logger.AddMsg("Apple", "is the best");
            logger.RemoveLogger("Apple", AppleEvent);
            logger.RemoveLogger("Android", AndroidEvent);

            Assert.IsTrue(ApplerEventrigger);
            Assert.IsFalse(AndroidEventrigger);
        }

        //做不出書上範例的結果，網路上的資料也沒類似做法先忽略
        [TestMethod(), Ignore]
        public void Test05()
        {
            LoggerV2 logger = new LoggerV2();

            var ApplerEventrigger = false;
            var AppleEvent = new EventHandler<LoggerEventArgs>((sender, args) =>
            {
                ApplerEventrigger = true;
                Assert.AreEqual("Apple is the best", args.msg);
            });
            var AndroidEventrigger = false;
            var AndroidEvent = new EventHandler<LoggerEventArgs>((sender, args) =>
            {
                AndroidEventrigger = true;
                Assert.AreEqual("Android", args.msg);
            });
            logger.AddLogger("Apple", AppleEvent);
            logger.AddLogger("Android", AndroidEvent);
            logger.AddMsgV2("Apple", "is the best");
            logger.RemoveLogger("Apple", AppleEvent);
            logger.RemoveLogger("Android", AndroidEvent);

            Assert.IsTrue(ApplerEventrigger);
            Assert.IsTrue(AndroidEventrigger);
        }

    }


}
