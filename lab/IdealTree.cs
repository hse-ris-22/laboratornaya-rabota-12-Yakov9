using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab
{
    public class IdealTree<T> where T : ICloneable
    {
        public PointTree<T>? R { get; set; }
        public int size; //размер дерева

        /// <summary>
        /// правила для размера дерева
        /// </summary>
        public int Size
        {
            get => size;
            set
            {
                if (value >= 0)
                    size = value;
                else
                    size = 0;
            }
        }
    }
}
