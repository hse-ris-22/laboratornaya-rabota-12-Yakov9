using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab
{
    public class Tree<T> where T : ICloneable, IInit, IComparable, new()
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

        public Tree(int size)
        {
            PointTree<T>? point = null;
            Size = size;
            R = CreateIdealTree(Size, point);
            Console.WriteLine("СОЗДАНО");
        }

        public Tree(PointTree<T> p, int size)
        {
            Size = size;
            R = p;
        }

        public static T GetInfo()
        {
            T? item = new T();
            item.RandomInit();
            return item;
        }

        public PointTree<T> CreateIdealTree(int size1, PointTree<T>? p)
        {
            int nl, nr;
            PointTree<T>? r;
            if (size1==0) 
            { 
                p=null;
                return p;
            }
            T d = GetInfo();
            nl=size1/2; nr=size1-nl-1;
            r = new PointTree<T>(d);
            r.Left=CreateIdealTree(nl, r.Left);
            r.Right=CreateIdealTree(nr, r.Right);
            return r;
        }

        public static void ShowTree(PointTree<T>? p, int l)
        {
            if (p!=null)
            {
                ShowTree(p.Left, l+10);
                for (int i = 0; i < l; i++)
                    Console.Write(" ");
                Console.WriteLine(p.Data);
                ShowTree(p.Right, l+10);
            }
        }

        public static PointTree<T> MakePoint(T d)
        {
            PointTree<T> p = new PointTree<T>(d);
            return p;
        }

        public PointTree<T> Add(PointTree<T> root, T d)
        {
            PointTree<T>? p = root;
            PointTree<T>? r = null;
            bool ok = false;
            while (p!=null && !ok)
            {
                r = p;
                //if (d == p.Data)
                if (d.Equals(p.Data))
                    ok = true;
                //else if (d < p.Data) 
                else if (d.CompareTo(p.Data) == -1)
                    p = p.Left;
                else p = p.Right;
            }
            if (ok) return p;
            PointTree<T> NewPoint = MakePoint(d);
            //if (d < r.Data)
            if (d.CompareTo(r.Data) == -1)
                r.Left = NewPoint;
            else r.Right = NewPoint;
            return root;
        }

        public Tree<T> CreateSearchTree()
        {
            PointTree<T>? newPoint = new PointTree<T>();
            Stack<PointTree<T>> inS = new Stack<PointTree<T>>();
            Stack<PointTree<T>> outS = new Stack<PointTree<T>>();
            PointTree<T> temp = new PointTree<T>();
            PointTree<T> item = new PointTree<T>();
            if (this.R!=null)
            {
                inS.Push(this.R);
                while (inS.Count>0)
                {
                    temp=inS.Pop();
                    outS.Push(temp);
                    if (temp.Left!=null) inS.Push(temp.Left);
                    if (temp.Right!=null) inS.Push(temp.Right);
                }
                while (outS.Count>0)
                {
                    item=outS.Pop();
                    newPoint.Add(newPoint, (T)item.Data.Clone());
                }
            }
            else
                Console.WriteLine("Дерево пустое");
            Tree<T> newTree = new Tree<T>(newPoint, this.Size);
            return newTree;
        }
    }
}
