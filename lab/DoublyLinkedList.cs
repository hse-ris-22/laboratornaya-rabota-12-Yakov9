using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;

namespace lab
{
    public class DoublyLinkedList<T> where T : ICloneable
    {
        //первый элемент списка
        public PointList<T>? Beg { get; set; }
        //последний элемент списка
        public PointList<T>? End { get; set; }
        //длина списка
        int length;

        /// <summary>
        /// правила для длины
        /// </summary>
        public int Length 
        {
            get => length;
            //set
            //  {
            //    if (value <= 0)
            //        length = 0;
            //    else
            //        length = value;
            //  }
        }


        /// <summary>
        /// конструктор с параметром длины
        /// </summary>
        /// <param name="length"></param>
        public DoublyLinkedList(T data)
        {
            length = 1;
            PointList<T> beg = new PointList<T>(data); //создаем первый элемент
            Beg = beg;
            End = beg;
        }

        /// <summary>
        /// добавление элемента в список
        /// </summary>
        /// <param name="element"></param>
        public void AddElement(T element)
        {
            PointList<T>? p = new PointList<T>(element);
            PointList<T>? t = this.End;
            this.End.Next = p;
            this.End = p;
            this.End.Prev = t;
            length++;
        }

        /// <summary>
        /// удаление элемента из списка
        /// </summary>
        /// <param name="p"></param>
        public void DeleteElement(PointList<T> p)
        {
            if (this.Length == 1) //удаление единственного элемента списка
            {
                this.Beg = null;
                this.End = null;
            }
            else if (p?.Prev is null) //удаление первого элемента списка
            {
                this.Beg = this.Beg?.Next;
                this.Beg.Prev = null;
            }
            else if (p?.Next is null) //удаление последнего элемента списка
            {
                this.End = this.End?.Prev;
                this.End.Next = null;
            }
            else //удаление элемента в середине
            {
                p.Next.Prev = p?.Prev;
                p.Prev.Next = p?.Next;
            }
            length--;
        }

        /// <summary>
        /// удаление списка из памяти
        /// </summary>
        /// <param name="list"></param>
        public void RemoveListFromMemory()
        {
            this.Beg.Data = default(T);
            this.Beg.Next = null;
            this.Beg.Prev = null;
            this.End.Data = default(T);
            this.End.Next = null;
            this.End.Prev = null;
            this.length = 0;
        }


        [ExcludeFromCodeCoverage]
        /// <summary>
        /// вывод списка
        /// </summary>
        public void ShowList()
        {
            if (this.Length <= 0) //проверка длины
            {
                Console.WriteLine("Список пуст");
            }
            else
            {
                Console.WriteLine("Ваш список:");
                PointList<T>? p = Beg;
                while (p!=null)
                {
                    Console.WriteLine(p);
                    p = p?.Next;
                }
            }
        }

        /// <summary>
        /// клонирование списка
        /// </summary>
        /// <returns></returns>
        public DoublyLinkedList<T> Clone()
        {
            DoublyLinkedList<T> newList = new DoublyLinkedList<T>((T)this.Beg.Data.Clone());
            PointList<T>? pOld = Beg.Next;
            for (int i = 0; i < Length -1; i++, pOld = pOld.Next)
            {
                newList.AddElement((T)pOld.Data.Clone());
            }
            return newList;
        }
    }
}
