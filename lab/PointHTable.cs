using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab
{
    public class PointHTable<T>
    {
        public int key;//ключ
        public T value;//значение
        public PointHTable(T data)
        {
            value = data;
            key = GetHashCode();
        }
        public override string ToString()
        {
            return key + ":" + value?.ToString();
        }
        public override int GetHashCode()
        {
            return value.GetHashCode();
        }
    }
}
