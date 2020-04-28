using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace item17
{
    public class Item17
    {
        private List<int> _Datas = new List<int>();
        Random _random = new Random();
        public void GetValue()
        {
            for (int i = 0; i < 5; i++)
            {
                this._Datas.Add(this._random.Next(1, 1000));
            }
        }

        public List<int> Datas
        {
            get
            {
                return this._Datas;
            }
        }
        public IEnumerable<int> DatasI
        {
            get
            {
                return this._Datas;
            }
        }
        public ReadOnlyCollection<int> DatasW
        {
            get
            {
                return new ReadOnlyCollection<int>(this._Datas);
            }
        }
    }
}
