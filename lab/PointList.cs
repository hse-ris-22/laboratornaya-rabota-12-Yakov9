using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;

namespace lab
{
    public class PointList<T>
    {
        public T? Data { get; set; }
        public PointList<T>? Next {get; set;}
        public PointList<T>? Prev { get; set; }
        public PointList()
        {
            Data = default(T);
            Next = null;
            Prev = null;
        }

        public PointList(T p)
        {
            Data = p;
            Next = null;
            Prev = null;
        }

        public override string ToString()
        {
            return Data + " ";
        }
    }
}
