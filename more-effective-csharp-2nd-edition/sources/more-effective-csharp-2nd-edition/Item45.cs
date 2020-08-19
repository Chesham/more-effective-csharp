using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using item45;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace more_effective_csharp_2nd_edition
{
    [TestClass()]
    public class Item45
    {
        [TestMethod()]
        public void 測試無法存取屬性的動態類別()
        {
            dynamic dynamicProperties = new item45.DynamicPropertyBag();
            Assert.ThrowsException<Microsoft.CSharp.RuntimeBinder.RuntimeBinderException>(() => dynamicProperties.Name = "test");
            Assert.ThrowsException<Microsoft.CSharp.RuntimeBinder.RuntimeBinderException>(() => dynamicProperties.Name);
        }

        [TestMethod()]
        public void 測試可存取屬性的動態類別()
        {
            dynamic dynamicPropertiesV2 = new item45.DynamicPropertyBagV2();
            dynamicPropertiesV2.Name = "test";
            Assert.IsTrue("test" == dynamicPropertiesV2.Name);
        }

        [TestMethod()]
        public void 傳統讀取XML()
        {
            var r = default(XDocument);
            var _ = Assembly.GetExecutingAssembly();
            using (var sr = new StreamReader("Planets.xml"))
            {
                r = XDocument.Parse(sr.ReadToEnd());
            }

            Assert.IsTrue("Mercury" == r.Root.Elements("Planet").First().Element("Name").Value);

            Assert.IsTrue("Earth" == r.Root.Elements("Planet").Skip(2).First().Element("Name").Value);

            Assert.IsTrue("Moon" == r.Root.Elements("Planet").Skip(2).First().Elements("Moons").First().Element("Moon").Value);
        }

        [TestMethod()]
        public void 動態讀取XML()
        {
            XmlDocument doc = new XmlDocument();
            XElement documentXml;
            var _ = Assembly.GetExecutingAssembly();
            using (var sr = new StreamReader("Planets.xml"))
            {

                doc.LoadXml(sr.ReadToEnd());
                documentXml = XElement.Load(new XmlNodeReader(doc));
            }

            dynamic dynamicXML = new item45.DynamicXElement(documentXml);
            Assert.IsTrue("Mercury" == dynamicXML.Planet.Name.Value);

            Assert.IsTrue("Earth" == dynamicXML["Planet", 2].Name.Value);

            Assert.IsTrue("Moon" == dynamicXML["Planet", 2]["Moons", 0].Moon.Value);

        }
    }
}
