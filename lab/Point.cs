using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;

namespace lab
{
    public class Point
    {
        public Person Person { get; set; }
        public Point? Next {get; set;}
        public Point? Prev { get; set; }
        public Point()
        {
            Person = new Person();
            Next = null;
            Prev = null;
        }

        public Point(Person p)
        {
            Person = p;
            Next = null;
            Prev = null;
        }

        public override string ToString()
        {
            return Person + " ";
        }
    }
}
