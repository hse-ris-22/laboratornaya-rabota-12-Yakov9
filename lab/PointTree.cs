using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab
{
    public class PointTree<T>
    {
        public T? Data { get; set; }
        public PointTree<T>? Left { get; set; }
        public PointTree<T>? Right { get; set; }

        public PointTree(T d)
        {
            Data = d;
            Left = null;
            Right = null;
        }

        public PointTree()
        {
            Data = default(T);
            Left = null;
            Right = null;
        }

        public override string ToString()
        {
            return Data + " ";
        }
    }
}
