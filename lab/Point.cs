using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;

namespace lab
{
    public class Point<T>
    {
        public Person? Data { get; set; }
        public Point<T>? Next {get; set;}
        public Point<T>? Prev { get; set; }
        public Point()
        {
            Data = null;
            Next = null;
            Prev = null;
        }

        public Point(Person p)
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
