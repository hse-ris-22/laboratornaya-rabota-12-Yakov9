using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab
{
    public class Tree<T> where T : ICloneable, IInit, IComparable<Person>, new()
    {
        public PointTree<T>? R { get; set; }
        public int size; //размер дерева

        /// <summary>
        /// правила для размера дерева
        /// </summary>
        public int Size
        {
            get => size;
        }

        /// <summary>
        /// конструктор с 1 параметром - размер
        /// </summary>
        /// <param name="sizeOfTree"></param>
        public Tree(int sizeOfTree)
        {
            PointTree<T>? point = null;
            size = sizeOfTree;
            R = CreateIdealTree(Size, point);
            Console.WriteLine("СОЗДАНО");
        }

        /// <summary>
        /// конструктор с двумя параметрами размер и дата
        /// </summary>
        /// <param name="p"></param>
        /// <param name="sizeOfTree"></param>
        public Tree(PointTree<T> p, int sizeOfTree, bool isSearchTree = false)
        {
            size = sizeOfTree;
            if (isSearchTree)
                R = p;
            else
                R = CreateIdealTree(Size, p);
        }

        /// <summary>
        /// рандомная инициализация объекта T
        /// </summary>
        /// <returns></returns>
        public static T GetInfo()
        {
            T? item = new T();
            item.RandomInit();
            return item;
        }

        /// <summary>
        /// создание идеально сбалансированного дерева
        /// </summary>
        /// <param name="size1"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public PointTree<T> CreateIdealTree(int size1, PointTree<T>? p)
        {
            int nl, nr;
            PointTree<T>? r;
            if (size1==0) //если размер равен нулю
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

        [ExcludeFromCodeCoverage]
        /// <summary>
        /// вывод дерева в консоли
        /// </summary>
        /// <param name="p"></param>
        /// <param name="l"></param>
        public static void ShowTree(PointTree<T>? p, int l)
        {
            if (p!=null) //проверка элемента дерева
            {
                ShowTree(p.Left, l+10);
                for (int i = 0; i < l; i++)
                    Console.Write(" ");
                Console.WriteLine(p.Data);
                ShowTree(p.Right, l+10);
            }
        }

        /// <summary>
        /// создание элемента дерева с data типа Person
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static PointTree<Person> MakePoint(Person d) 
        {
            PointTree<Person> p = new PointTree<Person>(d);
            return p;
        }

        /// <summary>
        /// добавление элемента в дерево поиска
        /// </summary>
        /// <param name="root"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        public static PointTree<Person> Add(PointTree<Person> root, Person d)
        {
            PointTree<Person>? p = root;
            PointTree<Person>? r = null;
            bool ok = false;
            while (p!=null && !ok)
            {
                r = p;
                //if (d == p.Data)
                if (d.CompareTo(p.Data) == 0)
                    ok = true;
                //else if (d < p.Data) 
                else if (d.CompareTo(p.Data) == -1)
                    p = p.Left;
                else p = p.Right;
            }
            if (ok) return p;
            PointTree<Person>? newPoint = Tree<Person>.MakePoint(d);
            //if (d < r.Data)
            if (d.CompareTo(r?.Data) == -1)
                r.Left = newPoint;
            else r.Right = newPoint;
            return root;
        }

        /// <summary>
        /// создание дерева поиска из идеально сбалансированного дерева
        /// </summary>      
        /// <param name="tree"></param>
        /// <returns></returns>
        public static Tree<Person> CreateSearchTree(Tree<Person> tree)
        {
            if (tree.R!=null)
            {
                PointTree<Person>? newPoint = new PointTree<Person>(tree.R.Data);
                Stack<PointTree<Person>> inS = new Stack<PointTree<Person>>();
                Stack<PointTree<Person>> outS = new Stack<PointTree<Person>>();
                PointTree<Person>? temp = new PointTree<Person>();
                PointTree<Person>? item = new PointTree<Person>();
                inS.Push(tree.R);
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
                    newPoint = Tree<T>.Add(newPoint, (Person)item.Data.Clone());
                }
                Tree<Person> newTree = new Tree<Person>(newPoint, tree.Size, true);
                Console.WriteLine("Дерево было трансформировано в дерево поиска.");
                return newTree;
            }
            else
            {
                Console.WriteLine("Дерево пустое, создайте новое дерево, нажав единицу");
                return tree;
            }
        }

        /// <summary>
        /// удаление дерева из памяти
        /// </summary>
        public void RemoveTreeFromMemory()
        {
            this.R = null;
            this.size = 0;
            Console.WriteLine("Дерево было удалено из памяти.");
        }
    }
}
