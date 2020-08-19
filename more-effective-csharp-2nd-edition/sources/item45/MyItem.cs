using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace item45
{
    public class MyItem
    {

    }

    public class DynamicPropertyBag
    {

    }

    public class DynamicPropertyBagV2 : DynamicObject
    {
        private Dictionary<string, object> storage = new Dictionary<string, object>();
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            if (storage.ContainsKey(binder.Name))
            {
                result = storage[binder.Name];
                return true;
            }
            result = null;
            return false;
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            string key = binder.Name;
            if (storage.ContainsKey(key))
                storage[key] = value;
            else
                storage.Add(key, value);
            return true;
        }


    }
    public class DynamicXElement : DynamicObject
    {
        private readonly XElement xmlSource;
        public DynamicXElement(XElement source)
        {
            xmlSource = source;
        }
        private Dictionary<string, object> storage = new Dictionary<string, object>();
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = new DynamicXElement(null);
            if (binder.Name == "Value")
            {
                result = (xmlSource != null) ? xmlSource.Value : "";
                return true;
            }
            if (xmlSource != null)
                result = new DynamicXElement(xmlSource.Element(XName.Get(binder.Name)));
            return true;
        }

        public override bool TryGetIndex(GetIndexBinder binder, object[] indexes, out object result)
        {
            result = null;
            if (indexes.Length != 2)
                return false;
            if (!(indexes[0] is string))
                return false;
            if (!(indexes[1] is int))
                return false;

            var allNodes = xmlSource.Elements(indexes[0].ToString());
            int index = (int)indexes[1];
            if (index < allNodes.Count())
                result = new DynamicXElement(allNodes.ElementAt(index));
            else
                result = new DynamicXElement(null);

            return true;
        }

        public override string ToString() => xmlSource?.ToString() ?? string.Empty;


    }

    //public class DynamicDictionary2 : IDynamicMetaObjectProvider
    //{
    //    DynamicMetaObject IDynamicMetaObjectProvider.GetMetaObject(System.Linq.Expressions.Expression parameter)
    //    {
    //        return new DynamicMetaObject(parameter);
    //    }
    //    private Dictionary<string, object> storage = new Dictionary<string, object>();

    //    public object SetDict(string key, object value)
    //    {
    //        if (storage.ContainsKey(key))
    //            storage[key] = value;
    //        else
    //            storage.Add(key, value);
    //        return value;
    //    }

    //    public object GetDict(string key)
    //    {
    //        object result = null;
    //        if (storage.ContainsKey(key))
    //        {
    //            result = storage[key];
    //        }
    //        return result;
    //    }

    //}

}
